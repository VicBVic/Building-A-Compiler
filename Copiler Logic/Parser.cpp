#pragma once
#include "Parser.h"
#include "Int.h"
#include "String.h"
#include "Float.h"
#include "Write.h"
#include "Return.h";
#include "SetVar.h"
#include <vector>
#include <string>
#include <fstream>
#include <iostream>
#include <stack>
Parser::Parser()
{
	//aici pui ce vrei sa rezervi

	reserved.addLine(initInt(ADDINT), "int");
	reserved.addLine(initInt(ADDSTRING), "string");
	reserved.addLine(initInt(ADDFLOAT), "float");
	reserved.addLine(initInt(WRITE), "write");
	reserved.addLine(initInt(RETURN), "return");
	
	std::string sp = ",;+-/*<>()[]{}:=";
	std::string ig = " \n\t";

	for (auto e : sp)
	{
		separators[e] = 1;
	}
	for (auto e : ig)
	{
		ignores[e] = 1;
	}

	line_separator = '\n';

}

Program<int> *Parser::read_file(std::string file)
{
	int line_count = 0;

	try 
	{


		std::ifstream f(file);
		if (!f.good()) throw(1);


		Program<int>* ans = new Program<int>;

		std::stack<Argument*> thread;
		Trie<Variable*> vars;

		bool flag = 1;

		while (f.good()&& flag)
		{
			std::string a = get_next_token(f,line_count);
			char sep = a.back();
			a.pop_back();
			std::cout << a << ' ' << sep << '\n';
			if (sep == ':')
			{
				int rezVal = reserved.getLine(a).val;
				switch (rezVal)
				{
				case 0:
					throw(2);
					break;
				case ADDINT:
				case ADDSTRING:
				case ADDFLOAT:
					read_var(ans, f, line_count, rezVal, vars, thread);
					break;
				case WRITE:
					read_write(ans, f, line_count, vars, thread);
					break;
				case RETURN:
					read_return(ans, f, line_count, thread);
					flag=0;
					break;
				default:
					throw(-1);
				}
			}
			else throw(-1);
		}
		//Write* arg = new Write(exp);
		//ans->add_argument(arg);

		return ans;
	}
	catch(int err)
	{
		switch (err)
		{
		case 1:
			std::cout << "Could not open file. Error code : " << err << "\n";
			break;
		case 2:
			std::cout << "Could not find argument at line "<< line_count<<". Error code : " << err << "\n";
			break;
		case 3:
			std::cout << "Missing semicolon on line " << line_count << ". Error code : "<< err << "\n";
			break;
		default:
			std::cout << "An unhandled exception occured. Error code : "<<err<<"\n";
			break;
		}
	}
	return nullptr;
}

Expression* Parser::read_expression(Program<int>* p,std::ifstream &f, int &line_count)
{
	std::stack<Expression*> expr;
	expr.push(new Expression);
	
	std::string a="error";
	bool eoe = 0;  //end of expression

	while (!eoe)
	{
		a = get_next_token(f,line_count);

		char sep = a.back();
		a.pop_back();

		if (!a.empty())
		{
			if ('0' <= a[0] && a[0] <= '9')
			{
				Variable* var = new Int(std::stoi(a));
				Expression* ex = new Expression(var);
				p->add_expression(ex);
				p->add_variable(var);
				expr.top()->push_back_mem(ex);
			}
		}
		Expression* ex;
		switch (sep)
		{
		case '(':
			ex = new Expression;
			p->add_expression(ex);
			expr.top()->push_back_mem(ex);
			expr.push(ex);
			break;
		case ')':
			expr.pop();
			break;
		case '*':
		case '/':
		case '-':
		case '+':
			expr.top()->push_back_oper(Operand(sep));
			break;
		case ';':
			eoe = 1;
			break;
		}
	}
	//Argument* show = new Write(expr.top());
	//ans->add_argument(show);
	p->add_expression(expr.top());
	return expr.top();
}

void Parser::read_write(Program<int>* p, std::ifstream& f, int& line_count, Trie<Variable*>& vars, std::stack<Argument*> &thread)
{
	std::string name;
	char eq;
	name = get_next_token(f, line_count);
	eq = name.back();
	name.pop_back();
	if (eq != ';') throw(3);
	Variable* var = vars.getLine(name);
	Expression* exp = new Expression(var);

	p->add_expression(exp);


	Write* arg = new Write(exp);

	if (!thread.empty()) thread.top()->set_next(arg);
	thread.push(arg);
	p->add_argument(arg);
}

void Parser::read_return(Program<int>* p, std::ifstream& f, int& line_count, std::stack<Argument*> &thread)
{
	Expression* exp = read_expression(p, f, line_count);

	p->add_expression(exp);

	Return* arg = new Return();
	arg->set_value(exp);

	if (!thread.empty()) thread.top()->set_next(arg);
	thread.push(arg);
	p->add_argument(arg);
}

void Parser::read_var(Program<int>* p, std::ifstream& f, int& line_count, int var_type, Trie<Variable*> &vars, std::stack<Argument*> &thread) 
{
	Variable* var;
	std::string name;
	char eq;
	switch (var_type)
	{
	case ADDINT:
		var = new Int;
		break;
	case ADDSTRING:
		var = new String;
		break;
	case ADDFLOAT:
		var = new Float;
	default:
		var = new Variable;
		break;
	}
	p->add_variable(var);

	name = get_next_token(f, line_count);
	eq = name.back();
	name.pop_back();

	vars.addLine(var, name);

	if (eq == '=')
	{
		Expression* exp = read_expression(p, f, line_count);
		SetVar* arg = new SetVar;
		arg->set_target(var);
		arg->set_assign(exp);

		if (!thread.empty()) thread.top()->set_next(arg);

		thread.push(arg);
		p->add_argument(arg);
	}
	else if (eq != ';')
	{
		throw(3);
	}
	return;
}

std::string Parser::get_next_token(std::ifstream &f,int &line_count)
{
	std::string ans;
	char c;
	while (f.get(c))
	{
		if (c == line_separator) line_count++;
		if(ignores[c]==0) ans.push_back(c);
		if (separators[c] == 1) break;
	}

	return ans;
}
