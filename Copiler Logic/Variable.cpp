#include "Variable.h"
#include "Operand.h"

void Variable::set_value(int value)
{
}

void Variable::set_value(std::string new_value)
{
}

void Variable::set_value(float new_value)
{
}

void Variable::copy_value(Variable* new_value)
{
}

void Variable::get_value(int& ret)
{
	ret = 0;
}

void Variable::get_value(std::string& ret)
{
	ret = "you failed here bitch";
}

void Variable::get_value(float& ret)
{
	ret = 0.0;
}

Variable::Variable()
{
}

Variable* Variable::make_copy()
{
	Variable* var = new Variable;
	*var = *this;
	return var;
}


void Variable::operate(Variable* other, const Operand operation)
{
	//the heart of operation magic
}

bool Variable::can_operate(Variable* other, const Operand operation)
{
	return 0; //decide if you can actually do stuff
}

bool Variable::is_null()
{
	return 1; 
}
