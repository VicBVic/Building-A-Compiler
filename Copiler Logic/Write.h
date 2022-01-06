#pragma once
#include "Argument.h"
class Write:
	public Argument
{
public:
	Write();
	Write(Expression* assign);
	void set_assign(Expression* assign);
	Expression* get_assign();
	virtual Argument* execute();
	virtual Variable* get_value();
	virtual Argument* make_copy();
	virtual void refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres);
private:
	Expression* assign;
};

