#pragma once
class Operand
{
public:
	enum {
		UNDEFINED,
		ADD,
		SUBSTRACT,
		MULTIPLY,
		DIVIDE
	};
	int type;
	Operand(int type);
	Operand();

};

