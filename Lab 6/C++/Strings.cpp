#include "Strings.h"
#include <ctype.h>
MyString::MyString()
{
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
int MyString::GetLength()
{
    return length;
}
char* MyString::GetLine()
{
    return str;
}

DigitalString::DigitalString()
{

}
DigitalString::DigitalString(char* str) : MyString(str)
{
    for (int i = 0; i < length; i++)
    {
        if (!isdigit(this->str[i])) {
            throw "it is impossible to create a digital string";
        }
    }
}
MyString* DigitalString::SubtractSymbol()
{
    int counter = 0;
    for (int i = 0; i < length; i++)
    {
        if (str[i] == '5')
        {
            counter++;
        }
    }
    DigitalString* newStr = new DigitalString();
    newStr->length = length - counter;
    newStr->str = new char[newStr->length];
    int pos = 0;
    for (int i = 0; i < length; i++)
    {
        if (str[i] != '5')
        {
            newStr->str[pos] = str[i];
            pos++;
        }
    }
    newStr->str[newStr->length] = '\0';
    return newStr;
}

LettersString::LettersString()
{

}
LettersString::LettersString(char*str) : MyString(str)
{
    for (int i = 0; i < length; i++)
    {
        if (!IsLetter(this->str[i]))
        {
            throw "it is impossible to create a letters string";
        }
    }
}
MyString* LettersString::SubtractSymbol()
{
    int counter = 0;
    for (int i = 0; i < length; i++)
    {
        if (str[i] == 'à')
        {
            counter++;
        }
    }
    LettersString* newStr = new LettersString();
    newStr->length = length - counter;
    newStr->str = new char[newStr->length];
    int pos = 0;
    for (int i = 0; i < length; i++)
    {
        if (str[i] != 'à')
        {
            newStr->str[pos] = str[i];
            pos++;
        }
    }
    newStr->str[newStr->length] = '\0';
    return newStr;
}