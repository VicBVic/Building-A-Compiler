#include <iostream>
#include <vector>
#include <string>
#include "Expression.h"
#include "Operand.h"
#include "Program.h"
#include "Return.h"
#include "String.h"
#include "Int.h"
#include "Float.h"
#include "Read.h"
#include "Write.h"
#include "Parser.h"
#include "Variable.h"

int main()
{
	/*Int* a = new Int(5);
	Int* b = new Int(5);
	Expression* exp = new Expression(a);
	Expression* mult = new Expression(b);
	Expression* encap = new Expression();
	encap->push_back(exp, Operand('*'));
	encap->push_back(mult);
	Read* r = new Read(a);
	Write* w = new Write(encap);
	Return* ret = new Return;
	ret->set_value(new Expression(new Int(0)));
	r->set_next(w);
	w->set_next(ret);
	Program<Int>* p = new Program<Int>;
	p->add_argument(r);
	p->add_argument(w);
	p->add_argument(ret);
	p->add_variable(a);
	p->add_variable(b);

	p->add_expression(encap);
	p->add_expression(mult);
	p->add_expression(exp);
	Expression* pex = p;
	Variable *ans=pex->evaluate();
	delete ans;
	return 0;*/
	std::string path = "C:/Users/0Botn/OneDrive/Desktop/main.rv";

	Parser *p = new Parser();
	p->read_file(path)->evaluate();
	delete p;
	system("pause");
	return 0;
}