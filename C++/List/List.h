#ifndef LIST_H
#define LIST_H

#include <iostream>

struct Item {
    int data;
    Item* next;
};

typedef Item* Itemptr;

void Add(Itemptr& head);
void Show(Itemptr head);
void Delete(Itemptr& head);

#endif // LIST_H
