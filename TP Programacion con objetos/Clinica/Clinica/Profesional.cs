using System;
using System.Collections.Generic;

namespace Clinica
{
	/// <summary>
	/// Description of Profesional.
	/// </summary>
	public abstract class Profesional
	{
		
		public string nombre;
		public List<Consulta> listadoConsultasPendientes;
		public List<Consulta> listadoAtencion;
		
		
		public Profesional(string nombre)
		{
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
		
		public abstract  void AgregarProfesional(ManejoArchivos archivo);
		
		public abstract void AtenderPacientes(Consulta consulta);
		
		public abstract double Calcularcosto();
		
	}
}
