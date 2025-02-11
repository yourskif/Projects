#include <iostream>
#include <cstdlib>
#include <ctime>
#include "dice.h"

using namespace std;

int Game(struct range zmin, int counter) {
    int NumberDice = 0;

    srand(time(NULL));
    NumberDice = rand() % 2;

    cout << "GAME OF " << zmin.player << "\n\n";
    return Dice(NumberDice, counter);
}
