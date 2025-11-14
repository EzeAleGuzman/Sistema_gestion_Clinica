
using System;
using System.Collections.Generic;
using System.IO;
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
		
		public Paciente(string nombreCompleto,int DNI, int edad,string obraSocial,  ManejoArchivos archivo, bool guardar = true)
		{
			this.nombreCompleto = nombreCompleto;
			this.DNI = DNI;
			this.edad = edad;
			this.obraSocial = obraSocial;
			historialConsultas = new List<Consulta>();
			consultasPendientes = new List<Consulta>();
			//Tener el almacenamiento en el constructor no es lo optimo, pero nos facilita la persistencia 
			if (guardar)
				AgregarPacienteBD(archivo);
		}
		
		//funcion para almacenarlo en la base de datos
		public  void AgregarPacienteBD(ManejoArchivos archivo)
		{
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.Combine(basePath, @"..\..");
			string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Pacientes.csv"));
			string nuevaLinea = string.Format("{0};{1};{2};{3}",nombreCompleto, DNI, edad, obraSocial);
			File.AppendAllText(path, Environment.NewLine + nuevaLinea);
			Console.WriteLine("Objeto Almacenado en base de datos");
		}
		
		//Para poder visualizar la clase
		public override string ToString()
		{
			return string.Format("Paciente \n NombreCompleto={0}\n DNI={1}\n Edad={2}\n ObraSocial={3}\n ", nombreCompleto, DNI, edad, obraSocial);
		}

		
		//El metodo Puede mostrar los 2 tipos de consulta(Podriamos reutilizarlo en profesionales y llevarlo a un archivo de utilidades????
		/*public void MostrarHistorialConsultas(List<Consulta> listaConsultas)
		{
			foreach (Consulta consulta in listaConsultas)
			{
				return
			}
		}*/
	}
}
