#include "Variable.h"
#include "Operand.h"

int Variable::get_value()
{
	return value;
}

void Variable::set_value(int value)
{
	this->value = value;
}

Variable::Variable(int value)
{
	this->value = value;
}

Variable::Variable()
{
	value = 0;
}

Variable* Variable::make_copy()
{
	Variable* var = new Variable;
	*var = *this;
	return var;
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
