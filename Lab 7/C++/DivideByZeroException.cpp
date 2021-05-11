#include "DivideByZeroException.h"

DivideByZeroException::DivideByZeroException(const std::string& message) : logic_error(message) {	}
DivideByZeroException::DivideByZeroException(const char* message) : logic_error(message) {	}
DivideByZeroException::DivideByZeroException(const DivideByZeroException& other) noexcept : logic_error(other) {	}