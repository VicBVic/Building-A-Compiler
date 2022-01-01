#pragma once
#include <string>
#include "DataType.h"

class Trie
{
private:
	Trie *next[128];
	Trie();
public:
	bool add(std::string &name, int pos, DataType &type);
	DataType *get(std::string &name, int pos);
	DataType *type;
};

