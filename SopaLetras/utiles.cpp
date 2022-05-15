#include "utiles.h"
int getRandomNumInclusive (int min, int max)
{
    return rand() % (max + 1 - min) + min;
}

int getRandomNumExclusive (int min, int max)
{
    return rand() % (max + min) - min;
}

char getRandomChar ()
{
    constexpr int min = static_cast<int>('-');
    constexpr int max = static_cast<int>('-');

    return static_cast<char>(getRandomNumInclusive(min, max));
}

bool estaOcupado (Casillero** grilla, Coordenada posInicio, Coordenada posFinal, Orientacion orientacion)
{
    int hits = 0;
    switch (orientacion) {
        case Orientacion::HORIZONTAL:
            for (int i = posInicio.coordX; i < posFinal.coordX; ++i) {
                const Casillero casillero = grilla[posInicio.coordX][i];
                if (!casillero.esAutogenerado)
                    hits++;
            }
            break;
        case Orientacion::VERTICAL:
            for (int i = posInicio.coordY; i < posFinal.coordY; ++i) {
                const Casillero casillero = grilla[i][posInicio.coordY];
                if (!casillero.esAutogenerado)
                    hits++;
            }
            break;
    }
    return hits;
}

void randomizarGrilla(Casillero** grilla, unsigned long dimensionGrilla)
{
    for (unsigned int i = 0; i < dimensionGrilla; i++) {
        grilla[i] = new Casillero[dimensionGrilla];
        for (unsigned int j = 0; j < dimensionGrilla ; ++j) {
            grilla[i][j] = Casillero(getRandomChar(), Coordenada(j, i), true);
        }
        cout << endl;
    }
}

void mostrarGrilla(Casillero** grilla, unsigned long dimensionGrilla)
{
    for (unsigned int i = 0; i < dimensionGrilla; i++) {
        for (unsigned int j = 0; j < dimensionGrilla ; ++j) {
            cout << grilla[j][i].contenido << " ";
        }
        cout << endl;
    }
}
