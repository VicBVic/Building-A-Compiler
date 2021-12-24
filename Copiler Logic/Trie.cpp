#include "Trie.h"

Trie::Trie() {
	this->type = nullptr;
	for (int i = 0; i < 128; i++)next[i] = nullptr;
}

bool Trie::add(std::string &name, int pos, DataType &type) {
	
	if (name.size() - 1 == pos) {

		if (this->type != nullptr)return 0;//daca variabila exista deja

		this->type = &type;
		return 1;

	}

	if (next[name[pos]] == nullptr)next[name[pos]] = new Trie();
	return next[name[pos]]->add(name, pos + 1, type);

}

DataType *Trie::get(std::string& name, int pos) {

	if (name.size() - 1 == pos) {

		if (this->type != nullptr)return nullptr;

		return this->type;

	}

	if (next[name[pos]] == nullptr)next[name[pos]] = new Trie();
	return next[name[pos]]->get(name, pos + 1);

}