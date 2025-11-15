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
	    /*public List<Consulta> consultas*/ 

    	private ManejoArchivos archivos;
		
		public Clinica(ManejoArchivos archivos)
		{
			this.archivos = archivos;
			
			pacientes = CargarPacientes();
			profesionales = CargarProfesionales();
			areas = CargarAreas();
			
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
		    	//Dependiendo el tipo de profesional invoco a distinto constructor
		    	if (f[2] == "espacialista")
		    	{
		    		lista.Add(new Especialista(
		    			nombre : f[1],
		    			archivo: archivos,
		    			guardar: false));
		    	}
		    	else if (f[2] == "emergentologo")
		    	{
		    		lista.Add(new Emergentologo(
		    			nombre : f[1],
		    			archivo: archivos,
		    			guardar: false));
		    	}
		    	else 
		    	{
		    		lista.Add(new MedicoClinico(
		    			nombre : f[1],
		    			archivo: archivos,
		    			guardar: false));
		    	}
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
		
		public void MostrarAreas(List<Area> areas)
		{
			foreach (Area area in areas)
			{
				Console.WriteLine(area);
			}
			if (pacientes.Count < 1)
			{
				Console.WriteLine("No hay Areas en la base de datos");
			}
		}
		
		public void BuscarPaciente(List<Paciente> list, int DNI)
		{
			foreach (Paciente p in list)
			{
				if (p.DNI == DNI)
				{
				}
			}
		}
	}
}
