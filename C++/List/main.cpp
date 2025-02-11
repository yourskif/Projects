#include <iostream>
#include "list.h"

using namespace std;

int main() {
    Itemptr head = nullptr;
    char choice;
    bool done = false;

    cout << "LINKED LIST DEMONSTRATION\n";
    cout << "Menu:\n"
        << "A - Add element\n"
        << "S - Show list\n"
        << "D - Delete first element\n"
        << "Q - Quit\n";

    while (!done) {
        cout << "\nYour choice: ";
        cin >> choice;
        choice = toupper(choice);

        switch (choice) {
        case 'A':
            Add(head);
            break;
        case 'S':
            Show(head);
            break;
        case 'D':
            Delete(head);
            break;
        case 'Q':
            done = true;
            break;
        default:
            cout << "Invalid choice! Try again.\n";
        }
    }

    // Очищення пам'яті перед виходом
    while (head != nullptr) {
        Delete(head);
    }

    cout << "Program exited.\n";
    return 0;
}
