#include "Expression.h"
#include <cmath>
#include <exception>

Expression::Expression() {
    this->a = 0;
    this->c = 0;
    this->d = 0;
};

Expression::Expression(double a, double c, double d) {
	this->a = a;
	this->c = c;
	this->d = d;
}

void Expression::SetA(double a) {
	this->a = a;
}

void Expression::SetC(double c) {
	this->c = c;
}

void Expression::SetD(double d) {
	this->d = d;
}

double Expression::GetValue() {
    if (d / 4 <= 0)
    {
        throw std::exception("the expression under the logarithm must be greater than zero");
    }
    else if (a * a - 1 == 0)
    {
        throw std::exception("division by zero occurred in the denominator");
    }
    else
    {
        return (2 * c - log10(d / 4)) / (a * a - 1);
    }
}