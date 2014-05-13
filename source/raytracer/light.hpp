#ifndef LIGHT_HPP
#define LIGHT_HPP

#include "vec3.hpp"
#include "color.hpp"
#include "sphere.hpp"

class Light
{
public:
	Light ();
	Light (const Sphere& sphere, const Color& color, const Vec3& attenuation);
	~Light ();

	void			Set (const Sphere& sphere, const Color& color, const Vec3& attenuation);

	const Vec3&		GetPosition () const;
	double			GetRadius () const;
	const Color&	GetColor () const;
	const Vec3&		GetAttenuation () const;
	
	Vec3			GetRandomPoint () const;
	double			GetIntensity (double distance) const;

private:
	Sphere			sphere;
	Color			color;
	Vec3			attenuation;
};

#endif
