using System;
using System.Collections.Generic;
using System.IO;
namespace Clinica
{
	/// <summary>
	/// Description of Profesional.
	/// </summary>
public abstract class Profesional
{
    public int Id;
    public string nombre;
    public double honorarios;
    public int tiempoConsulta;
    public int maxPacientesDia;
    public string tipo;
    public ManejoArchivos archivo;
    public List<Consulta> listadoConsultasPendientes;
    public List<Consulta> listadoAtencion;

    // Constructor para cargar desde CSV
    public Profesional(int id, string nombre)
    {
        this.Id = id;
        this.nombre = nombre;

        listadoConsultasPendientes = new List<Consulta>();
        listadoAtencion = new List<Consulta>();
    }

    // Constructor para crear por primera vez un profesional
    public Profesional(string nombre, ManejoArchivos archivo)
    {
        this.archivo = archivo;

        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string projectPath = Path.Combine(basePath, @"..\..");
        string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Profesionales.csv"));

        this.Id = archivo.GenerarId(path);
        this.nombre = nombre;

        listadoConsultasPendientes = new List<Consulta>();
        listadoAtencion = new List<Consulta>();
    }

    public abstract void AgregarProfesionalBD(ManejoArchivos archivo);

    public abstract void AtenderPacientes(Consulta consulta);

    public abstract double Calcularcosto();
}
}