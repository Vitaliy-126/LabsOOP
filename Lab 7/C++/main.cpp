#include <Windows.h>
#include "Expression.h"
#include "AdditionalFunctions.h"
#include <iostream>
#include <iomanip>

using namespace std;

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
    cout<<"Программа для расчёта выражения: (2 * c - lg(d / 4)) / (a * a - 1)"<<endl;
    Expression expressions[] =
    {
        Expression(1,2,3),
        Expression(2,2,2),
        Expression(-2,3,-3)
    };
    for (int i = 0; i < 3; i++)
    {
        try
        {
            cout<<"Значение выражения "<<i+1<<": "<<setprecision(2)<<expressions[i].GetValue()<<endl;
        }
        catch (logic_error ex)
        {
            cout<<"У выражении "<<i+1<<":"<<endl;
            cout << ex.what() << endl;
        }
    }
	Expression expression;
	Menu(expression);
	system("pause");
	return 0;
}