#include "Write.h"
#include <iostream>
#include "String.h"
Write::Write()
{
	assign = nullptr;
}

Write::Write(Expression* assign)
{
	this->assign = assign;
}

void Write::set_assign(Expression* assign)
{
	this->assign = assign;
}

Expression* Write::get_assign()
{
	return assign;
}

Argument* Write::execute()
{
	std::string ans;
	Variable* val = assign->evaluate();
	val->get_value(ans);
	std::cout <<ans;
	delete val;
	return get_next();
}

Variable* Write::get_value()
{
	return assign->evaluate();
}

Argument* Write::make_copy()
{
	Write* arg = new Write;
	*arg = *this;
	return arg;
}

void Write::refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres)
{
	Argument* next = get_next();
	if (args->find(next) != args->end())
	{
		set_next(args->find(next)->second);
	}
	Expression* assign = get_assign();
	if (expres->find(assign) != expres->end())
	{
		set_assign(expres->find(assign)->second);
	}
}
