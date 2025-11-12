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

namespace Clinica
{
	/// <summary>
	/// Description of Especialista.
	/// </summary>
	public class Especialista:Profesional
	{
		public int Id;
		public double honorarios = 8500;
		public int maxPacientesDia = 6;
		public string tipo = "especialista";
		
		public Especialista( string nombre, ManejoArchivos archivo):base(nombre)
		{	
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.Combine(basePath, @"..\..");
			string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Profesionales.csv"));
			//Genera el Id por medio de la funcion generadorA
			Id = archivo.GenerarId(path);
			AgregarProfesional(archivo);
		}

		

		public override  void AgregarProfesional(ManejoArchivos archivo)
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
