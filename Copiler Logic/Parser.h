#pragma once
#include <vector>
#include <string>
#include <stack>
#include <fstream>
#include <unordered_map>
#include "Program.h"
#include "Trie.h"

class Parser
{
public:
	Parser();
	Program<int>* read_file(std::string file);
	enum {
		DEFINT = 1,
		DEFSTRING = 2,
		DEFFLOAT = 3,
		WRITE = 4,
		RETURN = 5,
		SET = 6
	};
	enum class error {
		CANT_OPEN,
		MISSING_SEMICOLON,
		UNDEF_ARG,
		MISSING_PARAN,
		MISSING_TEXT = 666,
		UNDEF_SYM,
		UNDEF_DECLARE,
		MISSING_SYM,
	};
private:
	struct initInt {
		int val = 0;
		initInt(int val)
		{
			this->val = val;
		}
		initInt()
		{
			val = 0;
		}
	};
	//dont ask please
	Expression* read_expression(Program<int>* p, std::ifstream &f, int &line_count, Trie<Variable*>& vars);
	void read_var(Program<int>* p, std::ifstream& g, int& line_count, int var_type, Trie<Variable*> &vars, std::stack<Argument*> &thread);
	void read_write(Program<int>* p, std::ifstream& f, int& line_count, Trie<Variable*>& vars, std::stack<Argument*> &thread); // REALLY dont ask
	void read_return(Program<int>* p, std::ifstream& f, int& line_count,Trie<Variable*> &vars, std::stack<Argument*> &thread);
	void give_error_message(error error, int line_count);
	std::string get_next_token(std::ifstream &f,int &line_count);

	Trie<initInt> reserved;
	std::unordered_map<char, bool> separators;
	std::unordered_map<char, bool> ignores;
	char line_separator;

};

