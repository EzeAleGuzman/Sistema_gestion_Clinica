
using System;
using System.Collections.Generic;

namespace Clinica
{
	/// <summary>
	/// Description of Pacientes.
	/// </summary>
	public class Paciente
	{
		public string nombreCompleto;
		public int DNI;
		public int edad;
		public string obraSocial;
		public List<Consulta> historialConsultas;
		public List<Consulta> consultasPendientes; 
		
		public Paciente(string nombreCompleto,int DNI, int edad,string obraSocial)
		{
			this.edad = edad;
			this.DNI = DNI;
			this.edad = edad;
			this.obraSocial = obraSocial;
			historialConsultas = new List<Consulta>();
			consultasPendientes = new List<Consulta>();
		}
		
		#El metodo Puede mostrar los 2 tipos de consulta(Podriamos reutilizarlo en profesionales y llevarlo a un archivo de utilidades????
		public void MostrarHistorialConsultas(List listaConsultas)
		{
			foreach (consulta in listaConsultas)
			{
				MostrarConsulta(consulta)
			}
		}
	}
}
