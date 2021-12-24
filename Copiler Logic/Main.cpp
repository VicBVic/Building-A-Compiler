#include <iostream>
#include "Expression.h"
#include "Operand.h"
int main()
{	
	Expression* a = new Expression;
	Expression* b = new Expression(Variable(10));
	Expression* c = new Expression(Variable(25));
	Expression* d = new Expression(Variable(30));
	Expression* e = new Expression();
	a->push_back(b, Operand(Operand::UNDEFINED));
	e->push_back(d, Operand(Operand::UNDEFINED));
	e->push_back(c, Operand(Operand::MULTIPLY));
	a->push_back(e, Operand(Operand::ADD)); //equivalent to 10+(25*30)
	std::cout << a->evaluate().value;
	return 0;
}