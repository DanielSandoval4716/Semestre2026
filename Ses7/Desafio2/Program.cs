
interface INotificable{
  void Notifica();
}
class Notificacion_email:INotificable
{
  string direccion_correo;
  public void Notifica()
  {
    Console.WriteLine("Notificacion por email");
  }
}
class Notificacion_whatsapp:INotificable
{
  string numero_telefono;
  public void Notifica()
  {
    Console.WriteLine("Notificacion por whatsapp");
  }
}
class Notificacion_sms:INotificable
{
  string numero_telefono;
  public void Notifica()
  {
    Console.WriteLine("Notificacion por sms");
  }
}
class Programa
{
  static void Main()
  {
    Notificacion_email n1 = new Notificacion_email();
    Notificacion_whatsapp n2 = new Notificacion_whatsapp();
    Notificacion_sms n3 = new Notificacion_sms();
    n1.Notifica();
    n2.Notifica();
    n3.Notifica();
  }
  // Prueba con Interfaces
  // INotificable n;
  // Programa(INotificable n1){
  //   n = n1;
  // }
  // static void Main(string[] args)
  // {
  //   Programa p1 = new Programa(new Notificacion_email());
  //   Programa p2 = new Programa(new Notificacion_whatsapp());
  //   Programa p3 = new Programa(new Notificacion_sms());
  //   p1.n.Notifica();
  //   p2.n.Notifica();
  //   p3.n.Notifica();
  // }
}
