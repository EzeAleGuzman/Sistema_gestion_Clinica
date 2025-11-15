/*
 * Created by SharpDevelop.
 * User: Sarabe89
 * Date: 6/11/2025
 * Time: 08:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace Clinica
{
	/// <summary>
	/// Description of MedicoClinico.
	/// </summary>
	public class MedicoClinico:Profesional
	{
		
		public int Id;
		public double honorarios = 5000;
		public int maxPacientesDia = 10;
		public string tipo = "clinico";
		
		public MedicoClinico( string nombre, ManejoArchivos archivo, bool guardar = true):base(nombre)
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
			if (listadoConsultasPendientes.Count < 11) {
				listadoConsultasPendientes.Add(consulta);
			}
			else {
				Console.WriteLine("Se ha alcanzado el máximo de pacientes a atender por parte de este profesional");
			}
		}

		public override double Calcularcosto() {
			return listadoConsultasPendientes.Count * honorarios;
		}
		
		//Para poder visualizar la clase
		public override string ToString()
		{
			return string.Format("Profesional \n Nombre={0}\n honorarios={1}\n maxPacientesDia={2}\n Especialidad={3}\n ", nombre, honorarios, maxPacientesDia, tipo);
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
