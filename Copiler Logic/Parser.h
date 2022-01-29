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
	Expression* read_expression(Program<int>* p, std::ifstream &f, int &line_count);
	void read_var(Program<int>* p, std::ifstream& g, int& line_count, int var_type, Trie<Variable*> &vars, std::stack<Argument*> &thread);
	void read_write(Program<int>* p, std::ifstream& f, int& line_count, Trie<Variable*>& vars, std::stack<Argument*> &thread); // REALLY dont ask
	void read_return(Program<int>* p, std::ifstream& f, int& line_count, std::stack<Argument*> &thread);
	std::string get_next_token(std::ifstream &f,int &line_count);

	Trie<initInt> reserved;
	std::unordered_map<char, bool> separators;
	std::unordered_map<char, bool> ignores;
	char line_separator;

	enum {
		ADDINT=1,
		ADDSTRING=2,
		ADDFLOAT=3,
		WRITE=4,
		RETURN=5,
		SET=6
	};

};

