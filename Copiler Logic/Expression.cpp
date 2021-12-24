#include "Expression.h"
#include "Variable.h"

Expression::Expression(const Variable defaultVal)
{
    members[0] = nullptr;
    memberCount = 0;
    this->defaultVal = defaultVal;
}
void Expression::push_back(Expression* newMember, Operand operation)
{
    members[memberCount] = newMember;
    operations[memberCount] = operation;
    memberCount++;
}

Expression::Expression()
{
    members[0] = nullptr;
    memberCount = 0;
    this->defaultVal = -99; //trebuie inlocuit
}

Variable Expression::evaluate()
{
    if (memberCount == 0)
    {
        return defaultVal;
    }
    else
    {
        Variable ans=members[0]->evaluate();
        for (int i = 1; i < memberCount; i++)
        {
            Variable memberValue = members[i]->evaluate();

            if (ans.can_operate(memberValue, operations[i]))
            {
                ans.operate(memberValue, operations[i]);
            }
            else
            {
                return defaultVal;
            }
        }
        return ans;
    }
}
