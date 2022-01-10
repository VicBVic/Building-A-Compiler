#pragma once
#include "Variable.h"
#include "Operand.h"
#include <map>
#include <vector>

class Expression
{
private:
	std::vector<Expression*> members;
	std::vector<Operand> operations;
	Variable* defaultVal;
	int memberCount;
public:
	Expression(Variable* defaultVal);
	Expression();
	void push_back(Expression* newMember, Operand operation);
	virtual Expression* make_copy();
	virtual Variable* evaluate();
	void refactor(std::map<Variable*, Variable*>* vars,std::map<Expression*, Expression*>* expres);
};

