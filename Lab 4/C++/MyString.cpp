#include "MyString.h"

MyString::MyString() {
	str = nullptr;
	length = 0;
}

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

MyString::MyString(const MyString& other) {
	length = other.length;
	str = new char[length+1];
	for (int i = 0; i < length; i++) {
		str[i] = other.str[i];
	}
	str[length] = '\0';
}

MyString& MyString::operator = (const MyString& other) {
	if (str != nullptr) {
		delete[]str;
	}
	length = other.length;
	str = new char[length + 1];
	for (int i = 0; i < length; i++) {
		str[i] = other.str[i];
	}
	str[length] = '\0';
	return *this;
}

MyString::~MyString() {
	delete[]str;
}

int MyString::GetLength() {
	return length;
}

char* MyString::GetLine() {
	return str;
}

MyString MyString::operator +(const MyString& other) {
	MyString newStr;
	int thisLength = this->length;
	int otherLength = other.length;
	newStr.length=thisLength + otherLength;
	newStr.str = new char[newStr.length + 1];
	int i = 0;
	for (i; i < thisLength; i++) {
		newStr.str[i] = this->str[i];
	}
	for(int j=0;j<otherLength;j++,i++){
		newStr.str[i] = other.str[j];
	}
	newStr.str[thisLength + otherLength] = '\0';
	return newStr;
}

MyString MyString::operator +(char symbol) {
	MyString newStr;
	newStr.length = length+1;
	newStr.str = new char[newStr.length + 1];
	for (int i = 0; i < length; i++) {
		newStr.str[i] = str[i];
	}
	newStr.str[length] = symbol;
	newStr.str[newStr.length] = '\0';
	return newStr;
}

MyString MyString::operator -(char symbol) {
	int counter=0;
	for (int i = 0; i < length; i++) {
		if (str[i] == symbol)
			counter++;
	}
	MyString newStr;
	newStr.length = length - counter;
	newStr.str = new char[newStr.length + 1];
	int i = 0;
	for (int j = 0; j < length; j++) {
		if (str[j] != symbol) {
			newStr.str[i] = str[j];
			i++;
		}
	}
	newStr.str[newStr.length] = '\0';
	return newStr;
}