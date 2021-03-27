#include <iostream>
#include <Windows.h>
#include "MyString.h"
using namespace std;

char* input();

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	MyString S1;
	cout<<"¬ведите строку S2:"<<endl;
	MyString S2(input());
	cout << "¬ведите строку S3:" << endl;
	MyString S3(input());
	cout<<"¬ведите символ, который желаете вычесть с S2: ";
	char symbol;
	cin >> symbol;
	S2=S2-symbol;
	cout<<"¬аша строка S2:"<<endl<<S2.GetLine()<<endl;
	cout<<"–езультат сложени€ S2 и S3:"<<endl;
	S1 = S2 + S3;
	cout << S1.GetLine() << endl;
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