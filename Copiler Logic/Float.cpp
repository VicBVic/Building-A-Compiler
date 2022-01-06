#include "Float.h"

void Float::get_value(int& ret)
{
	ret = value;
}

void Float::get_value(std::string& ret)
{
	ret = std::to_string(value);
}

void Float::get_value(float& ret)
{
	ret = value;
}

void Float::set_value(int new_value)
{
	value =	new_value;
}

void Float::set_value(std::string new_value)
{
	value = std::stof(new_value);
}

void Float::set_value(float new_value)
{
	value = new_value;
}

void Float::copy_value(Variable* new_value)
{
	new_value->get_value(this->value);
}

Variable* Float::make_copy()
{
	Float* var = new Float;
	*var = *this;
	return var;
}

Float::Float(float value)
{
	this->value = value;
}

Float::Float()
{
	value = 0.0f;
}

void Float::operate(Variable* other, const Operand operation)
{
}

bool Float::can_operate(Variable* other, const Operand operation)
{
	return false;
}

bool Float::is_null()
{
	return value == 0.0f;
}
