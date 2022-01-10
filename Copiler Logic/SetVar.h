#pragma once
#include "Argument.h"
class SetVar :
    public Argument
{
public:
	virtual Argument* execute();
	virtual Argument* make_copy();
	virtual void refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres);
	void set_target(Variable* var);
	void set_assign(Expression* expr);
	Variable* get_target();
	Expression* get_assign();
private:
	Variable* target;
	Expression* assign;
};

