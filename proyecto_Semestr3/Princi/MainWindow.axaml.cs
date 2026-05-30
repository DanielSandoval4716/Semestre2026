using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.Generic;
using System.Linq;

namespace Princi;

public partial class MainWindow : Window
{
    Base _db = new Base();
    private bool md_regis = false;
    private int alId;
    private int maestroId;
    private Dictionary<string, CursoAlumno> dicCursos = new();
    private Dictionary<string, CursoAlumno> dicAlumnos = new();
    public MainWindow()
    {
        InitializeComponent();
    }
    //Login
    private void mostrar_regis(object sender, RoutedEventArgs e)
    {
        md_regis = !md_regis;
        rolsel.IsVisible = md_regis;
        btnRegistro.Content = md_regis ? "Cancelar" : "Registrarse";
        lblMensaje.Text = "";
    }
    private void Log(object sender, RoutedEventArgs e)
    {
        string usr = tusr.Text ?? "";
        string pass = tpass.Text ?? "";
        if (string.IsNullOrWhiteSpace(usr) || string.IsNullOrWhiteSpace(pass))
        {
            MostrarError("Completa todos los campos");
            return;
        }
        var sario = _db.Log(usr, pass);
        if (sario == null)
        {
            MostrarError("Usuario o contraseña incorrectos");
            return;
        }
        if (sario.Value.rol == "Alumno")
        {
            alId = sario.Value.id;
            meAl.Text = $"Bienvenido, {sario.Value.usuario}!";
            CarCursos();
            most("alumno");
        }
        else if (sario.Value.rol == "Maestro")
        {
            maestroId = sario.Value.id;
            meMa.Text = $"Bienvenido maestro {sario.Value.usuario}!";
            CargarCursos();
            CargarAlumnos();
            most("maestro");
        }
    }
    private void Reg(object sender, RoutedEventArgs e)
    {
        string usr = tusr.Text ?? "";
        string pass = tpass.Text ?? "";
        string rol = rbMaestro.IsChecked == true ? "Maestro" : "Alumno";
        if (string.IsNullOrWhiteSpace(usr) || string.IsNullOrWhiteSpace(pass))
        {
            MostrarError("Completa todos los campos");
            return;
        }
        if (_db.Regis(usr, pass, rol))
        {
            lblMensaje.Text = $"Registrado como {rol}";
            rolsel.IsVisible = false;
            md_regis = false;
            btnRegistro.Content = "Registrarse";
        }
        else
        {
            MostrarError("Ese usuario ya existe");
        }
    }
    //alumno
    private void CarCursos()
    {
        var cursos = _db.CursosAl(alId);
        dicCursos.Clear();
        foreach (var curso in cursos)
            dicCursos[curso.Nombre] = curso;
        dgCursos.ItemsSource = cursos;
        txtBC.Text = "";
        double prom = _db.Promedio(alId);
        txtProm.Text = $"Promedio: {prom:F2}";
    }
    //alumno
    //buscador
    private void Buscar(TextBox txtBusca, Dictionary<string, CursoAlumno> dic, ListBox lista)
    {
        string busq = txtBusca.Text?.ToLower() ?? "";
        if (string.IsNullOrWhiteSpace(busq))
        {
            lista.ItemsSource = dic.Values.ToList();
            return;
        }
      var resultados = new List<CursoAlumno>();
      foreach (var coso in dic.Values)
      {
          if (coso .Nombre.ToLower().Contains(busq))
              resultados.Add(coso );
      }
      lista.ItemsSource = resultados;
    }
    private void BuscCursos(object sender, TextChangedEventArgs e)
    {
        Buscar(txtBC, dicCursos, dgCursos);
    }
    private void LimpCursos(object sender, RoutedEventArgs e)
    {
        LimpiarBusca(txtBC, dicCursos, dgCursos);
    }
    private void BuscAlumnos(object sender, TextChangedEventArgs e)
    {
        Buscar(txtBA, dicAlumnos, dgAlumnosCurso);
    }
    private void LimpAlumnos(object sender, RoutedEventArgs e)
    {
        LimpiarBusca(txtBA, dicAlumnos, dgAlumnosCurso);
    }
    private void LimpiarBusca(TextBox txtBusca, Dictionary<string, CursoAlumno> dic, ListBox lista)
    {
        txtBusca.Text = "";
        lista.ItemsSource = dic.Values.ToList();
    }
    //buscador
    //Maestro
    private void CargarCursos()
    {
        cmbCursos.ItemsSource = _db.ObtenerCursosMaestro(maestroId);
    }
    private void CargarAlumnos()
    {
        cmbAlumnos.ItemsSource = _db.ObtenerAlumnos();
    }
    private void CrearCurso(object sender, RoutedEventArgs e)
    {
        string nombre = txtCurso.Text ?? "";
        if (string.IsNullOrWhiteSpace(nombre))
        {
            MostrarError("Escribe el nombre del curso");
            return;
        }
        if (_db.CrearCurso(nombre, maestroId))
        {
            lblMensaje.Foreground = Avalonia.Media.Brushes.Green;
            lblMensaje.Text = "✓ Curso creado";
            txtCurso.Text = "";
            CargarCursos();
        }
        else
        {
            MostrarError("Error al crear curso");
        }
    }
    private void CargarAlumnosCurso(int cursoId)
    {
        var alumnos = _db.ObtenerAlumnosCurso(cursoId);
        dicAlumnos.Clear();
        foreach (var alumno in alumnos)
            dicAlumnos[alumno.Nombre] = alumno;
        dgAlumnosCurso.ItemsSource = alumnos;
        txtBA.Text = "";
    }
    private void AsignarAlumno(object sender, RoutedEventArgs e)
    {
        var alumno = cmbAlumnos.SelectedItem as Usuario;
        var curso = cmbCursos.SelectedItem as Curso;
        if (alumno == null)
        {
            MostrarError("Selecciona un alumno");
            return;
        }
        if (curso == null)
        {
            MostrarError("Selecciona un curso");
            return;
        }
        if (_db.AsignarAlumno(alumno.Id, curso.Id))
        {
            lblMensaje.Foreground = Avalonia.Media.Brushes.Green;
            lblMensaje.Text = "✓ Alumno asignado";
            CargarAlumnosCurso(curso.Id);
        }
        else
        {
            MostrarError("El alumno ya está en este curso");
        }
    }
    private void GuardarNota(object sender, RoutedEventArgs e)
    {
        var alumno = cmbAlumnos.SelectedItem as Usuario;
        var curso = cmbCursos.SelectedItem as Curso;
        if (alumno == null || curso == null)
        {
            MostrarError("Selecciona alumno y curso");
            return;
        }
        if (!double.TryParse(txtNota.Text, out double nota))
        {
            MostrarError("Escribe un número válido");
            return;
        }
        if (nota < 0 || nota > 100)
        {
            MostrarError("El punteo debe estar entre 0 y 100");
            return;
        }
        if (_db.GuardarNota(alumno.Id, curso.Id, nota))
        {
            lblMensaje.Foreground = Avalonia.Media.Brushes.Green;
            lblMensaje.Text = "Punteo guardado";
            txtNota.Text = "";
            CargarAlumnosCurso(curso.Id);
        }
        else
        {
            MostrarError("Error al guardar punteo");
        }
    }
    private void VerCurso(object sender, RoutedEventArgs e)
    {
        var curso = cmbCursos.SelectedItem as Curso;
        if (curso == null)
        {
            MostrarError("Selecciona un curso");
            return;
        }
        CargarAlumnosCurso(curso.Id);
    }
    private void MostrarError(string msg)
    {
        lblMensaje.Foreground = Avalonia.Media.Brushes.Red;
        lblMensaje.Text = msg;
    }
    private void cerr_ses(object sender, RoutedEventArgs e)
    {
        tusr.Text = "";
        tpass.Text = "";
        lblMensaje.Text = "";
        most("login");
    }
    private void most(string panel)
    {
        login.IsVisible = panel == "login";
        panelAlumno.IsVisible = panel == "alumno";
        panelMaestro.IsVisible = panel == "maestro";
    }
}
