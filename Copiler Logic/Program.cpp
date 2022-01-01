#include "Program.h"
#include <map>
Program::Program()
{
}
void Program::add_argument(Argument* arg)
{
	args.push_back(arg);
}

void Program::add_expression(Expression* exp)
{
	expres.push_back(exp);
}

void Program::add_variable(Variable* var)
{
	vars.push_back(var);
}

Variable* Program::evaluate()
{
	std::map<Argument*, Argument*> new_args;
	std::map< Variable*, Variable*> new_vars;
	std::map< Expression*, Expression*> new_expres;
	for (auto e : vars)
	{
		new_vars[e] = new Variable;
		*new_vars[e] = *e;
	}
	for (auto e : expres)
	{
		new_expres[e] = new Expression;
		*new_expres[e] = *e;
	}
	for (auto e : args)
	{
		new_args[e] = new Argument;
		*new_args[e] = *e;
	}
	for (auto e : new_expres)
	{
		e.second->refactor(&new_vars, &new_expres);
	}
	for (auto e : new_args)
	{
		e.second->refactor(&new_args, &new_vars, &new_expres);
	}

	Argument* curent = new_args[args[0]]; //cam din senin luata, trebuie sa prindem exceptie
	Argument* next = curent->execute();


	//heart of the process
	while (next != nullptr)
	{
		curent = next;
		next = curent->execute();
	}

	ans = *(curent->get_value());

	//rebound
	for (auto e : vars)
	{
		delete new_vars[e];
	}
	for (auto e : expres)
	{
		delete new_expres[e];
	}
	for (auto e : args)
	{
		delete new_args[e];
	}

	return (&ans);
}
