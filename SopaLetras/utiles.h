#ifndef SOPALETRAS_UTILES_H
#define SOPALETRAS_UTILES_H
#include "structs.h"

// Funciones para numeros aleatorios
int getRandomNumInclusive (int min, int max);
int getRandomNumExclusive (int min, int max);
char getRandomChar ();

// Funciones para la grilla
void randomizarGrilla (Casillero** grilla, int dimensionGrilla);
void mostrarGrilla (Casillero** grilla, int dimensionGrilla);
bool estaOcupado (const Casillero& casillero);
void insertarPalabra (Casillero ** grilla, int dimensionGrilla, Palabra& palabra);

// Funciones de prueba

#endif //SOPALETRAS_UTILES_H
