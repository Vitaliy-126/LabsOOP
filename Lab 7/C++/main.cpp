#include <Windows.h>
#include "Expression.h"
#include "AdditionalFunctions.h"

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	Expression expression;
	Menu(expression);
	system("pause");
	return 0;
}