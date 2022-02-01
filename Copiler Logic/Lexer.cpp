#include "Lexer.h"
#include <iostream>
Lexer::Lexer()
{
	std::string whit = " \n";
	std::string sp = ",;+-/*<>()[]{}:=%";
	reserved->addLine(DEFINT, "int");
	reserved->addLine(DEFSTRING, "string");
	reserved->addLine(DEFFLOAT, "float");
	reserved->addLine(WRITE, "write");
	reserved->addLine(RETURN, "return");
	reserved->addLine(IF, "if");
	reserved->addLine(WHILE, "while");
	reserved->addLine(ELSE, "else");

	for (auto e : sp)
	{
		sep[e] = 1;
	}
	for (auto e : whit)
	{
		white[e] = 1;
	}
}

std::string Lexer::lex_file(std::ifstream& f)
{
	std::string ans;
	try
	{
		while (f.good())
		{
			//std::cout << "here" << '\n';
			ans.append(interpret_reserved(get_next_token(f), f));
		}
		return ans;
	}
	catch (error err)
	{
		std::cout << (int)(err) << " or something idk at line " <<lineCount <<"\n";
	}
	return "";
}

std::string Lexer::get_next_token(std::ifstream& f, bool ignore_white)
{
	std::string ans=""; char c;
	while (f.get(c))
	{
		if (c == '\n') lineCount++;
		if (white[c] != 1)
		{
			ans.push_back(c);
			break;
		}
	}
	if (sep[c] == 1) return ans;
	bool seeking_sym=0;
	
	while (f.get(c))
	{
		if (c == '\n') lineCount++;
		if (white[c])
		{
			if(!seeking_sym&&ignore_white) seeking_sym = 1;
			if (!ignore_white)
			{
				ans.push_back(c);
				return ans;
			}
		}
		else
		{
			ans.push_back(c);
			if (seeking_sym && !sep[c]) throw(error::MISSING_SYM);
		}
		if (sep[c]) return ans;
	}
	return "";
}
std::string Lexer::interpret_reserved(std::string name, std::ifstream& f)
{
	std::string ans;
	char sp=' ';
	if (!name.empty())
	{
		sp = name.back();
		name.pop_back();
	}
	if (name.empty())
	{
		//throw(error::UNDEF_ARG);
		if (sp == '}')  return "}";
		else if (sp == '{') return "{";
		else return "";
	}
	int res = reserved->getLine(name);

	if (res == -1)
	{
		if (sp != '=') throw(error::UNDEF_ARG);
		ans.append(interpret_var(name, f));
	}
	if (res == DEFINT || res == DEFSTRING || res == DEFFLOAT)
	{
		if (sp != ' ') throw(error::UNDEF_SYM);
		ans.append(interpret_declare(res, f));
	}
	if (res == WRITE)
	{
		ans.append(interpret_write(f));
	}
	if (res == RETURN)
	{
		ans.append(interpret_return(f));
	}
	if (res == IF)
	{
		if (sp == '(') ans.append(interpret_if(f, 1));
		else if (white[sp]) ans.append(interpret_if(f));
		else throw(error::UNDEF_SYM);
	}
	if (res == WHILE)
	{
		if (sp == '(') ans.append(interpret_while(f, 1));
		else if (white[sp]) ans.append(interpret_while(f));
		else throw(error::UNDEF_SYM);
	}
	if (res == ELSE)
	{
		if (sp == '{') ans.append(interpret_else(f, 1));
		else if (white[sp]) ans.append(interpret_else(f));
		else throw(error::UNDEF_SYM);
	}
	return ans;
}

std::string Lexer::interpret_var(std::string name, std::ifstream& f)
{
	std::string ans;
	if (vars->getLine(name) == -1) throw(error::UNDEF_VAR);
	ans.push_back('=');
	ans.append(std::to_string(vars->getLine(name)));
	ans.push_back('#');
	ans.append(interpret_expression(f));
	if (ans.back() != ';') throw(error::MISSING_SEMICOLON);
	return ans;
}

std::string Lexer::interpret_declare(int type, std::ifstream& f)
{
	std::string ans;
	char sp;
	std::string varName = get_next_token(f,1);
	
	
	bool cont = 1;
	
	while (cont)
	{
		sp = varName.back();
		varName.pop_back();
		if (varName.empty()) throw(error::UNDEF_DECLARE);
		if ('0' <= varName[0]&& varName[0] <= '9') throw(error::UNDEF_DECLARE);
		if (vars->getLine(varName) != -1) throw(error::REDECLARE);
		switch (type)
		{
		case DEFINT:
			ans.push_back('i');
			break;
		case DEFSTRING:
			ans.push_back('s');
			break;
		case DEFFLOAT:
			ans.push_back('f');
			break;
		}
		
		vars->addLine(varCount,varName);
		ans.append(std::to_string(varCount));
		ans.push_back('#');
		
		varCount++;


		if (sp == '=')
		{
			ans.push_back('=');
			std::string exp = interpret_expression(f);
			sp = exp.back();
			exp.pop_back();
			ans.append(exp);
			
		}
		ans.append(";");
		if (sp == ';') cont = 0;
		else if (sp != ',') throw(error::UNDEF_SYM);
		else
		{
			varName.clear();
			varName.append(get_next_token(f, 1));
		}
	}
	return ans;
}

std::string Lexer::interpret_write(std::ifstream& f)
{
	std::string ans;
	ans.push_back('w');
	ans.append(interpret_expression(f));
	if (ans.back() != ';') throw(error::MISSING_SEMICOLON);
	return ans;
}

std::string Lexer::interpret_return(std::ifstream& f)
{
	std::string ans;
	ans.push_back('>');
	ans.append(interpret_expression(f));
	if(ans.back()!= ';') throw(error::MISSING_SEMICOLON);
	return ans;
}

std::string Lexer::interpret_expression(std::ifstream& f, int level)
{
	bool ok = 1;
	std::string ans, a;
	ans.push_back('[');
	for (int i = 1; i < level; i++) ans.push_back('(');
	char sp;
	while (f.good())
	{
		a = get_next_token(f,1);
		sp = a.back();
		a.pop_back();
		if (!a.empty())
		{
			if ('0' <= a[0] && a[0] <= '9')
			{
				for (auto e : a)
				{
					if (e < '0' || e>'9') throw(error::UNDEF_DECLARE);
				}
				ans.append(a);
				ans.push_back('&');
			}
			else if (a[0] == '"')
			{
				if (a.back() != '"') throw(error::UNDEF_SYM);
				ans.append(a);
			}
			else
			{
				int nr = vars->getLine(a);
				if (nr == -1) throw(error::UNDEF_VAR);

				ans.append(std::to_string(nr));
				ans.push_back('#');
			}
		}


		if (sep[sp] != 1) throw(error::UNDEF_SYM);
		ans.push_back(sp);
		//needs some more work
		if (sp == '(') level++;
		if (sp==')') level--;
		if (sp == ',' || sp == ';' || sp == '{')
		{
			if (level == 1) break;
			else throw(error::MISSING_PARAN);
		}
	}

	sp = ans.back(); ans.pop_back();
	ans.push_back(']');
	ans.push_back(sp);
	return ans;
}

std::string Lexer::interpret_if(std::ifstream& f,bool read_paran)
{
	std::string ans;
	ans.push_back('?');
	ans.append(interpret_expression(f,1 + read_paran));
	return ans;
}

std::string Lexer::interpret_else(std::ifstream& f, bool read_curl)
{
	std::string ans;
	ans.push_back(':');
	if (read_curl) ans.push_back('{');
	return ans;
}

std::string Lexer::interpret_while(std::ifstream& f, bool read_paran)
{
	std::string ans;
	ans.push_back('O');
	ans.append(interpret_expression(f, 1 + read_paran));
	return ans;
}
