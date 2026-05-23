// Crear un método static, que pida dos valores de entrada, los cuales debe convertir a entero y sumarlos, este método debe estar en un bloque Try-Catch-Finally y mostrar un mensaje de Error si sucede algún fallo durante la ejecución (por ejemplo si el valor introducido es un texto en lugar de un número o sí el valor introducido esta en blanco).
static void suma()
{
    try
    {
        Console.WriteLine("ingrese el primer numero");
        int n1 = int.Parse(Console.ReadLine());
        Console.WriteLine("ingrese el segundo numero");
        int n2 = int.Parse(Console.ReadLine());
        int sum = n1+n2;
        Console.WriteLine("La suma es: "+sum);
    }
    catch (Exception ecs)
    {
      Console.WriteLine("error: "+ecs);
    }
}

suma();
