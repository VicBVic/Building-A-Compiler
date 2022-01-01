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

Expression::Expression()
{
    memberCount = 0;
    this->defaultVal = nullptr;
}

Variable* Expression::evaluate()
{
    if (memberCount == 0)
    {
        return defaultVal;
    }
    else
    {
        ans.set_value(members[0]->evaluate()->get_value());
        for (int i = 1; i < memberCount; i++)
        {
            Variable memberValue = *(members[i]->evaluate());

            if (ans.can_operate(memberValue, operations[i]))
            {
                ans.operate(memberValue, operations[i]);
            }
            else
            {
                return defaultVal;
            }
        }
        return (&ans);
    }
}

void Expression::refactor(std::map<Variable*,Variable*>* vars,std::map<Expression*, Expression*>* expres)
{
    for (auto e : members)
    {
        if (expres->find(e) != expres->end())
        {
            e = expres->find(e)->second;
        }
    }
    if (vars->find(defaultVal) != vars->end())
    {
        defaultVal = vars->find(defaultVal)->second;
    }
}
