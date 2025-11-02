
using System;
using System.Collections.Generic;
namespace Clinica
{
	#Defino las constantes de tipos de consultas
	public enum tipo_consulta
	{
		Generica,
		Especial
	}
	
	public enum prioridad_medica
	{
		NoUrgente,
		Urgente
	}
	/// <summary>
	/// Description of Consulta.
	/// </summary>
	public class Consulta
	{
		public tipo_consulta tipo;
		public prioridad_medica prioridad;
		public Paciente paciente;
		public Profesional profesional;
		public decimal costo;
		
		public Consulta()
		{
		}
	}
}
