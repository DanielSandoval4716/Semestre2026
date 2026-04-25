class tablero
{
    public char[,] tab = new char[3, 3];
    public void imprim()
    {
        Console.WriteLine("| {0} | {1} | {2} |", tab[0, 0], tab[0, 1], tab[0, 2]);
        Console.WriteLine("| {0} | {1} | {2} |", tab[1, 0], tab[1, 1], tab[1, 2]);
        Console.WriteLine("| {0} | {1} | {2} |", tab[2, 0], tab[2, 1], tab[2, 2]);
    }
    public void inser(int x, int y, char let)
    {
        tab[x, y] = let;
    }
    public char gana(char[,] t)
    {
        for (int i = 0; i < 3; i++)
        {
            if (t[i, 0] == t[i, 1] && t[i, 1] == t[i, 2])
            {
                return t[i, 0];
            }
            if (t[0, i] == t[1, i] && t[1, i] == t[2, i])
            {
                return t[0, i];
            }
        }
        if (t[0, 0] == t[1, 1] && t[1, 1] == t[2, 2])
        {
            return t[0, 0];
        }
        if (t[0, 2] == t[1, 1] && t[1, 1] == t[2, 0])
        {
            return t[0, 2];
        }
        return ' ';
    }
}
class Programa
{
    static void Main()
    {
        tablero t = new tablero();
        t.imprim();
        do
        {
            Console.WriteLine("Turno de X");
            Console.WriteLine("Fila: ");
            int x = int.Parse(Console.ReadLine())-1;
            Console.WriteLine("Columna: ");
            int y = int.Parse(Console.ReadLine())-1;
            t.inser(x, y, 'X');
            t.imprim();
            if (t.gana(t.tab) == 'X')
            {
                Console.WriteLine("Gano X");
                break;
            }
            if (t.gana(t.tab) == 'O')
            {
                Console.WriteLine("Gano O");
                break;
            }
            Console.WriteLine("Turno de O");
            Console.WriteLine("Fila: ");
            x = int.Parse(Console.ReadLine())-1;
            Console.WriteLine("Columna: ");
            y = int.Parse(Console.ReadLine())-1;
            t.inser(x, y, 'O');
            t.imprim();
            if (t.gana(t.tab) == 'X')
            {
                Console.WriteLine("Gano X");
                break;
            }
            if (t.gana(t.tab) == 'O')
            {
                Console.WriteLine("Gano O");
                break;
            }
        } while (true);
    }
}
