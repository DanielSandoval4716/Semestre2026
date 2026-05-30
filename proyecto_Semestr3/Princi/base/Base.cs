using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System;

namespace Princi;

public class Base
{
    private string _conexion = "Data Source=/home/fist/ra/codes/proyecto_Semestr3/Princi/base/base.db";
    //login
    public bool Regis(string usuario, string password, string rol)
    {
        try
        {
            using var con = new SqliteConnection(_conexion);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Usuarios (Usuario, Password, Rol) VALUES ($u, $p, $r)";
            cmd.Parameters.AddWithValue("$u", usuario);
            cmd.Parameters.AddWithValue("$p", password);
            cmd.Parameters.AddWithValue("$r", rol);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch { return false; }
    }
    public (int id, string rol, string usuario)? Log(string usuario, string password)
    {
        using var con = new SqliteConnection(_conexion);
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = "SELECT Id, Rol, Usuario FROM Usuarios WHERE Usuario=$u AND Password=$p";
        cmd.Parameters.AddWithValue("$u", usuario);
        cmd.Parameters.AddWithValue("$p", password);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
            return ((int)(long)reader["Id"], (string)reader["Rol"], (string)reader["Usuario"]);
        return null;
    }
    //login
    ////alumnos
    public List<CursoAlumno> CursosAl(int alumnoId)
    {
        var cursos = new List<CursoAlumno>();
        using var con = new SqliteConnection(_conexion);
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = @"
            SELECT C.Nombre, AC.Punteo, M.Usuario as Maestro
            FROM AlumnoCurso AC
            JOIN Cursos C ON C.Id = AC.CursoId
            JOIN Usuarios M ON M.Id = C.MaestroId
            WHERE AC.AlumnoId = $a
        ";
        cmd.Parameters.AddWithValue("$a", alumnoId);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            cursos.Add(new CursoAlumno { Nombre = (string)reader["Nombre"], Punteo = (double)reader["Punteo"], Maestro = (string)reader["Maestro"] });
        return cursos;
    }
    public double Promedio(int alumnoId)
    {
        using var con = new SqliteConnection(_conexion);
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = "SELECT AVG(Punteo) FROM AlumnoCurso WHERE AlumnoId = $a";
        cmd.Parameters.AddWithValue("$a", alumnoId);
        var resultado = cmd.ExecuteScalar();
        return resultado is DBNull ? 0 : (double)resultado;
    }
    //alumnos
    //maestro
    public List<Curso> ObtenerCursosMaestro(int maestroId)
    {
        var lista = new List<Curso>();
        using var con = new SqliteConnection(_conexion);
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = "SELECT Id, Nombre FROM Cursos WHERE MaestroId = $m";
        cmd.Parameters.AddWithValue("$m", maestroId);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            lista.Add(new Curso { Id = (int)(long)reader["Id"], Nombre = (string)reader["Nombre"] });
        return lista;
    }
    public List<Usuario> ObtenerAlumnos()
    {
        var lista = new List<Usuario>();
        using var con = new SqliteConnection(_conexion);
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = "SELECT Id, Usuario FROM Usuarios WHERE Rol = 'Alumno'";
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            lista.Add(new Usuario { Id = (int)(long)reader["Id"], Nombre = (string)reader["Usuario"] });
        return lista;
    }
    public bool CrearCurso(string nombre, int maestroId)
    {
        try
        {
            using var con = new SqliteConnection(_conexion);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Cursos (Nombre, MaestroId) VALUES ($n, $m)";
            cmd.Parameters.AddWithValue("$n", nombre);
            cmd.Parameters.AddWithValue("$m", maestroId);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch { return false; }
    }
    public bool AsignarAlumno(int alumnoId, int cursoId)
    {
        try
        {
            using var con = new SqliteConnection(_conexion);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO AlumnoCurso (AlumnoId, CursoId, Punteo) VALUES ($a, $c, 0)";
            cmd.Parameters.AddWithValue("$a", alumnoId);
            cmd.Parameters.AddWithValue("$c", cursoId);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch { return false; }
    }
    public bool GuardarNota(int alumnoId, int cursoId, double nota)
    {
        try
        {
            using var con = new SqliteConnection(_conexion);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE AlumnoCurso SET Punteo = $p WHERE AlumnoId = $a AND CursoId = $c";
            cmd.Parameters.AddWithValue("$p", nota);
            cmd.Parameters.AddWithValue("$a", alumnoId);
            cmd.Parameters.AddWithValue("$c", cursoId);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch { return false; }
    }
    public List<CursoAlumno> ObtenerAlumnosCurso(int cursoId)
    {
        var lista = new List<CursoAlumno>();
        using var con = new SqliteConnection(_conexion);
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = @"
            SELECT U.Usuario, AC.Punteo, M.Usuario as Maestro
            FROM AlumnoCurso AC
            JOIN Usuarios U ON U.Id = AC.AlumnoId
            JOIN Cursos C ON C.Id = AC.CursoId
            JOIN Usuarios M ON M.Id = C.MaestroId
            WHERE AC.CursoId = $c
        ";
        cmd.Parameters.AddWithValue("$c", cursoId);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            lista.Add(new CursoAlumno { Nombre = (string)reader["Usuario"], Punteo = Convert.ToDouble(reader["Punteo"]), Maestro = (string)reader["Maestro"] });
        return lista;
    }
}
//maestro
public class CursoAlumno
{
    public string Nombre { get; set; } = "";
    public double Punteo { get; set; }
    public string Maestro { get; set; } = "";
}
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public override string ToString()
    {
        return Nombre;
    }
}
public class Curso
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public override string ToString()
    {
        return Nombre;
    }
}
