using System;
using System.Collections.Generic;

namespace Clinica
{
	/// <summary>
	/// Description of Profesional.
	/// </summary>
	public  abstract class Profesional
	{
		public int id;
		public string nombre;
		public Area area;
		public List<Consulta> historialConsultas;
		public List<Consulta> consultasPendientes;
		
		
		public Profesional(int id,string nombre,Area area)
		{
			this.id = id;
			this.nombre = nombre;
			historialConsultas = new List<Consulta>();
			consultasPendientes = new List<Consulta>();
		}
		
		//se encargara de en las clases hijas agregar las consultas en estado realizado
		/*public abstract void agregarConsulta(Consulta consulta)
		{			
		}
		
		//agregara las consultas a estado pendiente
		public abstract void agregarPendientes(Consulta consulta)
		{		
		}
		
		public abstract double Calcularcosto()
		{
		
		}*/
		
	}
}
