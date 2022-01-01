#pragma once
#include "Argument.h"
#include "Variable.h"
#include "Expression.h"
class Return :
    public Argument
{
public:
    Argument* execute();
    virtual Variable* get_value();
    virtual Argument* make_copy();
    void set_value(Expression* new_expr);
    void refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres);

private:
    Expression* return_expr;
};

