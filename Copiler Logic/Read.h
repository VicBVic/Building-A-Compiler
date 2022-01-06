#pragma once
#include "Argument.h"
class Read :
    public Argument
{
public:
	Read();
	Read(Variable* target);
	void set_target(Variable* target);
	Variable* get_target();
	virtual Argument* execute();
	virtual Variable* get_value();
	virtual Argument* make_copy();
	virtual void refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres);
private:
    Variable* target;
};

