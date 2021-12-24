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
    Conditional(Argument* next, Argument* other, Expression* compare);
    Argument* get_other();
    void set_other(Argument* other);
    Argument* execute();


};

