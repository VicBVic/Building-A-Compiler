#include "SetVar.h"

Argument* SetVar::execute()
{
    Variable* new_var = assign->evaluate();
    target->copy_value(new_var);
    delete new_var;
    return get_next();
}

Argument* SetVar::make_copy()
{
    SetVar* arg = new SetVar;
    *arg = *this;
    return arg;
}

void SetVar::refactor(std::map<Argument*, Argument*>* args, std::map<Variable*, Variable*>* vars, std::map<Expression*, Expression*>* expres)
{
    Argument* next = get_next();
    Variable* target = get_target();
    Expression* assign = get_assign();
    if (args->find(next) != args->end())
    {
        set_next(args->find(next)->second);
    }
    if (expres->find(assign) != expres->end())
    {
        set_assign(expres->find(assign)->second);
    }
    if (vars->find(target) != vars->end())
    {
        set_target(vars->find(target)->second);
    }

}

void SetVar::set_target(Variable* var)
{
    this->target = var;
}

void SetVar::set_assign(Expression* expr)
{
    this->assign = expr;
}

Variable* SetVar::get_target()
{
    return target;
}

Expression* SetVar::get_assign()
{
    return assign;
}
