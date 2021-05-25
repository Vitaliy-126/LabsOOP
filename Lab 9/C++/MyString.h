#pragma once

class MyString
{
public:
	MyString(const char* str);
	~MyString();
	int GetLength();
	char* GetLine();
private:
	char* str;
	int length;
};