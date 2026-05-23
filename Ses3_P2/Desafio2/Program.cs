// Crea una aplicación que maneje los puntajes de un juego imaginario. Tendrá un puntaje, un puntaje record y un jugador record.
//
//
// Crea un método que tenga dos parámetros, uno para el puntaje obtenido y otro para el nombre del jugador.
//
//
// Cuando se llama a ese método, se debe verificar si el puntaje del jugador es mayor que la puntuación más alta, si es así, que se escriba en la consola algo así como"La nueva puntuación más alta es " + puntuación. Y en otra línea "La puntuación más alta fue lograda por " + nombre del jugador.
//
//
// Si no fue así, entonces que se escriba algo como "La puntuación más alta de " + puntuación más alta + " no se ha podido superar, y aún está en manos de " + jugador record.
//
//
// Considera qué variables se requieren globalmente y cuáles localmente.
class jugadores
{
    public string nombre;
    public int puntaje;
    public jugadores(string nm, int punt)
    {
        this.nombre = nm;
        this.puntaje = punt;
    }
}
class programa
{
    static void Main()
    {
        jugadores[] jugador = new jugadores[2];
        jugador[0] = new jugadores("Jugador1", 0);
        int n = 2;
        do
        {
            Console.WriteLine(
            "menu\n" +
            "---------------------\n" +
            "opcion 1: Ingresar jugador y puntaje\n" +
            "opcion 2: ver punteo mayor\n" +
            "opcion 3: Salir"
            );
            n = int.Parse(Console.ReadLine());
            if (n == 3)
            {
                break;
            }
            else if (n == 1)
            {
                Console.WriteLine("ingrese el nombre del jugador: ");
                string nm = Console.ReadLine();
                Console.WriteLine("ingrese el puntaje del jugador: ");
                int punta = int.Parse(Console.ReadLine());
                jugador[1] = new jugadores(nm, punta);
                if (jugador[0].puntaje > jugador[1].puntaje)
                {
                    Console.WriteLine("El jugador " + jugador[0].nombre + " mantiene la puntacion mayor con " + jugador[0].puntaje + " puntos");
                }
                else
                {
                    Console.WriteLine("El jugador " + jugador[1].nombre + " ha superado el puntaje record de " + jugador[0].puntaje + " con " + jugador[1].puntaje + " puntos");
                    jugador[0] = jugador[1];
                }
            }
            else if (n == 2)
            {
                Console.WriteLine("El jugador " + jugador[0].nombre + " es el jugador com mas puntos con " + jugador[0].puntaje + " puntos");
            }
        } while (true);
    }
}
