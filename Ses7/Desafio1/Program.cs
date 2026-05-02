class calculadora
{
  public string marca = "";
  public string serie = "";
  public int Sumar(int a, int b)
  {
    return a + b;
  }
  public int Restar(int a, int b)
  {
    return a - b;
  }
  public int Multiplicar(int a, int b)
  {
    return a * b;
  }
  public int Dividir(int a, int b)
  {
    return a / b;
  }
}
class calculadora_cientifica:calculadora
{
  public calculadora_cientifica(string marca, string serie)
  {
    this.marca = marca;
    this.serie = serie;
  }
  public int Potencia(int a, int b)
  {
    return (int)Math.Pow(a, b);
  }
  public int Raiz(int a)
  {
    return (int)Math.Sqrt(a);
  }
  public int Modulo(int a)
  {
    return (int)Math.Abs(a);
  }
  public int Logaritmo(int a)
  {
    return (int)Math.Log10(a);
  }
}
class Programa
{
  static void Main()
  {
    // Console.WriteLine("Ingrese la marca de la calculadora");
    // string marca = Console.ReadLine();
    // Console.WriteLine("Ingrese la serie de la calculadora");
    // string serie = Console.ReadLine();
    // calculadora_cientifica calc = new calculadora_cientifica(marca, serie);
    // Console.WriteLine("Ingrese el primer valor");
    // int a = int.Parse(Console.ReadLine());
    // Console.WriteLine("Ingrese el segundo valor");
    // int b = int.Parse(Console.ReadLine());
    // Console.WriteLine("Suma: {0}", calc.Sumar(a, b));
    // Console.WriteLine("Resta: {0}", calc.Restar(a, b));
    // Console.WriteLine("Multiplicacion: {0}", calc.Multiplicar(a, b));
    // Console.WriteLine("Division: {0}", calc.Dividir(a, b));
    // Console.WriteLine("Potencia: {0}", calc.Potencia(a, b));
    // Console.WriteLine("Raiz: {0}", calc.Raiz(a));
    // Console.WriteLine("Modulo: {0}", calc.Modulo(a));
    // Console.WriteLine("Logaritmo: {0}", calc.Logaritmo(a));
    calculadora_cientifica calc_suma = new calculadora_cientifica("Suma", "1");
    calculadora_cientifica calc_resta = new calculadora_cientifica("Resta", "2");
    calculadora_cientifica calc_multiplicacion = new calculadora_cientifica("Multiplicacion", "3");
    calculadora_cientifica calc_division = new calculadora_cientifica("Division", "4");
    calculadora_cientifica calc_potencia = new calculadora_cientifica("Potencia", "5");
    calculadora_cientifica calc_raiz = new calculadora_cientifica("Raiz", "6");
    calculadora_cientifica calc_modulo = new calculadora_cientifica("Modulo", "7");
    calculadora_cientifica calc_logaritmo = new calculadora_cientifica("Logaritmo", "8");
    Console.WriteLine("Ingrese el primer valor");
    int a = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el segundo valor");
    int b = int.Parse(Console.ReadLine());
    Console.WriteLine("Suma: {0}", calc_suma.Sumar(a, b));
    Console.WriteLine("Resta: {0}", calc_resta.Restar(a, b));
    Console.WriteLine("Multiplicacion: {0}", calc_multiplicacion.Multiplicar(a, b));
    Console.WriteLine("Division: {0}", calc_division.Dividir(a, b));
    Console.WriteLine("Potencia: {0}", calc_potencia.Potencia(a, b));
    Console.WriteLine("Raiz: {0}", calc_raiz.Raiz(a));
    Console.WriteLine("Modulo: {0}", calc_modulo.Modulo(a));
    Console.WriteLine("Logaritmo: {0}", calc_logaritmo.Logaritmo(a));
  }
}

