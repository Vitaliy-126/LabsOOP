#pragma once

class MyString
{
public:
	MyString();
	MyString(const char* str);
	~MyString();
	MyString(const MyString& other);
	void operator = (const MyString& other);
	int GetLength();
	char& operator[] (const int index);
	void Erase(int pos, int k);
private:
	char* str;
	int length;
};

class Text {
public:
	Text();
	~Text();
	void AddLine(const MyString& str);
	void DeleteLine(int row);
	void ClearText();
	int LenShortestLine();
	double PercentConsonants();
	void FormatSpaces();
	MyString& operator[] (const int index);
	int GetSize();
private:
	MyString* text;
	int rows;
	bool IsConsonant(char letter);
};