#pragma once
#include "Variable.h"
class String :
    public Variable
{
public:
	virtual void get_value(int& ret);
	virtual void get_value(std::string& ret);
	virtual void get_value(float& ret);
	virtual void set_value(int new_value);
	virtual void set_value(std::string new_value);
	virtual void set_value(float new_value);
	virtual void copy_value(Variable* new_value);
	virtual Variable* make_copy();
	String(std::string value);
	String();
	virtual void operate(Variable* other, const Operand operation);
	virtual bool can_operate(Variable* other, const Operand operation);
	virtual bool is_null();
	//friend std::ostream& operator<< (std::ostream& os, const String& c);
private:
	std::string value;
};

