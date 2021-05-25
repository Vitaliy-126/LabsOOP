#include <iostream>
#include <Windows.h>
#include "SinglyLinkedList.h"
#include <ctime>
using namespace std;

int main() {
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
    srand(time(NULL));
    SinglyLinkedList list;
    int size;
    cout<<"������� ���-�� ����� ��� ���������: ";
    cin >> size;
    cout<<"��������������� �����: ";
    for (int i = 0; i < size; i++)
    {
        short number = (short)rand()%201-100;
        list.Add(number);
        cout<<number<<" ";
    }
    cout << endl;
    cout<<"����������� ������:";
    for (int i = 0; i < list.Size(); i++)
    {
        cout << list[i] << " ";
    }
    cout << endl;
    cout << "���-�� ����� ������� 3: "<<list.QuantityMultiplesOfThree()<< endl;
    list.RemoveLargeForAverage();
    cout<<"������ ����� �������� ���������, ������� ������ �� ������� ��������:"<<endl;
    for (int i = 0; i < list.Size(); i++)
    {
        cout<<list[i]<<" ";
    }
    cout << endl;
	system("pause");
	return 0;
}