#include <Windows.h>
#include <iostream>
#include "Strings.h"
using namespace std;

char* input();

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	cout<<"������� �������� ������:"<<endl;
    MyString *str1 = new DigitalString(input());
    cout<<"������� ��������� ������:"<<endl;
    MyString *str2 = new LettersString(input());
    str1 = (*str1).SubtractSymbol();
    cout<<"������ ����� ���������:"<<endl;
    cout<<(*str1).GetLine();
	cout << " : " << (*str1).GetLength() << endl;
    str2 = (*str2).SubtractSymbol();
    cout<<(*str2).GetLine();
	cout << " : " << (*str2).GetLength() << endl;
	system("pause");
	return 0;
}

char* input() {
	int length,
		i = 0;
	char* temp = new char[256];
	while ((temp[i] = getchar()) != '\n' && i < 255) {
		i++;
	}
	temp[i] = '\0';
	length = strlen(temp);
	char* str = new char[length + 1];
	for (int i = 0; i < length; i++) {
		str[i] = temp[i];
	}
	str[length] = '\0';
	delete[]temp;
	return str;
}