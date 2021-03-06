#ifndef RAYTRACER_HPP
#define RAYTRACER_HPP

#include "common.hpp"
#include "renderer.hpp"
#include "ray.hpp"
#include "intersection.hpp"

class RayTracer : public Renderer
{
public:
	RayTracer (const Model& model, const Camera& camera, int sampleNum);
	
private:
	virtual Color	GetFieldColor (const Image::Field& field) const override;
	Color			Trace (const Ray& ray, int depth) const;
	
	bool			IsInShadow (const Vec3& position, const Light& light) const;
};

#endif
