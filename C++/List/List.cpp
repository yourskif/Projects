#include "list.h"
using namespace std;

// Додавання елемента в список
void Add(Itemptr& head) {
    int value;
    cout << "Enter data: ";
    cin >> value;

    Itemptr newItem = new Item;
    newItem->data = value;
    newItem->next = head;
    head = newItem;
}

// Відображення списку
void Show(Itemptr head) {
    if (head == nullptr) {
        cout << "List is empty!\n";
        return;
    }

    cout << "List contents:\n";
    Itemptr temp = head;
    while (temp != nullptr) {
        cout << temp->data << " -> ";
        temp = temp->next;
    }
    cout << "NULL\n";
}

// Видалення першого елемента зі списку
void Delete(Itemptr& head) {
    if (head == nullptr) {
        cout << "List is empty. Nothing to delete!\n";
        return;
    }

    Itemptr temp = head;
    head = head->next;
    delete temp;

    cout << "First element deleted.\n";
}
