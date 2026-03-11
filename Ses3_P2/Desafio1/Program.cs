// Crea un sistema de inicio de sesión de usuario, donde el usuario puede primero registrarse y luego iniciar sesión. El programa debe verificar si el usuario ha ingresado el nombre de usuario y la contraseña correctos al iniciar sesión (por lo tanto, los mismos que utilizó al registrarse).
//
//
// Utiliza declaraciones If, ingresos del usuario y métodos para resolver el desafío.
class persoina
{
    public string nombre;
    public string contra;
    public persoina(string nombre, string contra)
    {
        this.nombre = nombre;
        this.contra = contra;
        Console.WriteLine("usuario creado ");
    }
}

class principal
{
    static void Main()
    {
        persoina[] persoinas = new persoina[20];
        int ct = 0;
        int n = 3;
        do
        {
            Console.WriteLine(
            "menu\n" +
            "---------------------\n" +
            "opcion 1: Ingresar nuevo usuario\n" +
            "opcion 2: Iniciar sesion\n" +
            "opcion 3: Salir"
            );
            n = int.Parse(Console.ReadLine());
            if (n == 3)
            {
                Console.WriteLine("Haz salido del menu");
                break;
            }
            switch (n)
            {
                case 1:
                    Console.WriteLine("ingrese el nombre del usuario: ");
                    string nm = Console.ReadLine();
                    Console.WriteLine("ingrese la contraseña: ");
                    string ctr = Console.ReadLine();
                    persoinas[ct] = new persoina(nm, ctr);
                    ct++;
                    break;
                case 2:
                    Console.WriteLine("ingrese el nombre del usuario: ");
                    string nm1 = Console.ReadLine();
                    Console.WriteLine("ingrese la contraseña: ");
                    string ctr1 = Console.ReadLine();
                    bool buscador = false;
                    for (int i = 0; i < ct; i++)
                    {
                        if (persoinas[i].nombre== nm1 && persoinas[i].contra == ctr1)
                        {
                          buscador = true;
                          break;
                        }
                    }
                    if (buscador == true)
                    {
                      Console.WriteLine("El usuario es correcto, se ha encontrado");
                    }else
                    {
                        Console.WriteLine("El usuario no existe");
                    }
                    break;
            }
        } while (true);
    }
}
