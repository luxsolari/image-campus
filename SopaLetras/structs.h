#ifndef SOPALETRAS_STRUCTS_H
#define SOPALETRAS_STRUCTS_H
#include <string>
using namespace std;  // NOLINT(clang-diagnostic-header-hygiene)

enum class Orientacion
{
    HORIZONTAL = 0,
    VERTICAL   = 1,
    DIAGONAL   = 2,
    ///////////////
    COUNT      = 3
};

enum class DimensionGrilla
{
    CHICO   = 16,
    MEDIANO = 24,
    GRANDE  = 32,
    /////////////
    COUNT   = 3
};

struct Coordenada
{
    int coordX;
    int coordY;

    Coordenada()
    {
        this->coordX = 0;
        this->coordY = 0;
    }

    Coordenada (int coordX, int coordY)
    {
        this->coordX = coordX;
        this->coordY = coordY;
    }
};

struct Casillero
{
    string contenido;
    Coordenada posicion;
    bool esAutogenerado = false;

    Casillero() = default;
    Casillero (char contenido, Coordenada posicion, bool esAutogenerado)
    {
        this->contenido = contenido;
        this->posicion  = posicion;
        this->esAutogenerado = esAutogenerado;
    }

    Casillero (const string &contenido, Coordenada posicion, bool esAutogenerado)
    {
        this->contenido = contenido;
        this->posicion  = posicion;
        this->esAutogenerado = esAutogenerado;
    }
};

struct Palabra
{
    string palabra;
    int longitud;
    Orientacion orientacion;
    Coordenada posicionInicio;
    int intentosDeInsercion = 0;

    Palabra (const string &palabra, Orientacion orientacion)
    {
        this->palabra = palabra;
        this->longitud = static_cast<int>(strlen(palabra.c_str()));
        this->orientacion = orientacion;
        this->posicionInicio = Coordenada(0, 0);
    }
};

#endif //SOPALETRAS_STRUCTS_H
