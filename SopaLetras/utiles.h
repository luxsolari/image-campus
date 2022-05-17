#ifndef SOPALETRAS_UTILES_H
#define SOPALETRAS_UTILES_H
#include "structs.h"

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
void marcarPalabra (Casillero** grilla, const Palabra& palabra);

// Funciones para las palabras a encontrar
void inicializarPalabrasABuscar (vector<Palabra>& palabrasAEncontrar, const string palabrasTematicas[], int palabrasTotales, int dimensionGrilla);
Estado estaEnLista (vector<Palabra>& palabrasAEncontrar, const string& palabraBuscada);
Palabra buscarPalabra (vector<Palabra>& palabrasAEncontrar, const string& palabraBuscada);

#endif //SOPALETRAS_UTILES_H
