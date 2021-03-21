#include <string>
#include <vector>
#include <map>
#include <algorithm>
#include <random>
#include <iostream>

using namespace std;
// Other implementation: https://www.geeksforgeeks.org/counting-sort/
void countingSort(vector<int> & input, int range) {
    vector<int> count(range + 1, 0); // Use counting sort concept.
    int minValue = range + 1, maxValue = -1; // value range of trailingNums.

    for (int i = 0; i < input.size(); i++) {
        count[input[i]] ++;
        minValue = min(minValue, input[i]);
        maxValue = max(maxValue, input[i]);
    }

    for (int i = minValue, j = 0; i <= maxValue; i++) {
        while (count[i] > 0) {
            input[j] = i;
            count[i] --;
            j++;
        }
    }
}

int main() {
    int range = 20;
    vector<int> input(range);
    for (int i = 0; i < range; i++) {
        input[i] = i;
    }

    for (int i = 0; i < range; i++) {
        shuffle(input.begin(), input.end(), std::default_random_engine(22323));
        for_each(input.begin(), input.end(), [](int & n) {cout << n << " "; });
        cout << endl;

        countingSort(input, range);
        for_each(input.begin(), input.end(), [](int & n) {cout << n << " "; });
        cout << endl << endl;
    }
}