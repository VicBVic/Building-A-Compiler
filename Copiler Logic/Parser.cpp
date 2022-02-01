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

	reserved.addLine(initInt(DEFINT), "int");
	reserved.addLine(initInt(DEFSTRING), "string");
	reserved.addLine(initInt(DEFFLOAT), "float");
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
	Program<int>* ans = new Program<int>;
	try 
	{


		std::ifstream f(file);
		if (!f.good()) throw(error::CANT_OPEN);


		

		std::stack<Argument*> thread;
		Trie<Variable*> vars;

		bool flag = 1;

		while (f.good()&& flag)
		{
			std::string a = get_next_token(f,line_count);
			char sep = a.back();
			a.pop_back();
			//std::cout << a << ' ' << sep << '\n';
			if (sep == ':')
			{
				int rezVal = reserved.getLine(a).val;
				switch (rezVal)
				{
				case 0:
					throw(error::UNDEF_ARG);
					break;
				case DEFINT:
				case DEFSTRING:
				case DEFFLOAT:
					read_var(ans, f, line_count, rezVal, vars, thread);
					break;
				case WRITE:
					read_write(ans, f, line_count, vars, thread);
					break;
				case RETURN:
					read_return(ans, f, line_count, vars, thread);
					flag=0;
					break;
				default:
					throw(error::UNDEF_ARG);
				}
			}
			else throw(error::UNDEF_SYM);
		}
		//Write* arg = new Write(exp);
		//ans->add_argument(arg);

		return ans;
	}
	catch (error err)
	{
		delete ans;
		give_error_message(err, line_count);
	}
	return nullptr;
}

Expression* Parser::read_expression(Program<int>* p,std::ifstream &f, int &line_count, Trie<Variable*>& vars)
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
			else
			{
				Variable* var = vars.getLine(a);
				Expression* ex = new Expression(var);
				p->add_expression(ex);
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
			if (expr.empty()) throw(error::MISSING_PARAN);
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
		default:
			throw(error::UNDEF_SYM);
		}
	}
	//Argument* show = new Write(expr.top());
	//ans->add_argument(show);

	if (expr.size() != 1) throw(error::MISSING_PARAN);

	p->add_expression(expr.top());
	return expr.top();
}

void Parser::read_write(Program<int>* p, std::ifstream& f, int& line_count, Trie<Variable*>& vars, std::stack<Argument*> &thread)
{
	Expression* exp = read_expression(p,f,line_count,vars);

	p->add_expression(exp);


	Write* arg = new Write(exp);

	if (!thread.empty()) thread.top()->set_next(arg);
	thread.push(arg);
	p->add_argument(arg);
}

void Parser::read_return(Program<int>* p, std::ifstream& f, int& line_count, Trie<Variable*> &vars, std::stack<Argument*> &thread)
{
	Expression* exp = read_expression(p, f, line_count, vars);

	p->add_expression(exp);

	Return* arg = new Return();
	arg->set_value(exp);

	if (!thread.empty()) thread.top()->set_next(arg);
	thread.push(arg);
	p->add_argument(arg);
}

void Parser::give_error_message(error error, int line_count)
{

		switch (error)
		{
		case error::CANT_OPEN:
			std::cout << "Could not open file. Error code : " << (int)(error) << "\n";
			break;
		case error::UNDEF_ARG:
			std::cout << "Could not	identify argument at line " << line_count << ". Error code : " << (int)(error) << "\n";
			break;
		case error::UNDEF_SYM:
			std::cout << "Could not	identify symbol at line " << line_count << ". Error code : " << (int)(error) << "\n";
			break;
		case error::MISSING_SEMICOLON:
			std::cout << "Missing semicolon on line " << line_count << ". Error code : " << (int)(error) << "\n";
			break;
		case error::MISSING_PARAN:
			std::cout << "Missing pharanthesis on line " << line_count << ". Error code : " << (int)(error) << "\n";
			break;
		default:
			std::cout << "An unhandled exception occured. Error code : " << (int)(error) << "\n";
			break;
		}
}

void Parser::read_var(Program<int>* p, std::ifstream& f, int& line_count, int var_type, Trie<Variable*> &vars, std::stack<Argument*> &thread) 
{
	Variable* var;
	std::string name;
	char eq;
	switch (var_type)
	{
	case DEFINT:
		var = new Int;
		break;
	case DEFSTRING:
		var = new String;
		break;
	case DEFFLOAT:
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
		Expression* exp = read_expression(p, f, line_count, vars);
		SetVar* arg = new SetVar;
		arg->set_target(var);
		arg->set_assign(exp);

		if (!thread.empty()) thread.top()->set_next(arg);

		thread.push(arg);
		p->add_argument(arg);
	}
	else if (eq != ';')
	{
		throw(error::MISSING_SEMICOLON);
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
	if (ans.size() == 0) throw(error::MISSING_TEXT);
	return ans;
}
