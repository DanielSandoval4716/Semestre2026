using System;
using MySql.Data.MySqlClient;
class Program
{
    static string conexion = "Server=localhost;Database=escuela;User=root;Password=1234;";
    static void Main()
    {
        MySqlConnection con = new MySqlConnection(conexion);
        con.Open();
        string tabla =
        "CREATE TABLE IF NOT EXISTS Alumnos (" +
        "Id INT AUTO_INCREMENT PRIMARY KEY," +
        "Nombre VARCHAR(100)," +
        "Apellido VARCHAR(100)," +
        "Correo VARCHAR(150)," +
        "Edad INT)";
        MySqlCommand crearTabla = new MySqlCommand(tabla, con);
        crearTabla.ExecuteNonQuery();
        con.Close();
        while (true)
        {
            Console.WriteLine("\n1. Crear");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Salir");
            Console.Write("Opcion: ");
            string op = Console.ReadLine();
            if (op == "1")
            {
                Crear();
            }
            else if (op == "2")
            {
                Listar();
            }
            else if (op == "3")
            {
                Actualizar();
            }
            else if (op == "4")
            {
                Eliminar();
            }
            else if (op == "0")
            {
                break;
            }
        }
    }
    static void Crear()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Correo: ");
        string correo = Console.ReadLine();
        Console.Write("Edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());
        MySqlConnection con = new MySqlConnection(conexion);
        con.Open();
        string sql =
        "INSERT INTO Alumnos (Nombre, Apellido, Correo, Edad) " +
        "VALUES (@nombre, @apellido, @correo, @edad)";
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@apellido", apellido);
        cmd.Parameters.AddWithValue("@correo", correo);
        cmd.Parameters.AddWithValue("@edad", edad);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Alumno creado.");
        con.Close();
    }
    static void Listar()
    {
        MySqlConnection con = new MySqlConnection(conexion);
        con.Open();
        string sql = "SELECT * FROM Alumnos";
        MySqlCommand cmd = new MySqlCommand(sql, con);
        MySqlDataReader reader = cmd.ExecuteReader();
        Console.WriteLine("\nID  Nombre  Apellido  Correo  Edad");
        while (reader.Read())
        {
            Console.WriteLine(
                reader["Id"] + " " +
                reader["Nombre"] + " " +
                reader["Apellido"] + " " +
                reader["Correo"] + " " +
                reader["Edad"]
            );
        }
        con.Close();
    }
    static void Actualizar()
    {
        Listar();
        Console.Write("\nIngrese ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nuevo nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Nuevo apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Nuevo correo: ");
        string correo = Console.ReadLine();
        Console.Write("Nueva edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());
        MySqlConnection con = new MySqlConnection(conexion);
        con.Open();
        string sql = "UPDATE Alumnos " + "SET Nombre=@nombre, Apellido=@apellido, Correo=@correo, Edad=@edad " + "WHERE Id=@id";
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@apellido", apellido);
        cmd.Parameters.AddWithValue("@correo", correo);
        cmd.Parameters.AddWithValue("@edad", edad);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Alumno actualizado.");
        con.Close();
    }
    static void Eliminar()
    {
        Listar();
        Console.Write("\nIngrese ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        MySqlConnection con = new MySqlConnection(conexion);
        con.Open();
        string sql = "DELETE FROM Alumnos WHERE Id=@id";
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Alumno eliminado.");
        con.Close();
    }
}
