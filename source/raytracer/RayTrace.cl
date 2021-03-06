
// OpenCL does not have float3 so I just use float4 and pack 1.0f in to the w component

// ---------------DATA structs coming from the host------------------------------------------------

typedef struct {
	float4 orig;
	float4 dir;
} ray;

typedef struct {
	float4 a, b, c;
	float4 na, nb, nc;
	int matIdx;
	int doubleSided;
	int filler[2];		// 16 byte alignment
} triangle;

typedef struct {
	float4 pos;
	float4 color;
	float4 attenuation;
} light;

typedef struct {
	float4	color;

	float ambient;
	float diffuse;
	float specular;
	float shininess;

	float reflection;
	float transparency;
	float refractionIndex;

	int filler;			// 8 byte alignment
} material;

// ------------------------------------------------------------------------------------------------

#define MAX_DIST FLT_MAX / 16.0f
#define EPS 0.0001f

#define FRONT_FACING 0
#define BACK_FACING 1

typedef struct {
	float4 pos;
	float dist;
	__global const triangle* tri;
	int facing;
} intersection;

bool intersects (const ray* r, __global const triangle* tri, intersection* outIsect)
{
	float4 edge1Dir = tri->b - tri->a;
	float4 edge2Dir = tri->c - tri->a;
	float4 pVec = cross (r->dir, edge2Dir);

	float det = dot (edge1Dir, pVec);
	if (det < EPS && !tri->doubleSided) {
		return false;
	}

	float invDet = 1.0f / det;

	float4 tVector = r->orig - tri->a;
	float u = dot (tVector, pVec) * invDet;
	
	if (u < 0.0f || u > 1.0f) {
		return false;
	}

	float4 qVector = cross (tVector, edge1Dir);
	float v = dot (r->dir, qVector) * invDet;
	if (v < 0.0f || (u + v) > 1.0f) {
		return false;
	}

	float distance = dot (edge2Dir, qVector) * invDet;
	if (distance < 0.0f) {
		return false;
	}

	outIsect->dist = distance;
	outIsect->pos = r->orig + (distance * r->dir);
	outIsect->tri = tri;
	outIsect->facing = det > 0.0f ? FRONT_FACING : BACK_FACING;

	return true;
}

bool isPointInShadow (float4 pos, 
				__global const light* l, 
				__global const triangle* triangles, 
				const int triangle_count) 
{
	// Get ray from point to light
	ray r;
	r.dir = normalize (l->pos - pos);
	r.orig = pos + EPS * r.dir;

	// Find the closest intersection.
	intersection minIsect;
	minIsect.dist = FLT_MAX;
	for (int j = 0; j < triangle_count; ++j) {
		__global const triangle* tri = &triangles[j];
		
		intersection isect;
		if (intersects (&r, tri, &isect)) {
			if (isect.dist < minIsect.dist)
				minIsect = isect;
		}
	}

	float lightDist = length (l->pos - pos);
	return lightDist > minIsect.dist;
}

float4 getReflectedDirection (const float4 direction, const float4 normal)
{
	float dotProduct = dot (normal, direction);
	return direction - (2.0f * normal * dotProduct);
}

float4 phongShading (const ray* ray,
						__global const light* light,
						__global const material* mat, 
						const intersection* isect, 
						const float4 normal)
{
	float4 lightDir = normalize (light->pos - isect->pos);
	float4 reflectionVector = getReflectedDirection (lightDir, normal);

	float lightNormalProduct = dot (lightDir, normal);	
	float diffuseCoeff = max (lightNormalProduct, 0.0f);

	float specularCoeff = pow (max (dot (reflectionVector, ray->dir), 0.0f), mat->shininess);

	float4 diffuseColor = light->color * mat->color * mat->diffuse;
	float4 color = diffuseColor * diffuseCoeff + mat->color * mat->specular * specularCoeff;		// TODO: mat.color should be the materials specular color
	
	// attenuation
	float intensity = 0.0f;
	float distance = length (isect->pos - light->pos);
	float denom = (light->attenuation.x + distance * light->attenuation.y + distance * light->attenuation.z * light->attenuation.z);
	if (denom < EPS) {
		intensity = 1.0f;
	}
	intensity = 1.0f / denom;
	color = color * intensity;

	return clamp (color, 0.0f, 1.0f);
}

float getTriangleArea (float a, float b, float c)
{
	float s = (a + b + c) / 2.0f;
	float areaSquare = s * (s - a) * (s - b) * (s - c);
	if (areaSquare < 0.0f) {
		return 0.0f;
	}
	return sqrt (areaSquare);
}

float4 barycentricInterpolation (float4 vertex0, float4 vertex1, float4 vertex2,
								float4 value0, float4 value1, float4 value2,
									   float4 interpolationVertex)
{
	float edge0 = length (vertex0 - vertex1);
	float edge1 = length (vertex1 - vertex2);
	float edge2 = length (vertex2 - vertex0);

	float distance0 = length (vertex0 - interpolationVertex);
	float distance1 = length (vertex1 - interpolationVertex);
	float distance2 = length (vertex2 - interpolationVertex);

	float area = getTriangleArea (edge0, edge1, edge2);
	if (area < EPS) {
		return value0;
	}

	float area0 = getTriangleArea (edge0, distance0, distance1);
	float area1 = getTriangleArea (edge1, distance1, distance2);
	float area2 = getTriangleArea (edge2, distance0, distance2);

	float4 interpolated = (value0 * area1 + value1 * area2 + value2 * area0) / area;
	return interpolated;
}

// Find the closest intersection.
void intersect_ray_model (const ray* r,
						__global const triangle* triangles,
						const int triangle_count,
						intersection* minIsect)
{
	minIsect->dist = FLT_MAX;
	for (int i = 0; i < triangle_count; ++i) {
		__global const triangle* tri = &triangles[i];
		
		intersection isect;
		if (intersects (r, tri, &isect)) {
			if (isect.dist < minIsect->dist)
				*minIsect = isect;
		}
	}
}

float4 get_direct_light_color (const ray* r,
								const intersection* isect,
								__global const triangle* triangles,
								const int triangle_count,
								__global const light* lights,
								const int light_count,
								__global const material* materials) 
{
	float4 color = (float4) (0.0f, 0.0f, 0.0f, 0.0f);

	if (isect->dist < MAX_DIST) {		// no intersection
		__global const material* mat = &materials[isect->tri->matIdx];
		color += mat->color * mat->ambient;

		// TODO: this should be precalculated
		// calculate normal where ray intersects the model
		float4 normal = barycentricInterpolation (isect->tri->a, isect->tri->b, isect->tri->c,
													isect->tri->na, isect->tri->nb, isect->tri->nc,
													isect->pos);

		//float4 rayDirectedNormal = isect->facing == FRONT_FACING ? normal : -1.0f * normal;

		// Light the point.
		for (int i = 0; i < light_count; ++i) {
			if (!isPointInShadow (isect->pos, &lights[i], triangles, triangle_count)) {			
				color += phongShading (r, &lights[i], mat, isect, normal);
			}
		}
	}

	return color;
}

float4 get_reflection_color (const ray* r,
								const intersection* isect,
								__global const triangle* triangles,
								const int triangle_count,
								__global const light* lights,
								const int light_count,
								__global const material* materials) 
{
	float4 color = (float4) (0.0f, 0.0f, 0.0f, 0.0f);

	intersection currIsect = *isect;
	ray currRay = *r;
	float color_attenuation = 1.0f;

	for (int i = 0; i < 10; i++) {

		// TODO: this should be precalculated
		float4 normal = barycentricInterpolation (currIsect.tri->a, currIsect.tri->b, currIsect.tri->c,
													currIsect.tri->na, currIsect.tri->nb, currIsect.tri->nc,
													currIsect.pos);
		float4 rayDirectedNormal = currIsect.facing == FRONT_FACING ? normal : -1.0f * normal;

		__global const material* mat = &materials[currIsect.tri->matIdx];
		if (mat->reflection > 0.0f) {
				float4 reflDir = getReflectedDirection (currRay.dir, rayDirectedNormal);
				ray reflRay;
				reflRay.orig = currIsect.pos + reflDir * EPS;		// offset origin a bit to avoid self intersection
				reflRay.dir = reflDir;

				intersection minIsect;
				intersect_ray_model (&reflRay, triangles, triangle_count, &minIsect);

				if (minIsect.dist > MAX_DIST) {
					break;
				}

				float4 reflColor = get_direct_light_color (&reflRay, &minIsect, triangles, triangle_count, lights, light_count, materials);
				color += reflColor * color_attenuation * mat->reflection;

				currIsect = minIsect;
				currRay = reflRay;
				color_attenuation *= mat->reflection;
		}
	}

	return color;
}

float4 trace_ray (const ray* r,
				__global const triangle* triangles,
				const int triangle_count,
				__global const light* lights,
				const int light_count,
				__global const material* materials)		// This is an array but there is no need to know it's size, since we don't want to iterate over it.)
{
	float4 color = (float4) (0.0f, 0.0f, 0.0f, 0.0f);

	intersection minIsect;
	intersect_ray_model (r, triangles, triangle_count, &minIsect);

	if (minIsect.dist < MAX_DIST) {
		color += get_direct_light_color (r, &minIsect, triangles, triangle_count, lights, light_count, materials);

		color += get_reflection_color (r, &minIsect, triangles, triangle_count, lights, light_count, materials);
	}

	return color;
}

__kernel void get_field_color (__global const ray* rays,
								const int ray_count,

								__global const triangle* triangles,
								const int triangle_count,

								__global const light* lights,
								const int light_count,

								__global const material* materials,		// This is an array but there is no need to know it's size, since we don't want to iterate over it.

								__global float4* color)
{
	const int idx = get_global_id (0);
	ray r = rays[idx];
		
	float4 col = trace_ray (&r, triangles, triangle_count, lights, light_count, materials);

	color[idx] = clamp (col, 0.0f, 1.0f);
}