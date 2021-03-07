#include <iostream>
#include <Windows.h>
#include "MyLibrary.h"
#include "functions.h"
using namespace std;

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	Text text;
	Menu(text);
	system("pause");
	return 0;
}