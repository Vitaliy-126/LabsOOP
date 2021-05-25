#pragma once

class Node
{
public:
    Node(short value);
    void SetNext(Node* next);
    Node* GetNext();
    short GetValue();
private:
    short value;
    Node* next;
};

class SinglyLinkedList {
public:
    SinglyLinkedList();
    void Add(short value);
    int QuantityMultiplesOfThree();
    void RemoveLargeForAverage();
    short operator [](const int index);
    int Size();
private:
    Node* first;
    Node* last;
    int size;
};