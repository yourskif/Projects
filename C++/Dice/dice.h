#ifndef DICE_H
#define DICE_H

#define DASH 6
#define LEN 10
#define MAX 10

struct range {
    char player[LEN];
    int sum[DASH];
    int total;
};

int Game(struct range zmin, int counter);
int Dice(int Number, int counter);

#endif // DICE_H
#pragma once
