#include "image.hpp"
#include "common.hpp"

#include <math.h>

Image::Image (const Camera& camera, int resolutionX, int resolutionY, double distance)
{
	double imageWidth = distance * tan (camera.GetXFov () * DEGRAD) * distance;
	double imageHeight = distance * tan (camera.GetYFov () * DEGRAD) * distance;
	fieldWidth = imageWidth / (double) resolutionX;
	fieldHeight = imageHeight / (double) resolutionY;
	
	Coord eyeToCenter = Normalize (camera.GetCenter () - camera.GetEye ());
	xDirection = Normalize (eyeToCenter ^ camera.GetUp ());
	yDirection = Normalize (xDirection ^ eyeToCenter);

	Coord pyramidBottom = Offset (camera.GetEye (), eyeToCenter, distance);
	bottomLeft = pyramidBottom;
	bottomLeft = Offset (bottomLeft, xDirection * -1.0, imageWidth / 2.0);
	bottomLeft = Offset (bottomLeft, yDirection * -1.0, imageHeight / 2.0);
}

Image::~Image ()
{

}

Coord Image::GetFieldCenter (int x, int y) const
{
	Coord result = bottomLeft;
	result = Offset (result, xDirection, x * fieldWidth + fieldWidth / 2.0);
	result = Offset (result, yDirection, y * fieldHeight + fieldHeight / 2.0);
	return result;
}
