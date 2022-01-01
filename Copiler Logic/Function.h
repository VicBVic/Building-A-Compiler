#pragma once
#include <string>
//#include "Trie.h"
#include "Argument.h"
class Function
{
private:
	std::string params[(int)1e5];
	//Trie *local;
	//Trie *global;
	//Function(Trie &global);
	Argument *start;
public:
	bool chageParams();
	void Start();
};
