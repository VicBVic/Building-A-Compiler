#pragma once
#include "Variable.h"
#include "Operand.h"

constexpr auto maxSize = 1000;

class Expression
{
private:
	Expression* members[maxSize];
	Operand operations[maxSize];
	Variable defaultVal;
	int memberCount;
public:
	Expression(Variable defaultVal);
	Expression();
	void push_back(Expression* newMember, Operand operation);
	Variable evaluate();
};

