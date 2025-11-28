/*
 * Created by SharpDevelop.
 * User: Sarabe89
 * Date: 13/11/2025
 * Time: 21:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Clinica
{
	/// <summary>
	/// Description of Clinica.
	/// </summary>
	public class Clinica
	{
		
		public List<Paciente> pacientes;
	    public List<Profesional> profesionales;
	    public List<Area> areas;
	    public List<Consulta> consultas;
    	private ManejoArchivos archivos;
		
		public Clinica(ManejoArchivos archivos)
		{
			this.archivos = archivos;
			
			pacientes = CargarPacientes();
			profesionales = CargarProfesionales();
			areas = CargarAreas();
			consultas = CargarConsultas();
			
		}
		
		//Metodos gestionar lista de pacientes
		private List<Paciente> CargarPacientes()
		{
		    var lista = new List<Paciente>();
		    string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.Combine(basePath, @"..\..");
			string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Pacientes.csv"));
		    var filas = archivos.LeerCsv(path);
		
		    foreach (var f in filas)
		    {
		        lista.Add(new Paciente(
		            nombreCompleto: f[0],
		            DNI: int.Parse(f[1]),
		            edad: int.Parse(f[2]),
		            obraSocial: f[3],
		            archivo: archivos,
		           	guardar: false
		        ));
		    }
		
		    return lista;
		}
		
		//private void Eliminarpacientebase()
		
		public void MostrarPacientes(List<Paciente> pacientes)
		{
			foreach (Paciente p in pacientes)
			{
				
				Console.WriteLine(p);
			}
			if (pacientes.Count < 1)
			{
				Console.WriteLine("No hay pacientes en la base de datos");
			}
		}
				
		//Metodos Gestion Lista Profesionales
		public List<Profesional> CargarProfesionales()
		{
		    var lista = new List<Profesional>();
		    string basePath = AppDomain.CurrentDomain.BaseDirectory;
		    string projectPath = Path.Combine(basePath, @"..\..");
		    string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Profesionales.csv"));
		    var filas = archivos.LeerCsv(path);
		
		    foreach (var f in filas)
		    {
		        // f[0] = ID
		        // f[1] = Nombre
		        // f[2] = Tipo
		        // f[3] = tiempo
		        // f[4] = honorarios
		        // f[5] = maxPacientesDia
		
		        int id = int.Parse(f[0]);
		        string nombre = f[1];
		        string tipo = f[2].ToLower();
		
		        Profesional p = null;
		
		       
		        if (tipo == "especialista")
		        {
		            p = new Especialista(nombre, archivos, false);
		        }
		        else if (tipo == "emergentologo")
		        {
		            p = new Emergentologo(nombre, archivos, false);
		        }
		        else // clínico
		        {
		            p = new MedicoClinico(nombre, archivos, false);
		        }
		
		        // *** LO MÁS IMPORTANTE ***
		        // Sobreescribimos el ID generado automáticamente
		        p.Id = id;
		
		        // Cargar los datos restantes del CSV
		        p.tiempoConsulta = int.Parse(f[3]);
		        p.honorarios = double.Parse(f[4]);
		        p.maxPacientesDia = int.Parse(f[5]);
		
		        lista.Add(p);
		    }
		
		    return lista;
		}
		
		public void MostrarProfesionales(List<Profesional> profesionales)
		{
			foreach (Profesional p in profesionales)
			{
				
				Console.WriteLine(p);
			}
			if (pacientes.Count < 1)
			{
				Console.WriteLine("No hay profesionales en la base de datos");
			}
		}
		
		
		public List<Area> CargarAreas()
		{
			var lista = new List<Area>();
		    string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.Combine(basePath, @"..\..");
			string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Areas.csv"));
		    var filas = archivos.LeerCsv(path);
		
		    foreach (var f in filas)
		    {
		        lista.Add(new Area(
		            nombre: f[1],
		            archivo: archivos,
		           	guardar: false
		        ));
		    }
		
		    return lista;
		}
		
		public void MostrarAreas()
		{
			foreach (Area area in CargarAreas())
			{
				Console.WriteLine(area.getNombre());
			}
			if (pacientes.Count < 1)
			{
				Console.WriteLine("No hay Areas en la base de datos");
			}
		}
		
		public List<Consulta> CargarConsultas()
		{
		    var lista = new List<Consulta>();
		
		    string basePath = AppDomain.CurrentDomain.BaseDirectory;
		    string projectPath = Path.Combine(basePath, @"..\..");
		    string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Consultas.csv"));
		
		    var filas = archivos.LeerCsv(path);
		
		    foreach (var f in filas)
		    {
		        // ----------------------------
		        // 1. Buscar PACIENTE
		        // ----------------------------
		        int dni = int.Parse(f[0]);
		        Paciente pacienteEncontrado = null;
		
		        foreach (Paciente pac in pacientes)
		        {
		            if (pac.DNI == dni)
		            {
		                pacienteEncontrado = pac;
		                break;
		            }
		        }
		        if (pacienteEncontrado == null)
		            continue;
		
		        // ----------------------------
		        // 2. Buscar PROFESIONAL por ID
		        // ----------------------------
		        int idProfesional = int.Parse(f[1]);
		        Profesional profesionalEncontrado = null;
		
		        foreach (Profesional prof in profesionales)
		        {
		            if (prof.Id == idProfesional)
		            {
		                profesionalEncontrado = prof;
		                break;
		            }
		        }
		        if (profesionalEncontrado == null)
		            continue;
		
		        // ----------------------------
		        // 3. Crear consulta
		        // ----------------------------
		        string prioridad = f[3];
		
		        Consulta consulta = new Consulta(
		            pacienteEncontrado,
		            prioridad,
		            profesionalEncontrado
		        );
		
		        consulta.duracionMinutos = profesionalEncontrado.tiempoConsulta;
		        consulta.costo = profesionalEncontrado.honorarios;
		        consulta.realizada = bool.Parse(f[6]);
		
		        lista.Add(consulta);
		    }
		
		    return lista;
		}

		
		public void MostrarConsultas()
	    {
			foreach (Consulta c in consultas)
	            {
	            	Console.WriteLine(c); 
	            }
	    }
	}
}
