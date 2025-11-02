
using System;
using System.Collections.Generic;

namespace Clinica
{
	/// <summary>
	/// Description of Pacientes.
	/// </summary>
	public class Paciente
	{
		public string obraSocial;
		public int DNI;
		public int edad;
		public string obraSocial
		public List<Consulta> historialConsultas;
		public List<Consulta> consultasPendientes; 
		
		public Paciente(int dni, string nombreCompleto,int edad,string obraSocial)
		{
			this.obraSocial = obraSocial;
			historialConsultas = new List<Consulta>();
			consultasPendientes = new List<Consulta>();
		}
		
	}
}
