#ifndef MESH_HPP
#define MESH_HPP

#include "coord.hpp"
#include "material.hpp"
#include <vector>

class Triangle
{
public:
	Triangle ();
	Triangle (int v0, int v1, int v2, int mat);
	~Triangle ();

	int		v0;
	int		v1;
	int		v2;
	int		mat;
};

class Mesh
{
public:
	Mesh ();
	~Mesh ();

	int						AddVertex (const Coord& coord);
	int						AddTriangle (const Triangle& triangle);
	int						AddMaterial (const Material& material);

	int						VertexCount () const;
	int						TriangleCount () const;
	int						MaterialCount () const;

	const Coord&			GetVertex (int index) const;
	const Triangle&			GetTriangle (int index) const;
	const Coord&			GetNormal (int index) const;
	const Material&			GetMaterial (int index) const;

private:
	Coord					CalculateNormal (int index);

	std::vector<Coord>		vertices;
	std::vector<Triangle>	triangles;
	std::vector<Coord>		normals;
	std::vector<Material>	materials;
};

#endif