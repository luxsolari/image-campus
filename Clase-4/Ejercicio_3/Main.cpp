#include <iostream>
#include <chrono>
#include <thread>

using namespace std;

int main()
{
	int contadorTurno = 1;
	bool enBatalla = true;

	float vidaMaxJugador	= 0.0f;
	float vidaActualJugador = 0.0f;
	float ataqueJugador		= 0.0f;

	float vidaMaxEnemigo	= 0.0f;
	float vidaActualEnemigo	= 0.0f;
	float ataqueEnemigo		= 0.0f;

	cout << "T<P>BS - Totally <Predictable> Battle Simulator" << endl;
	cout << "-------------------------------------------" << endl;

	cout << "Cuantos puntos de vida maxima tiene el jugador? : ";
	cin >> vidaMaxJugador;
	vidaActualJugador = vidaMaxJugador;

	cout << "Cuantos puntos de ataque tiene el jugador? : ";
	cin >> ataqueJugador;


	cout << "Cuantos puntos de vida maxima tiene el enemigo? : ";
	cin >> vidaMaxEnemigo;
	vidaActualEnemigo = vidaMaxEnemigo;

	cout << "Cuantos puntos de ataque tiene el enemigo? : ";
	cin >> ataqueEnemigo;
	cout << endl;
	cout << "-------------------------------------------" << endl;
	cout << "BATTLE START!" << endl;
	cout << "El jugador tiene " << vidaActualJugador << " / " << vidaMaxJugador << " PV y " << ataqueJugador << " de ATK." << endl;
	cout << "El enemigo tiene " << vidaActualEnemigo << " / " << vidaMaxEnemigo << " PV y " << ataqueEnemigo << " de ATK." << endl;
	cout << "-------------------------------------------" << endl;
	cout << endl;
	this_thread::sleep_for(2.5s);

	while (enBatalla)
	{
		system("cls");

		cout << "-------------------------------------------" << endl;
		cout << "TURNO " << contadorTurno << ": " << endl;
		this_thread::sleep_for(1s);
		
		vidaActualEnemigo -= ataqueJugador;
		cout << "El jugador ataca! El enemigo recibe " << ataqueJugador << " de DMG. Le quedan " << vidaActualEnemigo << " / " << vidaMaxEnemigo << " PV." << endl;
		this_thread::sleep_for(1s);
		if (vidaActualEnemigo <= 0.0f) 
		{
			// El jugador es victorioso, por lo que detenmos la batalla en este punto.
			cout << "El jugador ha ganado la batalla!" << endl;
			enBatalla = false;
		}
		else 
		{
			// El enemigo aun tiene vida, por lo que hace su turno.
			vidaActualJugador -= ataqueEnemigo;
			cout << "El enemigo ataca! El jugador recibe " << ataqueEnemigo << " de DMG. Le quedan " << vidaActualJugador << " / " << vidaMaxJugador << " PV." << endl;
			this_thread::sleep_for(1s);
			if (vidaActualJugador <= 0.0f)
			{
				// El enemigo es victorioso, por lo que detenmos la batalla en este punto.
				cout << "El enemigo ha ganado la batalla!" << endl;
				enBatalla = false;
			}
		}
		// Ninguno de los dos participantes tiene 0 PV, por lo que aumentamos el contador de turnos y seguimos.	
		contadorTurno++;
		this_thread::sleep_for(1s);
		cout << endl;
		cout << "El jugador tiene " << vidaActualJugador << " / " << vidaMaxJugador << " PV." << endl;
		cout << "El enemigo tiene " << vidaActualEnemigo << " / " << vidaMaxEnemigo << " PV." << endl;
		cout << "-------------------------------------------" << endl;
		cout << endl;
		this_thread::sleep_for(2.5s);
	}


	return 0;
}
