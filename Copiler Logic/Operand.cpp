#include "Operand.h"

Operand::Operand(int type)
{
	this->type = type;
}

Operand::Operand()
{
	type = UNDEFINED;
}
