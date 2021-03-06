#pragma once
#include "Variable.h"
#include "Expression.h"
#include <map>


class Argument
{
private:
	Argument* next;
	Variable* ret_val = new Variable();
public:
	Argument(Argument* next);
	Argument();
	Argument* get_next();
	virtual Argument* execute();
	virtual Variable* get_value();
	virtual Argument* make_copy();
	virtual void refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres);
	void set_next(Argument* next);
};

