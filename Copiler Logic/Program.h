#pragma once
#include "Expression.h"
#include "Argument.h"
#include "Variable.h"
#include <vector>
#include <map>
class Program : public Expression
{
public:
	Program();
	void add_argument(Argument* arg);
	void add_expression(Expression* exp);
	void add_variable(Variable* var);
	Variable* evaluate();
private:
	Variable *ans;
	std::vector<Variable*> params;
	std::vector<Variable*> vars;
	std::vector<Expression*> expres;
	std::vector<Argument*> args;
};

