#include "Variable.h"
#include "Operand.h"

Variable::Variable(int value)
{
	this->value = value;
}

Variable::Variable()
{
	value = 0;
}


void Variable::operate(const Variable other, const Operand operation)
{
	//the heart of operation magic
	switch (operation.type)
	{
	case Operand::ADD:
		this->value += other.value;
		break;
	case Operand::SUBSTRACT:
		this->value -= other.value;
		break;
	case Operand::MULTIPLY:
		this->value *= other.value;
		break;
	case Operand::DIVIDE:
		this->value /= other.value;
		break;

	}
}

bool Variable::can_operate(const Variable other, const Operand operation)
{
	return (operation.type!=Operand::DIVIDE||other.value!=0);
}
