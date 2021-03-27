#pragma once

class MyString
{
public:
	MyString();
	MyString(const char* str);
	MyString(const MyString& other);
	~MyString();
	int GetLength();
	char* GetLine();
	MyString& operator = (const MyString& other);
	MyString operator +(const MyString& other); 
	MyString operator +(char symbol);
	MyString operator -(char symbol);
private:
	char* str;
	int length;
};
