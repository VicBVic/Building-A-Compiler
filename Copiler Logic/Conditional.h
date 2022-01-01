#pragma once
#include "Argument.h"
#include "Expression.h"
class Conditional :
    public Argument
{
private:
    Argument* other;
    Expression* compare;
public:
    Conditional();
    Conditional(Argument* next, Argument* other, Expression* compare);
    Argument* get_other();
    void set_other(Argument* other);
    virtual Argument* make_copy();
    Argument* execute();
    void refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres);
};

