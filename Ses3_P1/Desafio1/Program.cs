// Crear un método static, que pida los ingresos de los últimos 3 meses, así como el nombre del usuario e imprima en pantalla la suma de todos los ingresos y un promedio con un mensaje similiar a "Hola <usuario> en total ganaste suma y promediaste promedio ".  
static void Main()
{
    double[] meses = new double[3];
    try
    {
        Console.WriteLine("ingrese los ingresos del mes 1: ");
        meses[0] = double.Parse(Console.ReadLine());
        Console.WriteLine("ingrese los ingresos del mes 2: ");
        meses[1] = double.Parse(Console.ReadLine());
        Console.WriteLine("ingrese los ingresos del mes 3: ");
        meses[2] = double.Parse(Console.ReadLine());
        Console.WriteLine("ingrese su nombre: ");
        string nm = Console.ReadLine();
        double sum = 0, prom;
        for (int i = 0; i < 3; i++)
        {
            sum = sum + meses[i];
        }
        prom = sum / 3;
        Console.WriteLine($"Hola {nm} en total ganaste {sum} y promediaste {prom}");
    }
    catch (Exception a)
    {
        Console.WriteLine("dato no valido ingresado error: " + a);
    }
}

Main();
