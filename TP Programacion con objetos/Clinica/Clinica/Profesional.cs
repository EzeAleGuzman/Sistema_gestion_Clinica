/*
 * Created by SharpDevelop.
 * User: Sarabe89
 * Date: 18/10/2025
 * Time: 20:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
		public List<Consulta> historialConsultas;
		public List<Consulta> consultas Pendientes;
		
		
		public Profesional(int dni, string nombreCompleto, DateTime fechaNacimiento, int id):base(dni, nombreCompleto, fechaNacimiento)
		{
			this.id = id;
			historialConsultas = new List<Consulta>();
			consultasPendientes = new List<Consulta>();
		}
		
		//se encargara de en las clases hijas agregar las consultas en estado realizado
		public abstract void agregarConsulta(Consulta consulta)
		{			
		}
		
		//agregara las consultas a estado pendiente
		public abstract void agregarPendientes(Consulta consulta)
		{		
		}
		
		public virtual 
		
	}
}
