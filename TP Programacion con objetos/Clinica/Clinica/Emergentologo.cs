/*
 * Created by SharpDevelop.
 * User: Sarabe89
 * Date: 6/11/2025
 * Time: 08:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace Clinica
{
	/// <summary>
	/// Description of Emergentologo.
	/// </summary>
	public class Emergentologo:Profesional
	{
		public int Id;
		public double honorarios = 10000;
		public int maxPacientesDia = 8;
		public string tipo = "emergentologo";
		
	

		
		public Emergentologo( string nombre, ManejoArchivos archivo, bool guardar = true):base(nombre)
		{	
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.Combine(basePath, @"..\..");
			string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Profesionales.csv"));
			//Genera el Id por medio de la funcion generadorA
			Id = archivo.GenerarId(path);
			if (guardar)
				AgregarProfesionalBD(archivo);
		}

		public override void AtenderPacientes(Consulta consulta){
			if (listadoConsultasPendientes.Count < 9) {
				listadoConsultasPendientes.Add(consulta);
			}
			else {
				Console.WriteLine("Se ha alcanzado el máximo de pacientes a atender por parte de este profesional");
			}
		}

		public override double Calcularcosto() {
			return listadoConsultasPendientes.Count * honorarios;
		}

			//funcion para almacenarlo en la base de datos
		public override  void AgregarProfesionalBD(ManejoArchivos archivo)
		{
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.Combine(basePath, @"..\..");
			string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Profesionales.csv"));
			string nuevaLinea = string.Format("{0};{1};{2};{3};{4}", Id, nombre, tipo, honorarios, maxPacientesDia);
			File.AppendAllText(path, Environment.NewLine + nuevaLinea);
			Console.WriteLine("Objeto Almacenado en base de datos");
		}
	}

	
}
