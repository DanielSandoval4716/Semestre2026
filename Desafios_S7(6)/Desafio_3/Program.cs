class Programa
{
    static List<string> tas = new List<string>();
    static void Main()
    {
        int op;
        do
        {
            Console.WriteLine("Seleccione una opción: ");
            Console.WriteLine("1. Mostrar tareas");
            Console.WriteLine("2. Agregar tarea");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("0. Salir");
            op = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (op)
            {
                case 1:
                    Mostrar();
                    break;
                case 2:
                    Agregar();
                    break;
                case 3:
                    Eliminar();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
            Console.WriteLine();
        } while (op != 0);
    }
    static void Mostrar()
    {
        if (tas.Count == 0)
        {
            Console.WriteLine("No hay tareas.");
            return;
        }
        Console.WriteLine("Lista de tareas:");
        for (int i = 0; i < tas.Count; i++)
        {
            Console.WriteLine("{0}.{1}", i+1, tas[i]);
        }
    }
    static void Agregar()
    {
        Console.Write("Ingrese la nueva tarea: ");
        string tarita = Console.ReadLine();
        tas.Add(tarita);
    }
    static void Eliminar()
    {
        Mostrar();
        if (tas.Count == 0) return;
        Console.Write("Ingrese el número de la tarea a eliminar: ");
        int idx = int.Parse(Console.ReadLine());
        if (idx >= 1 && idx <= tas.Count)
        {
            tas.RemoveAt(idx - 1);
        }
        else
        {
            Console.WriteLine("Índice inválido. La tarea no existe");
        }
    }
}
