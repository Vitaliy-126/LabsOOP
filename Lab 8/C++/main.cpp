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
    cout<<"Введите кол-во чисел для генерации: ";
    cin >> size;
    cout<<"Сгенерированные числа: ";
    for (int i = 0; i < size; i++)
    {
        short number = (short)rand()%201-100;
        list.Add(number);
        cout<<number<<" ";
    }
    cout << endl;
    cout<<"Односвязный список:";
    for (int i = 0; i < list.Size(); i++)
    {
        cout << list[i] << " ";
    }
    cout << endl;
    cout << "Кол-во чисел кратных 3: "<<list.QuantityMultiplesOfThree()<< endl;
    list.RemoveLargeForAverage();
    cout<<"Список после удаления елементов, которые больше за среднее значение:"<<endl;
    for (int i = 0; i < list.Size(); i++)
    {
        cout<<list[i]<<" ";
    }
    cout << endl;
	system("pause");
	return 0;
}