#pragma once

class Expression
{
public:
    Expression();
    Expression(double a, double c, double d);
    void SetA(double a);
    void SetC(double c);
    void SetD(double d);
    double GetValue();
private:
    double a;
    double c;
    double d;
};