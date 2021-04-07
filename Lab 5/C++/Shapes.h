#pragma once

class Point
{
public:
	Point();
	Point(double x, double y);
	double GetX();
	double GetY();
private:
	double x;
	double y;
};

class Shape
{
public:
	Shape(Point* points, int quantityVertexes);
	~Shape();
	static double SideLength(Point left, Point right);
	virtual double Perimeter() = 0;
	virtual double Square() = 0;
	Point operator [](const int index);
	int QuantityVertexes();
protected:
	int quantityVertexes;
	Point* points;
};

class Triangle : public Shape
{
public:
	double ASide;
	double BSide;
	double CSide;
	Triangle(Point* points);
	double Perimeter() override;
	double Square() override;
};