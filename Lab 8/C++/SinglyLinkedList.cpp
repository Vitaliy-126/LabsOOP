#include "SinglyLinkedList.h"
#include <stdexcept>
#include <exception>

using namespace std;
Node::Node(short value)
{
	this->value = value;
    this->next = nullptr;
}

void Node::SetNext(Node* next)
{
    this->next = next;
}

Node* Node::GetNext()
{
    return next;
}

short Node::GetValue()
{
    return value;
}

SinglyLinkedList::SinglyLinkedList()
{
    size = 0;
    first = nullptr;
    last = nullptr;
}

void SinglyLinkedList::Add(short value)
{
    if (first != nullptr)
    {
        Node* node = new Node(value);
        node->SetNext(first);
        first = node;
        size++;
    }
    else
    {
        first = last = new Node(value);
        size = 1;
    }
}

int SinglyLinkedList::QuantityMultiplesOfThree()
{
    int counter = 0;
    Node* currentNode = first;
    while (currentNode != nullptr)
    {
        if (currentNode->GetValue() % 3 == 0)
        {
            counter++;
        }
        currentNode = currentNode->GetNext();
    }
    return counter;
}

void SinglyLinkedList::RemoveLargeForAverage()
{
    double mean = 0;
    Node* currentNode = first;
    while (currentNode != nullptr)
    {
        mean += currentNode->GetValue();
        currentNode = currentNode->GetNext();
    }
    mean /= size;
    Node* prevNode = nullptr;
    currentNode = first;
    while (currentNode != nullptr)
    {
        if (currentNode->GetValue() > mean)
        {
            if (prevNode == nullptr)
            {
                first = currentNode->GetNext();
                size--;
            }
            else
            {
                prevNode->SetNext(currentNode->GetNext());
                size--;
            }
        }
        else
        {
            prevNode = currentNode;
        }
        currentNode = currentNode->GetNext();
    }
    last = prevNode;
}

short SinglyLinkedList::operator[](const int index)
{
    if (index < 0 || index >= size)
    {
        throw out_of_range("Index out of range");
    }
    if (size == 0)
    {
        throw logic_error("The list is empty");
    }
    int counter = 0;
    Node* currentNode = first;
    while (currentNode != nullptr)
    {
        if (counter == index)
        {
            return currentNode->GetValue();
        }
        currentNode = currentNode->GetNext();
        counter++;
    }
}

int SinglyLinkedList::Size()
{
    return size;
}
