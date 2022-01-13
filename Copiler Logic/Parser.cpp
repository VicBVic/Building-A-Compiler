#include "Parser.h"
#include <vector>
#include <fstream>

std::ifstream in("main.tmp");

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
				tokens.push_back(token);
				tokens.push_back(std::string(1, c));
				token = "";
				break;
			default:
				token.push_back(c);
				break;
			}
		}
	}
	return tokens;
}

