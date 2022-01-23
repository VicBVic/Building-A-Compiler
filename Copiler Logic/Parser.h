#pragma once
#include <vector>
#include <string>
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

	std::string get_next_token(std::ifstream &f);
	Trie<initInt> reserved;
	std::unordered_map<char, bool> separators;
	std::unordered_map<char, bool> ignores;
};

