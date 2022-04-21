#include <iostream>
#include <string>
using namespace std;

enum class Elemento
{
	PIEDRA	= 1,
	PAPEL	= 2,
	TIJERA	= 3
};

int main()
{
	constexpr int CANTIDAD_JUGADORES = 3;
	string nombresJugadores[CANTIDAD_JUGADORES] = {};
	Elemento eleccionesJugadores[CANTIDAD_JUGADORES] = {};

	for (int i = 0; i < CANTIDAD_JUGADORES; i++)
	{
		string nombreJugador;

		cout << "Ingrese el nombre del jugador " << i + 1 << ": ";
		getline(cin, nombreJugador);
		nombresJugadores[i] = nombreJugador;

		int inputJugador;
		do
		{
			cout << nombresJugadores[i] << ", elija su opcion (1 - PIEDRA, 2- PAPEL, 3 - TIJERA): ";
			cin >> inputJugador;

			if (!cin.good() || (inputJugador < 1 || inputJugador > 3))
			{
				// Operaciones sobre el stream de entrada para ignorar los inputs invalidos
				// https://stackoverflow.com/questions/5655142/how-to-check-if-input-is-numeric-in-c
				cin.clear();
				cout << "Solo se permite ingresar numeros entre 1 y 3." << endl;
			}
			cin.ignore((std::numeric_limits<std::streamsize>::max()), '\n');
		} while (inputJugador < 1 || inputJugador > 3);

		switch (inputJugador)
		{
			case 1:
				eleccionesJugadores[i] = Elemento::PAPEL;
				break;
			case 2:
				eleccionesJugadores[i] = Elemento::PIEDRA;
				break;
			case 3:
				eleccionesJugadores[i] = Elemento::TIJERA;
				break;
		}

		system("cls");
	}

	// Lo que sigue es esencialmente una combinatioria de N elementos tomados de a dos, jugador A y jugador B, sin considerar repeticiones.
	// En este caso, quiero calcular un juego de todos contra todos, pero a diferencia de un "round-robin" con "ida y vuelta",
	// yo solo quiero considerar los casos de "ida".
	// Por ejemplo, si tengo tres jugadores;
	// A debe jugar contra B
	// A debe jugar contra C
	// B   no juega contra A (esto seria el partido de "vuelta", pero no lo quiero considerar)
	// B debe jugar contra C
	// C   no juega contra A (otro caso de "vuelta")
	// C   no juega contra B (otro caso de "vuelta")
	// Eso nos deja solamente con 3 juegos en lugar de los 6 que normalmente tendriamos en un "round-robin".
	//
	// Link a una calculadora para ver la teoria detras del asunto:
	// https://www.hackmath.net/en/calculator/combinations-and-permutations?n=3&k=2&order=1&repeat=0
	int nroJuego = 1;
	for (int jugadorA = 0; jugadorA < CANTIDAD_JUGADORES; jugadorA ++)
	{
		for (int jugadorB = jugadorA + 1; jugadorB < CANTIDAD_JUGADORES; jugadorB ++)
		{
			if (jugadorA != jugadorB)
			{
				string eleccionJugadorA;
				string eleccionJugadorB;

				switch (eleccionesJugadores[jugadorA])
				{
				case Elemento::PIEDRA: 
					eleccionJugadorA = "Piedra";
					break;
				case Elemento::PAPEL:
					eleccionJugadorA = "Papel";
					break;
				case Elemento::TIJERA:
					eleccionJugadorA = "Tijera";
					break;
				}

				switch (eleccionesJugadores[jugadorB])
				{
				case Elemento::PIEDRA: 
					eleccionJugadorB = "Piedra";
					break;
				case Elemento::PAPEL:
					eleccionJugadorB = "Papel";
					break;
				case Elemento::TIJERA:
					eleccionJugadorB = "Tijera";
					break;
				}

				cout << "Juego " << nroJuego <<": "
					 << nombresJugadores[jugadorA] << " - " << eleccionJugadorA << " "
					 << " vs. "
					 << nombresJugadores[jugadorB] << " - " << eleccionJugadorB << " "
				<< endl;
				nroJuego ++;
			}
		}
	}

}