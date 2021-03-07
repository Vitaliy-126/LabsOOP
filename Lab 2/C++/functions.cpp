#include "MyLibrary.h"
#include <iostream>
using namespace std;
void OutputText(Text& text, int rows) {
	for (int i = 0; i < rows; i++) {
		for (int j = 0; j < text[i].GetLength(); j++) {
			cout << text[i][j];
		}
		cout << endl;
	}
}

char* input() {
	int length,
		i = 0;
	char* temp = new char[256];
	std::cin.ignore(8192, '\n');
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

void PrintMenu() {
	cout << "MENU[0-8]:" << endl
		<< "0. Stop a program" << endl
		<< "1. Àdd a line to the text" << endl
		<< "2. Delete a line from the text" << endl
		<< "3. Clear the text" << endl
		<< "4. Find the length of the shortest row" << endl
		<< "5. Percentage of consonants in text" << endl
		<< "6. Format the spaces" << endl
		<< "7. Print text" << endl
		<< "8. Call Menu" << endl;
}

void Menu(Text& text) {
	bool need = true;
	int choice;
	PrintMenu();
	do {
		cout << "Your choice: ";
		cin >> choice;
		switch (choice)
		{
		case 0: {
			need = false;
			break;
		}
		case 1: {
			cout << "Enter the line" << endl;
			char* line = input();
			MyString str = line;
			delete[]line;
			text.AddLine(str);
			break;
		}
		case 2: {
			int index;
			cout << "Enter the index" << endl;
			cin >> index;
			text.DeleteLine(index);
			break;
		}
		case 3:
		{
			text.ClearText();
			break;
		}
		case 4: {
			cout << "The length of the shortest row: " << text.LenShortestLine() << endl;
			break;
		}
		case 5: {
			cout << text.PercentConsonants() << "%" << endl;
			break;
		}
		case 6: {
			text.FormatSpaces();
			break;
		}
		case 7: {
			cout << "Your text:" << endl;
			OutputText(text, text.GetSize());
			break;
		}
		case 8: {
			PrintMenu();
			break;
		}
		default:
			cout << "This item does not appear on the menu." << endl;
			break;
		}
	} while (need);
}