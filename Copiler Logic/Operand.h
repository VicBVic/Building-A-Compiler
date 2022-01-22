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
	Operand(char type);
	int get_type(char c);

};

