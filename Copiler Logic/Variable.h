#pragma once
#include "Operand.h"
class Variable
{
public:
	int get_value();
	void set_value(int value);
	Variable(int value);
	Variable();
	virtual Variable* make_copy();
	void operate(const Variable other,const Operand operation);
	bool can_operate(const Variable other, const Operand operation);
private:
	int value;
};

