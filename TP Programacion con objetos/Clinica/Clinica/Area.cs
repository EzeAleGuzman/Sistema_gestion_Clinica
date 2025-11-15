
using System;
using System.Collections.Generic;
using System.IO;

namespace Clinica
{
	/// <summary>
	/// Description of Area.
	/// </summary>
	public class Area
	{
		public int Id;
		public string nombre;
		public List<Profesional> profesionales;
		
		
		
		public Area( string nombre,ManejoArchivos archivo, bool guardar = true)
		{		
			this.nombre = nombre;
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.Combine(basePath, @"..\..");
			string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Areas.csv"));
			//Genera el Id por medio de la funcion generadorA
			Id = archivo.GenerarId(path);
			profesionales = new List<Profesional>();
			if (guardar)
				AgregarArealBD(archivo);
		}
		
		public  void AgregarArealBD(ManejoArchivos archivo)
		{
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.Combine(basePath, @"..\..");
			string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Areas.csv"));
			string nuevaLinea = string.Format("{0};{1}", Id, nombre);
			File.AppendAllText(path, Environment.NewLine + nuevaLinea);
			Console.WriteLine("Objeto Almacenado en base de datos");
		}
		
		public override string ToString()
		{
			return string.Format("Area Nombre={0}", nombre);
		}


		public void AgregarProfesionalArea(Profesional profesional){
			profesionales.Add(profesional);
		}

		public void EliminarProfesionalDelArea(Profesional profesional){
			profesionales.Remove(profesional);
		}

		public void MostrarProfesionalesDelArea(){
			try{
				if (profesionales == null) {
					throw new Exception();
					//trow new NoHayProfesionalesExeption(); lo dejo asi para hacerlo mas adelante
				}
				if (profesionales.Count == 0)
					Console.WriteLine("No hay profesionales Agregados al Area");
				else 
					Console.WriteLine("Informacion De los profesionales");
	
					foreach(Profesional profesional in profesionales){
						Console.WriteLine("Nombre:  {0}", profesional.nombre);
						Console.WriteLine("Area: {0}", nombre);
						Console.WriteLine("");
					};

            }
            catch (Exception n)
            {
				Console.WriteLine(n.Message);
            }
		}
	}


		
		
}

