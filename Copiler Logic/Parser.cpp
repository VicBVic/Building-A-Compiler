#include "Parser.h"
#include <vector>
#include <fstream>
#include <iostream>

std::ifstream in("main.tmp");
std::ofstream out("tokens.log");

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
				if (token != "")tokens.push_back(token);
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
				if (token != "")tokens.push_back(token);
				tokens.push_back(std::string(1, c));
				token = "";
				break;
			default:
				token.push_back(c);
				break;
			}
		}
		if (token != "")tokens.push_back(token);
	}
	in.close();
	for (auto token : tokens)out << token << "|\n";
	out.close();
	return tokens;
}

