#pragma once

#include <string>
#include <fstream>
#include <map>
#include "Trie.h"


class Lexer
{
public:
	Lexer();
	std::string lex_file(std::ifstream& f);
private:
	std::string get_next_token(std::ifstream& f,bool ignore_white=0);
	std::string interpret_reserved(std::string name,std::ifstream& f);
	std::string interpret_var(std::string name, std::ifstream& f);
	std::string interpret_declare(int type, std::ifstream& f);
	std::string interpret_write(std::ifstream &f);
	std::string interpret_return(std::ifstream& f);
	std::string interpret_expression(std::ifstream &f, int level = 1);
	std::string interpret_if(std::ifstream& f, bool read_paran=0);
	std::string interpret_else(std::ifstream& f, bool read_curl = 0);
	std::string interpret_while(std::ifstream& f, bool read_paran = 0);

	Trie<int> *reserved=new Trie<int>(-1);
	Trie<int>* vars = new Trie<int>(-1);
	int varCount = 0;
	int lineCount = 0;

	std::map<char, bool> white;
	std::map<char, bool> sep;
	enum {
		DEFINT = 1,
		DEFSTRING = 2,
		DEFFLOAT = 3,
		WRITE = 4,
		RETURN = 5,
		IF,
		WHILE,
		ELSE
	};
	enum class error {
		CANT_OPEN,
		MISSING_SEMICOLON,
		UNDEF_ARG,
		MISSING_PARAN,
		MISSING_TEXT,
		UNDEF_SYM,
		UNDEF_DECLARE,
		REDECLARE,
		UNDEF_VAR,
		MISSING_SYM,
	};
};

