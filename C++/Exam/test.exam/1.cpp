#include <iostream>
using namespace std;

class First
{
	int value;
public:
	First(int _value):value(_value){}
	First(void):value(0){}
	virtual int V(void){return value;}
};
class Second:public First
{
public:
	Second(int _value):First(_value){}
	Second(void):First(0){}
};

int main()
{
 First a(10);
 Second b(1),c(3);
 int x=a.V()+(b.V()*c.V());

 return 0;
}