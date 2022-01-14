#include "Parser.h"
#include <vector>
#include <fstream>
#include <iostream>

std::ifstream in("main.tmp");
//std::ofstream out("hereyoudumbfuck");

std::vector<std::string> Parser::gettokens() {
	std::string line;
	std::vector<std::string> tokens;
	while (getline(in, line))
	{
		std::string token;
		bool s = 0;
		for (auto c : line) {
			switch (c)
			{
			case ' ':
			case '\t':
				tokens.push_back(token);
				token = "";
				break;
			case ';':
			case '{':
			case '}':
			case '(':
			case ')':
			case '+':
			case '-':
			case '/':
			case '*':
			case '%':
			case ',':
			case '^':
			case '&':
			case '|':
			case '=':
				tokens.push_back(std::string(1, c));
				tokens.push_back(token);
				token = "";
				break;
			default:
				token.push_back(c);
				break;
			}
		}
		tokens.push_back(token);
	}
	in.close();
	return tokens;
}

