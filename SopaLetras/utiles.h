#ifndef SOPALETRAS_UTILES_H
#define SOPALETRAS_UTILES_H
#include <string>
#include <vector>
#include "structs.h"
constexpr int INTENTOS_MAX = 1000;

// Funciones para numeros aleatorios
int  getRandomNumInclusive (int min, int max);
int  getRandomNumExclusive (int min, int max);
string stringToUpper(string oString);
char getRandomChar ();

// Funciones para la grilla
void randomizarGrilla (Casillero** grilla, int dimensionGrilla);
void mostrarGrilla (Casillero** grilla, int dimensionGrilla);
bool estaOcupado (const Casillero& casillero);
void insertarEnGrilla (Casillero ** grilla, int dimensionGrilla, Palabra& palabra, bool alAzar);

// Funciones para las palabras a encontrar
void inicializarPalabrasABuscar (vector<Palabra>& palabrasAEncontrar, const string palabrasTematicas[], int palabrasTotales);
Estado estaEnLista (vector<Palabra>& palabrasAEncontrar, const string& palabraBuscada);

#endif //SOPALETRAS_UTILES_H
