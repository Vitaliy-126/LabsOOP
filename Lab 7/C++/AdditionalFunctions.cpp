#include <iostream>
#include <iomanip>
#include "Expression.h"
using namespace std;

void PrintMenu()
{
    cout << "Меню[0-2]:" << endl <<
        "0. Завершить програму" << endl <<
        "1. Установить значения выражению" << endl <<
        "2. Вычислить значение выражения" << endl;
}
void Menu(Expression expression)
{
    bool exit = false;
    int choice;
    do
    {
        PrintMenu();
        try
        {
            cout<<"Ваш выбор: ";
            cin >> choice;
            switch (choice)
            {
            case 0:
                exit = true;
                break;
            case 1:
                double a, c, d;
                cout<<"a = ";
                cin >> a;
                expression.SetA(a);
                cout<<"c = ";
                cin >> c;
                expression.SetC(c);
                cout<<"d = ";
                cin >> d;
                expression.SetD(d);
                break;
            case 2:
                cout<<"Значение выражения: " <<setprecision(2)<< expression.GetValue()<<endl;
                break;
            }
        }
        catch (exception ex)
        {
            cout << ex.what() << endl;
        }
    } while (!exit);
}