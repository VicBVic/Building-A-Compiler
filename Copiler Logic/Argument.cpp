#include "Argument.h"

Argument::Argument()
{
	set_next(nullptr);
}

Argument::Argument(Argument* next)
{
	set_next(next);
}

Argument* Argument::execute()
{
	return next;
}

Argument* Argument::get_next()
{
	return next;
}
Variable* Argument::get_value()
{
	return ret_val;
}

void Argument::refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres)
{
	Argument* next = get_next();
	if (args->find(next)!=args->end())
	{
		set_next(args->find(next)->second);
	}
}

void Argument::set_next(Argument* next)
{
	this->next = next;
}
