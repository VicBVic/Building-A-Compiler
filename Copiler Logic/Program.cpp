/*#include "Program.h"
#include <map>
template <typename T> Program<T>::Program()
{
	ans = new Variable;
}
template <typename T> void Program<T>::add_argument(Argument* arg)
{
	args.push_back(arg);
}

template <typename T>void Program<T>::add_expression(Expression* exp)
{
	expres.push_back(exp);
}

template <typename T> void Program<T>::add_variable(Variable* var)
{
	vars.push_back(var);
}

template <typename T> Variable* Program<T>::evaluate()
{
	std::map<Argument*, Argument*> new_args;
	std::map< Variable*, Variable*> new_vars;
	std::map< Expression*, Expression*> new_expres;
	for (auto e : vars)
	{
		new_vars[e] = e->make_copy();
	}
	for (auto e : expres)
	{
		new_expres[e] = e->make_copy();
	}
	for (auto e : args)
	{
		new_args[e] = e->make_copy();
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

	ans->copy_value(curent->get_value());

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

	return ans;
}
*/