using System.Text.RegularExpressions;
class Programa
{
  MatchCollection separar_correos(string texto) {
    string patron = @"[\w\.\-]+@[\w\.\-]+\.[\w\.\-]+";
    ///w letras y numeros, + uno o mas, * cero o mas, \. punto, /- guion
    return Regex.Matches(texto, patron);
  }
  static void Main(string[] args)
  {
    Console.WriteLine("ingrese el texto: ");
    string texto = Console.ReadLine();
    Programa p = new Programa();
    MatchCollection mc = p.separar_correos(texto);
    foreach (Match m in mc) {
      Console.WriteLine(m.Value);
    }
  }
}
