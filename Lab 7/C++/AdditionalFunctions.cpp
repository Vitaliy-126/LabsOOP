#include <iostream>
#include <iomanip>
#include "Expression.h"
using namespace std;

void PrintMenu()
{
    cout << "����[0-2]:" << endl <<
        "0. ��������� ��������" << endl <<
        "1. ���������� �������� ���������" << endl <<
        "2. ��������� �������� ���������" << endl;
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
            cout<<"��� �����: ";
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
                cout<<"�������� ���������: " <<setprecision(2)<< expression.GetValue()<<endl;
                break;
            }
        }
        catch (exception ex)
        {
            cout << ex.what() << endl;
        }
    } while (!exit);
}