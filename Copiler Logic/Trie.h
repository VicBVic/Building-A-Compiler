#pragma once

#include <string>
#include <map>
template <typename T> class Trie
{
public:
	Trie<T>()
	{
	}
	void addLine(T end, std::string line, int poz = 0)
	{
		if (poz == line.size())
		{
			//de adaugat o conditie aici(nu vrem sa rescriem variabile)
			this->end = end;
			return;
		}
		if (next.find(line[poz]) == next.end()) next[line[poz]] = new Trie<T>;
		next[line[poz]]->addLine(end, line, poz + 1);
		return;
	}


	//din nou, nicio verificare, nimic
	T getLine(std::string line, int poz = 0)
	{
		if (poz == line.size())
		{
			return this->end;
		}
		if (next.find(line[poz]) == next.end()) return end;
		return next[line[poz]]->getLine(line, poz + 1);
	}

private:
	std::map <char, Trie<T>* > next;
	T end;

};

