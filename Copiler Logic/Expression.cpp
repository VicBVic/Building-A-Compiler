#include "Expression.h"
#include "Variable.h"

Expression::Expression(Variable* defaultVal)
{
    memberCount = 0;
    this->defaultVal = defaultVal;
}
void Expression::push_back(Expression* newMember, Operand operation)
{
    members.push_back(newMember);
    operations.push_back(operation);
    memberCount++;
}

void Expression::push_back_mem(Expression* newMember)
{
    members.push_back(newMember);
    memberCount++;
}

void Expression::push_back_oper(Operand operation)
{
    operations.push_back(operation);
}

Expression* Expression::make_copy()
{
    Expression* exp = new Expression;
    *exp = *this;
    return exp;
}

Expression::Expression()
{
    memberCount = 0;
    this->defaultVal = nullptr;
}

Variable* Expression::evaluate()
{
    if (memberCount == 0)
    {
        return defaultVal->make_copy();
    }
    else
    {
        Variable* ans = members[0]->evaluate();
        for (int i = 1; i < memberCount; i++)
        {
            Variable* memberValue=members[i]->evaluate();

            if (ans->can_operate(memberValue, operations[i-1]))
            {
                ans->operate(memberValue, operations[i-1]);
                delete memberValue;
            }
            else
            {
                delete memberValue;
                return defaultVal->make_copy();
            }
        }
        return ans;
    }
}

void Expression::refactor(std::map<Variable*,Variable*>* vars,std::map<Expression*, Expression*>* expres)
{
    for (int i=0;i<members.size();i++)
    {
        if (expres->find(members[i]) != expres->end())
        {
            members[i] = expres->find(members[i])->second;
        }
    }
    if (vars->find(defaultVal) != vars->end())
    {
        defaultVal = vars->find(defaultVal)->second;
    }
}
