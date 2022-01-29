#pragma once
#include "Expression.h"
#include "Argument.h"
#include "Variable.h"
#include <vector>
#include <map>
template <typename T=Variable> class Program : public Expression
{
public:
	Program()
	{
	}
	void add_argument(Argument* arg)
	{
		args.push_back(arg);
	}
	void add_expression(Expression* exp)
	{
		expres.push_back(exp);
	}
	void add_variable(Variable* var)
	{
		vars.push_back(var);
	}
	virtual Variable* evaluate()
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
		Variable* ans =curent->get_value();

		//rebound
		for (auto e : new_vars)
		{
			delete e.second;
		}
		for (auto e : new_expres)
		{
			delete e.second;
		}
		for (auto e : new_args)
		{
			delete e.second;
		}

		return ans;
	}
private:
	std::vector<Variable*> params;
	std::vector<Variable*> vars;
	std::vector<Expression*> expres;
	std::vector<Argument*> args;
};

