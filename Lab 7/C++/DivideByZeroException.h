#pragma once

#include <stdexcept>

class DivideByZeroException : public std::logic_error
{
public:
	DivideByZeroException(const std::string& message);
	DivideByZeroException(const char* message);
	DivideByZeroException(const DivideByZeroException& other) noexcept;
};