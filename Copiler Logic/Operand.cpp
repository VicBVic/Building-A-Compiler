#include "Operand.h"

Operand::Operand(int type)
{
	this->type = type;
}

Operand::Operand()
{
	type = UNDEFINED;
}

Operand::Operand(char c)
{
	this->type = get_type(c);
}

int Operand::get_type(char c)
{
	switch (c)
	{
	case '+':
		return ADD;
	case '-':
		return SUBSTRACT;
	case '/':
		return DIVIDE;
	case '*':
		return MULTIPLY;
	default:
		return UNDEFINED;
	}
}
