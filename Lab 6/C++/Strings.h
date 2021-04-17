#pragma once

class MyString
{
public:

    MyString();

    MyString(const char* str);

    virtual MyString* SubtractSymbol() = 0;

    virtual int GetLength();

    char* GetLine();

protected:
    char* str;
    int length;
};

class DigitalString : public MyString
{
public:
    DigitalString();
    DigitalString(char* str);
    MyString* SubtractSymbol() override;
};

class LettersString : public MyString
{
public:
    LettersString();
    LettersString(char* str);
    MyString* SubtractSymbol() override;
private:
    bool IsLetter(char symbol) {
        for (int i = 192; i <= 255; i++) {
            if (symbol == (char)i) {
                return true;
            }
        }
        return false;
    }
};