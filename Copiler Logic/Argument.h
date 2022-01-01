#pragma once
#include "Variable.h"
#include "Expression.h"
#include <map>


class Argument
{
private:
	Argument* next;
	Variable* ret_val = new Variable(-999);
public:
	Argument(Argument* next);
	Argument();
	virtual Argument* execute();
	Argument* get_next();
	virtual Variable* get_value();
	virtual void refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres);
	virtual void set_next(Argument* next);
};

