#include <iostream>
#include "utils.h"
using namespace std;

int main()
{
	srand(time(0));
    
    Casillero** grilla;
    unsigned long dimensionMatriz;

    // Pedir input del tamaño del array
    string inputDimension;
    cout << "Incializando sopa de letras" << endl;
    cout << "Ingresar dimension de la sopa: ";
    getline(cin, inputDimension);
    dimensionMatriz = stoul(inputDimension);

    // Inicializar array
    grilla = new Casillero*[dimensionMatriz]{};
    randomizarGrilla(grilla, dimensionMatriz); 
    inicializarDatosDePrueba(grilla, dimensionMatriz);

    // Mostrar matriz por pantalla
    mostrarGrilla(grilla, dimensionMatriz);

    return 0;
}
