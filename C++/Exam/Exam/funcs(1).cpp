#include <iostream>
#include <cstring>
#include "classes.h"
using namespace std;

// Eksponat ---------------------------------------------------------
Eksponat::Eksponat(char *snazwa,int srik)
{
	nazwa=new char[strlen(snazwa)+1];
	if (!nazwa){cout<<"Misstake memory";exit(0);}
	strcpy(nazwa,snazwa);
	nazwa[strlen(nazwa)]='\0';
	rik=srik;
}

Eksponat::Eksponat(const Eksponat&ob)
{
	nazwa=new char[strlen(nazwa)+1];
	if (!nazwa){cout<<"Misstake memory";exit(0);}
	strcpy(nazwa,ob.nazwa);
	nazwa[strlen(nazwa)]='\0';
	rik=ob.rik;
}

Eksponat&Eksponat::operator=(const Eksponat&ob)
{
 if (this==&ob)
	 return *this;
 if(nazwa)
	 delete [] nazwa;
if (!nazwa){cout<<"Misstake memory";exit(0);}
	strcpy(nazwa,ob.nazwa);
	nazwa[strlen(nazwa)]='\0';
	rik=ob.rik;
	return *this;
}

void Eksponat::operator()(char *snazwa,int srik)
{
	nazwa=new char[strlen(snazwa)+1];
	if (!nazwa){cout<<"Misstake memory";exit(0);}
	strcpy(nazwa,snazwa);
	nazwa[strlen(nazwa)]='\0';
	rik=srik;
}

void Eksponat::set()
{
	char temp[20];
	cout<<"input nazwu i rik"<<endl;
	cin.getline(temp,20);
	while(cin.get()!='\n')
		continue;
	nazwa=new char[strlen(temp)+1];
	if(!nazwa){cout<<"mistake memory\n";exit(0);}
	strcpy(nazwa,temp);
	nazwa[strlen(nazwa)]='\0';
	cin>>rik;
	//while(cin.get() != '\n')
	//	continue;
}


//Eksponat&Eksponat::getInfo ()
void Eksponat::getInfo()
{
	cout<<"\nNazwa:"<<nazwa<<" "<<"rik= "<<rik<<endl;
// return *this; 
}
//char Eksponat::getInfor()
//{
////	cout<<"\nNazwa:"<<nazwa<<" "<<"rik= "<<rik<<endl;
// return *this; 
//// return *nazwa;
//}



Eksponat::~Eksponat()
{
	delete [] nazwa;
}

ostream& operator<<(ostream&out, Eksponat& x){
	cout<<"\nNazwa:"<<x.nazwa<<" "<<"Rik= "<<x.rik<<endl;
	return out;
}

//void Eksponat::print()
//{
//	cout<<"\nNazwa:"<<nazwa<<" "<<"rik= "<<rik<<endl;
//}


// Moneta -----------------------------------------------------------
Moneta::Moneta(char *snazwa,int srik,char *skraina,int snominal):Eksponat(snazwa,srik)
{
	kraina=new char[strlen(skraina)+1];
	if (!kraina){cout<<"Misstake memory";exit(0);}
	strcpy(kraina,skraina);
	nazwa[strlen(kraina)]='\0';
	nominal=snominal;
}

Moneta::Moneta(Eksponat&ob,char *skraina,int snominal):Eksponat(ob)
{
	kraina=new char[strlen(skraina)+1];
	strcpy(kraina,skraina);
	kraina[strlen(kraina)]='\0';
	nominal=snominal;
}

Moneta::Moneta(const Moneta&ob):Eksponat(ob)
{
	kraina=new char[strlen(ob.kraina)+1];
	if (!kraina){cout<<"Misstake memory";}
	strcpy(kraina,ob.kraina);
	kraina[strlen(ob.kraina)]='\0';
	nominal=ob.nominal;
}

Moneta& Moneta::operator = (const Moneta& ob)
{
 if (this==&ob)
	 return *this;
 if(nazwa)
	 delete [] kraina;
if (!kraina){cout<<"Misstake memory";exit(0);}
	kraina=new char[strlen(ob.kraina)+1];
	strcpy(kraina,ob.kraina);
	kraina[strlen(ob.kraina)]='\0';
	nominal=ob.nominal;
	return *this;
}

void Moneta::operator()(char *skraina,int snominal)
{
	kraina=new char[strlen(skraina)+1];
	if (!kraina){cout<<"Misstake memory";exit(0);}
	strcpy(kraina,skraina);
	nazwa[strlen(kraina)]='\0';
	nominal=snominal;
}

//Moneta&Moneta::getInfo ()
void Moneta::getInfo()
{
	cout<<"\nKraina:"<<kraina<<" "<<"nominal= "<<nominal<<endl;
// return *this; 
}

void Moneta::set()
{
	char temp[20];
	cout<<"input krainu i nominal"<<endl;
	cin.getline(temp,20);
	while(cin.get()!='\n')
		continue;
	kraina=new char[strlen(temp)+1];
	if(!kraina){cout<<"mistake memory\n";exit(0);}
	strcpy(kraina,temp);
	nazwa[strlen(kraina)]='\0';
	cin>>nominal;
	while(cin.get() != '\n')
		continue;
}

Moneta::~Moneta()
{
	delete [] kraina;
}

ostream& operator<<(ostream& out, Moneta& x){
	out<<"\nNazwa:"<<x.nazwa<<" "<<"rik:"<<x.rik<<" "<<"Kraina:"<<x.kraina<<" "<<"nominal= "<<x.nominal<<endl;
	return out;
}

//void Moneta::print()
//{
//	cout<<"\nKraina:"<<kraina<<" "<<"nominal= "<<nominal<<endl;
//}


//=============================================================================
// Kartuna -----------------------------------------------------------
Kartuna::Kartuna(char *snazwa,int srik,char *sxudognik,int svartist):Eksponat(snazwa,srik)
{
	xudognik=new char[strlen(sxudognik)+1];
	if (!xudognik){cout<<"Misstake memory";exit(0);}
	strcpy(xudognik,sxudognik);
	nazwa[strlen(xudognik)]='\0';
	vartist=svartist;
}

Kartuna::Kartuna(Eksponat&ob,char *sxudognik,int svartist):Eksponat(ob)
{
	xudognik=new char[strlen(sxudognik)+1];
	strcpy(xudognik,sxudognik);
	xudognik[strlen(xudognik)]='\0';
	vartist=svartist;
}

Kartuna::Kartuna(const Kartuna&ob):Eksponat(ob)
{
	xudognik=new char[strlen(ob.xudognik)+1];
	if (!xudognik){cout<<"Misstake memory";}
	strcpy(xudognik,ob.xudognik);
	xudognik[strlen(ob.xudognik)]='\0';
	vartist=ob.vartist;
}

Kartuna& Kartuna::operator = (const Kartuna& ob)
{
 if (this==&ob)
	 return *this;
 if(xudognik)
	 delete [] xudognik;
if (!xudognik){cout<<"Misstake memory";exit(0);}
	xudognik=new char[strlen(ob.xudognik)+1];
	strcpy(xudognik,ob.xudognik);
	xudognik[strlen(ob.xudognik)]='\0';
	vartist=ob.vartist;
	return *this;
}

void Kartuna::operator()(char *sxudognik,int svartist)
{
	xudognik=new char[strlen(sxudognik)+1];
	if (!xudognik){cout<<"Misstake memory";exit(0);}
	strcpy(xudognik,sxudognik);
	xudognik[strlen(xudognik)]='\0';
	vartist=svartist;
}

//Kartuna&Kartuna::getInfo ()
void Kartuna::getInfo()
{
	cout<<"\nXudognik:"<<xudognik<<" "<<"vartist= "<<vartist<<endl;
// return *this; 
}
void Kartuna::set()
{
	char temp[20];
	cout<<"input xudognika i vartist"<<endl;
	cin.getline(temp,20);
	while(cin.get()!='\n')
		continue;
	xudognik=new char[strlen(temp)+1];
	if(!xudognik){cout<<"mistake memory\n";exit(0);}
	strcpy(xudognik,temp);
	nazwa[strlen(xudognik)]='\0';
	cin>>vartist;
	while(cin.get() != '\n')
		continue;
}

Kartuna::~Kartuna()
{
	delete [] xudognik;
}

ostream& operator<<(ostream& out, Kartuna& x){
	out<<"\nNazwa:"<<x.nazwa<<" "<<"rik:"<<x.rik<<" "<<"Xudognik:"<<x.xudognik<<" "<<"vartist= "<<x.vartist<<endl;
	return out;
}

//void Kartuna::print()
//{
//	cout<<"\nKraina:"<<kraina<<" "<<"nominal= "<<nominal<<endl;
//}


////---------------------------------------------------------
////статические переменные
//int person::n;                  // текущее число 
//person* person::arrap[MAXLEN];  // массив указателей на
//                                // класс 
/////////////////////////////////////////////////////////////
////---------------------------------------------------------



