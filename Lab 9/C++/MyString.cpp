#include "MyString.h"

MyString::MyString(const char* str)
{
	length = 0;
	while (str[length] != '\0')
		length++;
	this->str = new char[length + 1];
	for (int i = 0; i < length; i++) {
		this->str[i] = str[i];
	}
	this->str[length] = '\0';
}

MyString::~MyString()
{
	delete[]str;
}

int MyString::GetLength()
{
	return length;
}

char* MyString::GetLine()
{
	return str;
}
