using System;
using System.Collections.Generic;

namespace Clinica
{
	/// <summary>
	/// Description of Profesional.
	/// </summary>
	public abstract class Profesional
	{
		public int id;
		public string nombre;
		public List<Consulta> listadoConsultasPendientes;
		public List<Consulta> listadoAtencion;
		
		
		public Profesional(int id,string nombre)
		{
			this.id = id;
			this.nombre = nombre;
			listadoConsultasPendientes = new List<Consulta>();
			listadoAtencion = new List<Consulta>();
		}
		
		//se encargara de en las clases hijas agregar las consultas en estado realizado
		/*
		public abstract void AtenderPacientes(Consulta consulta)
		{		
			listadoConsultasPendientes.Add(consulta);
		}
		
		public abstract double Calcularcosto();*/
		
	}
}
