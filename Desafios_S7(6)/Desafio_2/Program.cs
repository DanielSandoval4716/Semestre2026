class Programa
{
    static double[,] cp = new double[5, 5];
    void Prose()
    {
        for (int i = 0; i < cp.GetLength(0); i++)
        {
            double total = 0;
            for (int j = 0; j < cp.GetLength(1); j++)
            {
                total += cp[i, j];
            }
            double  totaF= Desc(total);
            Console.WriteLine($"Cliente {i + 1}:");
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Total con descuento aplicado: {totaF}");
        }
    }
    double Desc(double tot)
    {
        if (tot >= 100 && tot <= 1000)
        {
            return tot - (tot * 0.10);
        }
        else if (tot > 1000)
        {
            return tot - (tot * 0.20);
        }
        return tot;
    }
    static void Main()
    {
        for (int i = 0; i < cp.GetLength(0); i++)
        {
            Console.WriteLine("ingrese las compras del cliente {0} (5 compras obligatorias)",i+1);
            for (int j = 0; j < cp.GetLength(1); j++)
            {
                cp[i, j] = double.Parse(Console.ReadLine());
            }
        }
        Programa p = new Programa();
        p.Prose();
    }
}
