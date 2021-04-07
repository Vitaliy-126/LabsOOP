#include <Windows.h>
#include <iostream>
#include "Shapes.h"
using namespace std;

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	cout.precision(2);
	cout.setf(ios::fixed);
	Point* points = new Point[3];
	points[0] = Point(3, 5);
	points[1] = Point(5, 6);
	points[2] = Point(0, 0);
	Triangle triangle(points);
	cout << "Периметр треугольника: " << triangle.Perimeter() << endl;
	cout << "Площадь треугольника: " << triangle.Square() << endl;
	cout << "Стороны треугольника: A({0:.##}) , B({1:.##}) , C({2:.##})", triangle.ASide, triangle.BSide, triangle.CSide;
	cout << "Треугольник был создан с точок:" << endl;
	for (int i = 0; i < triangle.QuantityVertexes(); i++)
	{

	}
	system("pause");
	return 0;
}