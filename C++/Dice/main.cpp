#include <iostream>
#include "dice.h"

using namespace std;

int main() {
    struct range player;
    int counter = 0;

    cout << "Enter player name: ";
    cin >> player.player;

    int result = Game(player, counter);
    cout << "Final score: " << result << endl;

    return 0;
}
