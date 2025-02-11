/*
Завдання:
Дано масив розміром K-2, який містить різні цілі числа в діапазоні більше 0 та менше K+1.
У масиві відсутні два послідовні числа. Напишіть програму для знаходження цих чисел.

Приклад 1:
K=20, arr[] = {5, 7, 6, 4, 20, 3, 8, 11, 18, 17, 13, 1, 9, 2, 19, 14, 10, 12}
Пропущені числа: 15 та 16.

Приклад 2:
K=5, arr[] = {1, 5, 2}
Пропущені числа: 3 та 4.

Рішення:
1) Використання сортування вибором (`SortChoice`) для впорядкування масиву.
2) Пошук відсутніх чисел шляхом перевірки послідовності (`FindNumber`).
*/

#include <iostream>
#include <cstdlib>
#include <ctime>
#include <windows.h>

using namespace std;

const int K = 20;

// Функція для знаходження відсутніх чисел
void FindNumber(int arr[], int size) {
    int key = 1;
    for (int i = 0; i < size;) {
        if (arr[i] == key) {
            key++;
            i++;
        }
        else {
            cout << "Пропущене число: " << key << endl;
            key++;
        }
    }
}

// Сортування вибором (Selection Sort)
void SortChoice(int arr[], int size) {
    int ind, min;
    for (int i = 0; i < size; i++) {
        ind = i;
        min = arr[i];

        for (int j = i + 1; j < size; j++) {
            if (arr[j] < min) {
                ind = j;
                min = arr[j];
            }
        }
        swap(arr[ind], arr[i]);
    }
}

int main() {
    // Виправлення кодування консолі для коректного виводу кирилиці
    setlocale(LC_ALL, "ru");

    srand(time(NULL));

    int arr[] = { 5, 7, 6, 4, 20, 3, 8, 11, 18, 17, 13, 1, 9, 2, 19, 14, 10, 12 };
    const int size = sizeof(arr) / sizeof(arr[0]);

    cout << "Початковий масив:" << endl;
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    cout << "Сортування..." << endl;
    SortChoice(arr, size);

    cout << "Відсортований масив:" << endl;
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    cout << "Пошук пропущених чисел:" << endl;
    FindNumber(arr, size);

    return 0;
}
