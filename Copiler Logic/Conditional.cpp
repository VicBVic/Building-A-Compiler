#include "Conditional.h"

Conditional::Conditional(Argument* next, Argument* other, Expression* compare)
{
	set_next(next);
	set_other(other);
	this->compare = compare;
}

Argument* Conditional::get_other()
{
	return other;
}

void Conditional::set_other(Argument* other)
{
	this->other = other;
}

Argument* Conditional::execute()
{
	if (compare->evaluate()->get_value())
	{
		return get_next();
	}
	else return get_other();
}
void Conditional::refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres)
{
	Argument* next = get_next();
	Argument* other = get_other();
	if (args->find(next) != args->end())
	{
		set_next(args->find(next)->second);
	}
	if (args->find(other) != args->end())
	{
		set_other(args->find(other)->second);
	}
	if (expres->find(compare) != expres->end())
	{
		compare = expres->find(compare)->second;
	}
}
