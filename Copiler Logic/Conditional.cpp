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
	if (compare->evaluate().value)
	{
		return get_next();
	}
	else return get_other();
}
