#include <iostream>
using namespace std;

int main()
{
    // Declarar array bi-dimensional
    char** matrizSopaLetras;
    unsigned long dimensionMatriz;

    // Pedir input del tamaño del array
    string inputDimension;
    cout << "Incializando sopa de letras" << endl;
    cout << "Ingresar dimension de la sopa: ";
    getline(cin, inputDimension);
    dimensionMatriz = stoul(inputDimension);

    // Inicializar array
    matrizSopaLetras = new char*[dimensionMatriz];
    for (int i = 0; i < dimensionMatriz; ++i) {
        matrizSopaLetras[i] = new char[dimensionMatriz];
    }

    return 0;
}
