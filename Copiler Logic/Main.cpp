#include <iostream>
#include <fstream>
#include "Expression.h"
#include "Operand.h"
#include "Program.h"
#include "Return.h"

std::ifstream in("main.tmp");
int main()
{	
	Variable* returnVal = new Variable(5318008);
	Expression* returnExp = new Expression(returnVal);
	Argument* a = new Argument;
	Argument* b = new Argument;
	Argument* c = new Argument;
	Return* d = new Return;
	a->set_next(b);
	b->set_next(c);
	c->set_next(d);
	d->set_value(returnExp);
	Program* main = new Program;
	main->add_argument(d);
	main->add_expression(returnExp);
	main->add_variable(returnVal);
	std::cout << main->evaluate()->get_value();
	return 0;
}