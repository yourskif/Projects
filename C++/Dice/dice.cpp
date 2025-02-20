#include <iostream>
#include <cstdlib>
#include <ctime>
#include "dice.h"

using namespace std;

int Dice(int Number, int counter) {
    int i, count = 0;
    int result = 0;

    static struct range Nick[MAX]; // Глобальний масив для збереження результатів

    srand(time(NULL));
    cout << "LOOK: Number of Dice = " << Number << "\n";
    getchar();

    for (i = 1; i <= DASH; i++) {
        cout << "The Dice" << Number << " is playing:\n";
        cout << "Number of Dice = " << Number << " DASH======================> " << i << "\n";

        result = rand() % 6 + 1; // Генерація чисел від 1 до 6
        Nick[counter].sum[i - 1] = result;

        cout << "Nick[" << counter << "].sum[" << i - 1 << "] = " << Nick[counter].sum[i - 1]
            << " Result(" << i << ") = " << result << "\n";

        count += result;
        Number = (Number == 0) ? 1 : 0;
        getchar();
    }

    cout << "\n\nRESULT\n\n";
    int cont = 0;
    while (cont < MAX) {
        cout << "Nick[" << cont << "].total = " << Nick[cont].total << "\n";
        for (int das = 0; das < DASH; das++) {
            cout << "Nick[" << cont << "].sum[" << das << "] = " << Nick[cont].sum[das] << "\n";
        }
        cont++;
    }

    getchar();
    return count;
}
