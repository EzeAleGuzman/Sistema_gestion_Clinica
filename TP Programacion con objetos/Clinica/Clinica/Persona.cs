/*
 * Created by SharpDevelop.
 * User: Sarabe89
 * Date: 18/10/2025
 * Time: 20:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Clinica
{
	/// <summary>
	/// Description of Persona.
	/// </summary>
	public abstract class Persona
	{
		public int dni;
		public  string nombreCompleto;
		public int edad;
		
		
		public Persona(int dni, string nombreCompleto, DateTime fechaNacimiento)
		{
			this.dni = dni;
			this.nombreCompleto = nombreCompleto;
			this.fechaNacimiento = fechaNacimiento;
		}
		
		public int CalcularEdad()
		{
			DateTime hoy = DateTime.Today;
				
			///Asigna a la varieble edad el valor del resto entre el año actual y el año de nacimiento
			int edad = hoy.Year - fechaNacimiento.Year;
			///Verifica El mes , como tambien el dia de cumpleaños para calcular la edad
			if (hoy.Month < fechaNacimiento.Month || (hoy.Month == fechaNacimiento.Month && hoy.Day < fechaNacimiento.Day))
			{
				    edad--;
			}
			return edad;
		}
		
		//se encargara de en las clases hijas agregar las consultas en estado realizado
		public virtual void agregarConsulta(Consulta consulta)
		{
		}
		
		//agregara las consultas a estado pendiente
		public virtual void agregarPendientes(Consulta consulta)
		{
		}
	}
}
