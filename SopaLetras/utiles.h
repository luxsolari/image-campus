#ifndef SOPALETRAS_UTILES_H
#define SOPALETRAS_UTILES_H
#include "structs.h"
#include <iostream>

int getRandomNumInclusive (int min, int max);
int getRandomNumExclusive (int min, int max);
char getRandomChar ();
bool estaOcupado (Casillero** grilla, Coordenada posInicio, Coordenada posFinal, Orientacion orientacion);
void randomizarGrilla (Casillero** grilla, unsigned long dimensionGrilla);
void mostrarGrilla (Casillero** grilla, unsigned long dimensionGrilla);
void inicializarDatosPrueba (Casillero** grilla, unsigned long dimensionGrilla);

#endif //SOPALETRAS_UTILES_H
