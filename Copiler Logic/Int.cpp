#include "Int.h"

#include "Int.h"

void Int::get_value(int& ret)
{
	ret = value;
}

void Int::get_value(std::string& ret)
{
	ret = std::to_string(value);
}

void Int::get_value(float& ret)
{
	ret = value;
}

void Int::set_value(int new_value)
{
	value = new_value;
}

void Int::set_value(std::string new_value)
{
	value = std::stoi(new_value);
}

void Int::set_value(float new_value)
{
	value = new_value;
}

void Int::copy_value(Variable* new_value)
{
	new_value->get_value(this->value);
}

Variable* Int::make_copy()
{
	Int* var = new Int;
	*var = *this;
	return var;
}

Int::Int(int value)
{
	this->value = value;
}

Int::Int()
{
	value = 0;
}

void Int::operate(Variable* other, const Operand operation)
{
	int conv = 0;
	other->get_value(conv);
	switch (operation.type)
	{
	case Operand::ADD:
		value += conv;
		break;
	case Operand::SUBSTRACT:
		value -= conv;
		break;
	case Operand::MULTIPLY:
		value *= conv;
		break;
	case Operand::DIVIDE:
		value /= conv;
		break;
	}
}

bool Int::can_operate(Variable* other, const Operand operation)
{
	try
	{
		int conv=0;
		other->get_value(conv);
		if (operation.type == Operand::DIVIDE && conv == 0) throw(0);
		return 1;
	}
	catch(int error)
	{
		return 0;
	}
}

bool Int::is_null()
{
	return value == 0;
}
