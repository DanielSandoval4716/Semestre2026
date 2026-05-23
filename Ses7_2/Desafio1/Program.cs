public class Auto
{
    public string placa;
    string ruta = "/home/fist/ra/codes/programacion26/Ses7_2/Guardar_Historial_de_reparaciones.txt";
    public int hp;
    public string color;
    public Auto(string placa, int hp, string color)
    {
        this.placa = placa;
        this.hp = hp;
        this.color = color;
    }
    public virtual void MostrarDetalles()
    {
        Console.WriteLine($"Placa: {placa} - {color} - {hp} HP");
    }
    public virtual void Reparar()
    {
        Console.WriteLine("El vehiculo ha sido reparado");
    }
    public void Imprimir_Hitorial_de_reparaciones()
    {
        string texto = File.ReadAllText(ruta);
        Console.WriteLine(texto);
    }
    public void Guardar_Historial_de_reparaciones()
    {
        if (File.Exists(ruta))
        {
            File.AppendAllText(ruta, "El vehiculo ha sido reparado a las {0}" + DateTime.Now + "\n");
        }
        else
        {
            File.WriteAllText(ruta, "El vehiculo ha sido reparado a las {0}" + DateTime.Now + "\n");
        }
    }
}
class BMW : Auto
{
    private string marca = "BMW";
    public string Modelo;
    public BMW(string placa, int hp, string color, string modelo) : base(placa, hp, color)
    {
        this.Modelo = modelo;
    }
    public new void MostrarDetalles()
    {
        Console.WriteLine("Marca: {0} - Modelo: {1} - HP: {2} - Color: {3}", marca, Modelo, hp, color);
    }
    public override void Reparar()
    {
        Console.WriteLine("El BMW {0} está reparado", Modelo);
        Guardar_Historial_de_reparaciones();
    }
}
class Programa
{
    static void Main()
    {
        BMW bmw = new BMW("ABC123", 300, "Negro", "M3");
        bmw.MostrarDetalles();
        bmw.Reparar();
        bmw.Imprimir_Hitorial_de_reparaciones();
    }
}
