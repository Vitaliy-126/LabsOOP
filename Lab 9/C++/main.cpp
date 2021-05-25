#include <iostream>
#include <Windows.h>
#include "MyString.h"
using namespace std;

int FindIndexSymbol(MyString& line, char symbol);
char* input();

int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);
	int (*pFunction)(MyString& line, char symbol) = FindIndexSymbol;
	cout << "Введите строку: ";
	MyString line(input());
	cout << "Введите символ: ";
	char symbol;
	cin >> symbol;
	cout << "Индекс первого вхождения " << symbol << " : " << pFunction(line, symbol) << endl;
    system("pause");
    return 0;
}

int FindIndexSymbol(MyString& line, char symbol) {
	for (int i = 0; i < line.GetLength(); i++) {
		if (line.GetLine()[i] == symbol) {
			return i;
		}
	}
	return -1;
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