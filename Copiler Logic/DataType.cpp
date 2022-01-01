#include "DataType.h"

DataType::DataType(Variable &var) {
	variable = 1;
	this->var=&var;
	this->func = nullptr;
}

DataType::DataType(Function& func) {
	variable = 0;
	this->func = &func;
	this->var = nullptr;
}
