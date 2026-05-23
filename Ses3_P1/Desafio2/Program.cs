// Crear una clase que contenga 4 métodos que realicen las operaciones básicas (Sumar, Restar, Multiplicar, Dividir), debe pedir como parámetro dos números de tipo int y retornar un valor del mismo tipo. 
//
// Debe invocar los 4 métodos desde el método main.

class operaciones
{
    int dt()
    {
        Console.WriteLine("ingrese el numero: ");
        return int.Parse(Console.ReadLine());
    }
    double sm(double n1, double n2)
    {
        return n1 + n2;
    }
    double rs(double n1, double n2)
    {
        return n1 - n2;
    }
    double mult(double n1, double n2)
    {
        return n1 * n2;
    }
    double div(double n1, double n2)
    {
        return n1 / n2;
    }
    static void Main()
    {
        try
        {
            operaciones op = new operaciones();
            Console.WriteLine("ingrese los datos para la suma: ");
            double sm = op.sm(op.dt(), op.dt());
            Console.WriteLine("el resultado es: " + sm);
            Console.WriteLine("ingrese los datos para la resta: ");
            double rs = op.rs(op.dt(), op.dt());
            Console.WriteLine("el resultado es: " + rs);
            Console.WriteLine("ingrese los datos para la multiplicacion: ");
            double mult = op.mult(op.dt(), op.dt());
            Console.WriteLine("el resultado es: " + mult);
            Console.WriteLine("ingrese los datos para la division: ");
            double div = op.div(op.dt(), op.dt());
            Console.WriteLine("el resultado es: " + div);
        }
        catch (Exception w)
        {
            Console.WriteLine("error: " + w);
        }
    }
}
