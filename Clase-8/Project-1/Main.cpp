#include <iostream>
#include <string>
using namespace std;

void imprimirInvertido(char cadena[], int longitud);

int main()
{
	bool continuar = true;
	char opcion;

	while (continuar)
	{
		string input;
		cout << "Dame una cadena de texto y te muestro su inverso: ";
		cin >> input;

		char* arregloChars = new char[(int) input.length()];
		arregloChars = const_cast<char*>(input.c_str());

		imprimirInvertido(arregloChars, (int) input.length());

		do
		{
			cout << endl;
			cout << "Comenzar de nuevo? (s/n): ";
			cin >> opcion;

			switch (opcion)
			{
			case 'S':
			case 's':
				system("cls");
				break;
			case 'N':
			case 'n':
				cout << "Terminado!" << endl;
				continuar = false;
				break;
			default:
				cout << "Ingresar solamente 's' o 'n'" << endl;
				break;
			}

			if (!cin.good())
			{
				// Operaciones sobre el stream de entrada para ignorar los inputs invalidos
				// https://stackoverflow.com/questions/5655142/how-to-check-if-input-is-numeric-in-c
				cin.clear();
				cout << "Solo se permite ingresar numeros entre 1 y 3." << endl;
			}
			cin.ignore((std::numeric_limits<std::streamsize>::max()), '\n');
		}
		while (opcion != 'S' && opcion != 's' && opcion != 'N' && opcion != 'n');
	}


	return 0;
}

void imprimirInvertido(char cadena[], int longitud)
{
	for (int i = longitud ; i >= 0; i--)
	{
		cout << cadena[i];
	}
}
