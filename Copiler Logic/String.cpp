#include "String.h"

void String::get_value(int& ret)
{
	ret = std::stoi(value);
}

void String::get_value(std::string& ret)
{
	ret = value;
}

void String::get_value(float& ret)
{
	ret = std::stof(value);
}

void String::set_value(int new_value)
{
	value = std::to_string(new_value);
}

void String::set_value(std::string new_value)
{
	value = new_value;
}

void String::set_value(float new_value)
{
	value = std::to_string(new_value);
}

void String::copy_value(Variable* new_value)
{
	new_value->get_value(this->value);
}

Variable* String::make_copy()
{
	String* var = new String;
	*var = *this;
	return var;
}

String::String(std::string value)
{
	this->value = value;
}

String::String()
{
	value = "";
}

void String::operate(Variable* other, const Operand operation)
{
}

bool String::can_operate(Variable* other, const Operand operation)
{
	return false;
}

bool String::is_null()
{
	return value=="";
}
