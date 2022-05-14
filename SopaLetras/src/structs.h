#pragma once
using namespace std;

enum class Orientacion
{
	HORIZONTAL = 0,
	VERTICAL   = 1,
    ///////////////
	COUNT      = 2
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
	bool esAutogenerado;

	Casillero(){}

	Casillero (char contenido, Coordenada posicion, bool esAutogenerado)
	{
		this->contenido = contenido;
		this->posicion = posicion;
		this->esAutogenerado = esAutogenerado;
	}

	Casillero (string contenido, Coordenada posicion, bool esAutogenerado)
	{
		this->contenido = contenido;
		this->posicion = posicion;
		this->esAutogenerado = esAutogenerado;
	}
};

struct Palabra
{
	string palabra;
	int longitud;
	Coordenada posicionInicio;
	Orientacion orientacion;

	Palabra (string palabra, int longitud, Coordenada posicionInicio, Orientacion orientacion) {
		this->palabra = palabra;
		this->longitud = longitud;
		this->posicionInicio = posicionInicio;
		this->orientacion = orientacion;
	}
};
