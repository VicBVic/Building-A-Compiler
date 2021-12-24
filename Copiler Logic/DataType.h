#pragma once
#include "Variable.h"
#include "Function.h"
class DataType
{
private:
	DataType(Variable &var);
	DataType(Function &func);
	bool variable;
	enum type {
		Void = 0,
		Int =1,
		Bool =2,

	};
public:
	Variable *var;
	Function *func;
};

