using System;
using System.Collections.Generic;
namespace Clinica
{
	//Defino las constantes de tipos de consultas
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
		public int id;
		public Paciente paciente;
		public Profesional profesional;
		public tipo_consulta tipo;
		public prioridad_medica prioridad;
		public decimal costo;
		public int duracion;
		public DateTime fecha;
		
		
//		Constructor 	
		public Consulta(int id, Paciente paciente, Profesional profesional, tipo_consulta tipo, prioridad_medica prioridad, int duracion, DateTime fecha)
		{
			this.id = id;
			this.paciente = paciente;
			this.profesional = profesional;
			this.tipo = tipo; 
			this.prioridad = prioridad;
			this.costo = profesional.Calcularcosto(); //calculo a partir de profesional
			this.duracion = duracion;
			this.fecha = fecha;
		}
		
//		Métodos
		
		public void MostrarDetalle()
		{
			Console.WriteLine("Consulta n°: {0}", id);
			Console.WriteLine("Paciente: {0}", paciente.nombreCompleto);
			Console.WriteLine("Profesional: {0}", profesional.nombre);
			Console.WriteLine("Tipo de consulta: {0}", tipo);
			Console.WriteLine("Duración de la consulta: {0} minutos", duracion);
			Console.WriteLine("Costo: ${0}", costo);
		}
	}
}
