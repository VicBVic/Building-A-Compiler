#include "Read.h"
#include <iostream>
Read::Read()
{
	target = nullptr;
}

Read::Read(Variable* target)
{
	this->target = target;
}

void Read::set_target(Variable* target)
{
	this->target = target;
}

Variable* Read::get_target()
{
	return target;
}

Argument* Read::execute()
{
	std::string str;
	std::cin >> str;
	target->set_value(str);
	return get_next();
}

Variable* Read::get_value()
{
	return nullptr;
}

Argument* Read::make_copy()
{
	Read* arg = new Read;
	*arg = *this;
	return arg;
}

void Read::refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres)
{
	Argument* next = get_next();
	if (args->find(next) != args->end())
	{
		set_next(args->find(next)->second);
	}
	Variable* target = get_target();
	if (vars->find(target) != vars->end())
	{
		set_target(vars->find(target)->second);
	}
}
