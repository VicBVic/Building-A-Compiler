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

void Argument::set_next(Argument* next)
{
	this->next = next;
}
