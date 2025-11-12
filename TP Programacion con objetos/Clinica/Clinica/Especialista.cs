/*
 * Created by SharpDevelop.
 * User: Sarabe89
 * Date: 6/11/2025
 * Time: 08:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Clinica
{
	/// <summary>
	/// Description of Especialista.
	/// </summary>
	public class Especialista:Profesional
	{
		
		public double honorarios = 8500;
		public int maxPacientesDia = 6;
		
		public Especialista(int id, string nombre, double honorarios, int maxPacientesDia):base(id, nombre)
		{
			this.honorarios = honorarios;
			this.maxPacientesDia = maxPacientesDia;
		}

		public override void AtenderPacientes(Consulta consulta){
			if (listadoConsultasPendientes.count < 7) {
				listadoConsultasPendientes.Add(consulta)
			}
			else {
				Console.WriteLine("Se ha alcanzado el máximo de pacientes a atender por parte de este profesional");
			}

		public override double Calcularcosto() {
			return listadoConsultasPendientes.count * honorarios;
		}	
	}
}
