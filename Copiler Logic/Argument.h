#pragma once




class Argument
{
private:
	Argument* next;
public:
	Argument(Argument* next);
	Argument();
	Argument* execute();
	Argument* get_next();
	void set_next(Argument* next);
};

