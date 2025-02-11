// classes.h
#ifndef _CLASSES_H_
#define _CLASSES_H_
#include <iostream>
using namespace std;

class Eksponat
{
//	static int n;					// текущее число Eksponat
	//static Eksponat* arrap[];		// массив указателей на класс Eksponat
protected:
	char *nazwa;
	int rik;
public: 
	Eksponat(char *snazwa="no one",int srik=0);
	Eksponat(const Eksponat&ob);
	virtual ~Eksponat();
	Eksponat&operator=(const Eksponat&ob);
	void operator()(char *,int);
//	virtual Eksponat& getInfo ();
//	char getInfor();
	virtual void getInfo();
	friend ostream& operator<<(ostream& out, Eksponat& x);
	virtual void set();
//	virtual void print() const;
	static void change();
	static void nazwasort();
	static void nameorder(Eksponat**,Eksponat**);
};

class Moneta : public Eksponat
{
	char *kraina;
	int nominal;
public:
	Moneta(char *snazwa="no one",int srik=0,char *skraina="no one",int snominal=0);
	Moneta(Eksponat&ob,char *skraina,int snominal);
	Moneta(const Moneta&ob );
	Moneta&operator=(const Moneta&ob);
//	virtual Moneta& getInfo ();
	virtual void getInfo();
	Eksponat& getInfor();
	void operator()(char *,int );
	friend ostream& operator<<(ostream& out, Moneta& x);
//	virtual void print() const;
	virtual void set();
	virtual ~Moneta();
};
//
class Kartuna : public Eksponat
{
	char *xudognik;
	int vartist;
public:
	Kartuna(char *snazwa="no one",int srik=0,char *sxudognik="no one",int svartist=0);
	Kartuna(Eksponat&ob,char *sxudognik,int svartist);
	Kartuna(const Kartuna&ob);
	Kartuna&operator=(const Kartuna&ob);
//	virtual Kartuna& getInfo ();
	virtual void getInfo();
	void operator()(char *,int );
	friend ostream& operator<<(ostream& out, Kartuna& x);
//	virtual void print()const;
	virtual void set();
	virtual ~Kartuna();
};

//int Eksponat::n;                  // текущее число 

#endif
