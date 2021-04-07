#include "Shapes.h"
#include <cmath>
Point::Point() {
	x = 0;
	y = 0;
}

Point::Point(double x, double y)
{
	this->x = x;
	this->y = y;
}

double Point::GetX() {
	return x;
}

double Point::GetY() {
	return y;
}

Shape::Shape(Point*points, int quantityVertexes)
{
	this->quantityVertexes = quantityVertexes;
	this->points = new Point[quantityVertexes];
	for (int i = 0; i < quantityVertexes; i++)
	{
		this->points[i] = points[i];
	}
}

Shape::~Shape() {
	delete[]points;
}

double Shape::SideLength(Point left, Point right)
{
	return sqrt(pow((right.GetX() - left.GetX()), 2) + pow((right.GetY() - left.GetY()), 2));
}

int Shape::QuantityVertexes()
{
	return quantityVertexes;
}

Point Shape::operator [](const int index) {
	if (index >= 0 && index < quantityVertexes)
	{
		return points[index];
	}
	else
	{
		throw "index out of range";
	}
}

Triangle::Triangle(Point* points) : Shape(points, 3)
{
	ASide = SideLength(points[0], points[1]);
	BSide = SideLength(points[0], points[2]);
	CSide = SideLength(points[1], points[2]);
	if (ASide + BSide <= CSide || ASide + CSide <= BSide || BSide + CSide <= ASide)
	{
		throw "such a triangle does not exist";
	}
}

double Triangle::Perimeter()
{
	return ASide + BSide + CSide;
}

double Triangle::Square()
{
	double halfPerimeter = Perimeter() / 2;
	double square = sqrt(halfPerimeter*(halfPerimeter - ASide)*(halfPerimeter - BSide)*(halfPerimeter - CSide));
	return square;
}
