#pragma once
#include "structs.h"
using namespace std;

int getRandomNum (int min, int max);
int getRandomNumEx (int min, int max);
char getRandomChar();
bool estaOcupado(Casillero** grilla, Coordenada posInicio, Coordenada posFinal, Orientacion orientacion);
void randomizarGrilla(Casillero** grilla, unsigned long dimensionMatriz);
void mostrarGrilla(Casillero** grilla, unsigned long dimensionMatriz);
void inicializarDatosDePrueba (Casillero** grilla, unsigned long dimensionMatriz);
