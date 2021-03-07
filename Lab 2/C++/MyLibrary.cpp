#include "MyLibrary.h"
#include <cctype>
using namespace std;

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

void MyString::operator = (const MyString& other) {
	length = other.length;
	str = new char[length + 1];
	for (int i = 0; i < length; i++) {
		str[i] = other.str[i];
	}
	str[length] = '\0';
}

MyString::MyString(const MyString& other) {
	length = other.length;
	str = new char[length + 1];
	for (int i = 0; i < length; i++) {
		str[i] = other.str[i];
	}
	str[length] = '\0';
}

int MyString::GetLength() {
	return length;
}

MyString::~MyString() {
	delete[]str;
}

char& MyString::operator[] (const int index)
{
	return str[index];
}

void MyString::Erase(int pos, int k) {
	if (pos >= 0 && k > 0 && (pos + k - 1) <= this->GetLength()) {
		MyString temp(*this);
		length = this->GetLength() - k;
		delete[]str;
		str = new char[length + 1];
		int i = 0,
			correction = 0;
		while (i < length) {
			if (i == pos)
				correction = k;
			str[i] = temp.str[i + correction];
			i++;
		}
		str[length] = '\0';
	}
}

Text::Text() {
	text = nullptr;
	rows = 0;
}

Text::~Text() {
	delete[]text;
}

void Text::AddLine(const MyString& str) {
	MyString* temp = new MyString[rows];
	if (text != nullptr) {
		for (int i = 0; i < rows; i++) {
			temp[i] = text[i];
		}
		delete[]text;
	}
	rows++;
	text = new MyString[rows];
	for (int i = 0; i < rows - 1; i++) {
		text[i] = temp[i];
	}
	text[rows - 1] = str;
	delete[]temp;
}

void Text::DeleteLine(int row) {
	if (row < rows) {
		if (text != nullptr && rows >= 1) {
			MyString* temp = new MyString[rows - 1];
			int start = 0,
				pos = 0;
			while (pos < rows) {
				if (pos != row) {
					temp[start] = text[pos];
					start++;
					pos++;
				}
				else pos++;
			}
			rows--;
			delete[]text;
			text = temp;
		}
	}
}

void Text::ClearText() {
	delete[]text;
	text = nullptr;
	rows = 0;
}

int Text::LenShortestLine() {
	if (rows == 0) return -1;
	else {
		int min = text[0].GetLength();
		int index = 0;
		for (int i = 1; i < rows; i++) {
			if (min > text[i].GetLength()) {
				min = text[i].GetLength();
				index = i;
			}
		}
		return index;
	}
}

MyString& Text::operator[] (const int index) {
	return text[index];
}

bool Text::IsConsonant(char letter) {
	bool result = true;
	MyString vowels = "aeiouy";
	for (int i = 0; i < vowels.GetLength(); i++) {
		if (vowels[i] == tolower(letter))
			result = false;
	}
	return result;
}

double Text::PercentConsonants() {
	int length,
		letters = 0,
		consonants = 0;
	for (int i = 0; i < rows; i++) {
		length = text[i].GetLength();
		for (int j = 0; j < length; j++) {
			if (isalpha(text[i][j])) {
				letters++;
				if (IsConsonant(text[i][j]))
					consonants++;
			}
		}
	}
	return ((double)consonants / letters) * 100;
}

void Text::FormatSpaces() {
	int j,
		counter = 0,
		start;
	for (int i = 0; i < rows; i++) {
		if (text[i].GetLength() > 0) {
			if (text[i][0] == ' ') {
				j = 0;
				counter = 0;
				while (text[i][j] == ' ') {
					counter++;
					j++;
				}
				text[i].Erase(0, counter);
			}
			if (text[i][text[i].GetLength() - 1] == ' ') {
				j = text[i].GetLength() - 1;
				counter = 0;
				while (text[i][j] == ' ') {
					counter++;
					j--;
				}
				text[i].Erase(j + 1, counter);
			}
			j = 0;
			start = 0;
			while (j < text[i].GetLength()) {
				counter = 0;
				if (text[i][j] == ' ') {
					start = j;
					while (text[i][j] == ' ') {
						counter++;
						j++;
					}
					if (counter > 1) {
						text[i].Erase(start, counter - 1);
						j = start;
					}
				}
				j++;
			}
		}
	}
}

int Text::GetSize() {
	return rows;
}