#include "Return.h"

Argument* Return::execute()
{
    return nullptr;
}

Variable* Return::get_value()
{
    return return_expr->evaluate();
}

void Return::set_value(Expression* new_expr)
{
    return_expr = new_expr;
}

void Return::refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres)
{
    if (expres->find(return_expr) != expres->end())
    {
        return_expr = expres->find(return_expr)->second;
    }
}
