
using System;
using System.Collections.Generic;

namespace Clinica
{
	/// <summary>
	/// Description of Area.
	/// </summary>
	public class Area
	{
		public int id;
		public string nombre;
		public List<Profesional> profesionales;
		
		public Area(int id, string nombre, List<Profesional> profesionales)
		{
			this.id = id;
			this.nombre = nombre;
			this.profesionales = profesionales;
		}
		
		public Area(int id, string nombre)
		{
			this.id = id;
			this.nombre = nombre;
			profesionales = new List<Profesional>();
		}

		public void AgregarProfesionalArea(Profesional profesional){
			profesionales.add(profesiona);
		}

		public void EliminarProfesional(Profesional profesional){
			profesionales.delete(profesional);
		}

		public void MostrarProfesionales(){
			try{
				if (profesionales == null) {
					throw new Exception();
					//trow new NoHayProfesionalesExeption(); lo dejo asi para hacerlo mas adelante
				}
				
				Console.WriteLine("Informacion De los profesionales");

				foreach(Profesional profesional in profesionales){
					Console.WriteLine("ID: {0}", id);
					Console.WriteLine("Nombre:  {0}", nombre);
					Console.WriteLine("Area: {0}", area);
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

