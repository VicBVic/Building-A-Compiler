#pragma once
#include "Operand.h"
class Variable
{
public:
	int value;
	Variable(int value);
	Variable();
	void operate(const Variable other,const Operand operation);
	bool can_operate(const Variable other, const Operand operation);
};

