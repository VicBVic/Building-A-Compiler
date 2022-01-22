#include "Parser.h"
#include "Int.h"
#include "Write.h"
#include <vector>
#include <string>
#include <fstream>
#include <iostream>
#include <stack>
Parser::Parser()
{
	//aici pui ce vrei sa rezervi

	reserved.addLine(initInt(1), "int");
	reserved.addLine(initInt(2), "string");
	reserved.addLine(initInt(3), "float");
	
	std::string sp = ",;+-/*<>()[]{}";
	std::string ig = " \n\t";

	for (auto e : sp)
	{
		separators[e] = 1;
	}
	for (auto e : ig)
	{
		ignores[e] = 1;
	}

}

Program<int> *Parser::read_file(std::string file)
{
	try 
	{
		std::ifstream f(file);
		if (!f.good()) throw(1);


		Program<int>* ans = new Program<int>;


		enum {
			EXPR,
			ARG,
			VAR
		};

		int readmode = EXPR;

		std::stack<Expression*> expr;
		expr.push(new Expression);

		std::string a="error";

		bool eoe = 0;  //end of expression

		while (!eoe)
		{
			a = get_next_token(f);

			char sep = a.back();
			a.pop_back();

			if (!a.empty())
			{
				if ('0' <= a[0]&& a[0] <= '9')
				{
					Variable* var = new Int(std::stoi(a));
					Expression* ex = new Expression(var);
					ans->add_expression(ex);
					ans->add_variable(var);
					expr.top()->push_back_mem(ex);
				}
			}
			Expression * ex;
			switch (sep)
			{
			case '(':
				ex = new Expression;
				ans->add_expression(ex);
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
		Argument* show = new Write(expr.top());

		ans->add_argument(show);

		return ans;


	}
	catch(int err)
	{
		switch (err)
		{
		case 1:
			std::cout << "could not open file. error code:1 \n";
			break;
		default:
			break;
		}
	}
	return nullptr;
}

std::string Parser::get_next_token(std::ifstream &f)
{
	std::string ans;
	char c;
	while (f.get(c))
	{
		if(ignores[c]==0) ans.push_back(c);
		if (separators[c] == 1) break;
	}

	return ans;
}
