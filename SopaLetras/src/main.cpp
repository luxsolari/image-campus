#include <iostream>
using namespace std;

struct Palabra
{
	string palabra;
	int longitud;
	int posicionInicioX;
	int posicionIncioY;
};

int getRandomNum (int min, int max);
char getRandomChar();

int main()
{
	// Incializar seed random
	srand(time(0));

	// Lista de "palabras"
	// Palabra** listaPalabras = new Palabra*;

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
        // Incializar columnas
        matrizSopaLetras[i] = new char[dimensionMatriz];
        for (int j = 0; j < dimensionMatriz; j++)
        {
            matrizSopaLetras[i][j] = getRandomChar();
        }        
    }

    // Mostrar matriz por pantalla
    for (int i = 0; i < dimensionMatriz; i++)
    {
        for (int j = 0; j < dimensionMatriz; j++)
        {
            cout << matrizSopaLetras[i][j] << " ";
        }
        cout << endl;
    }   

    return 0;
}

int getRandomNum (int min, int max)
{
	return rand() % (max + 1 - min) + min;
}

char getRandomChar ()
{
	// Casting de tipo de dato (convertir de un tipo de dato a otro).
	int min = (int)'A';
	int max = (int)'Z';

	return (char)getRandomNum(min, max);
}