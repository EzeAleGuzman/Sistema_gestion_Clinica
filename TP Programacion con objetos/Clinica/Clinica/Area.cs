
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
		
		public Area()
		{
		}
		
		public Area(int id, string nombre)
		{
			this.id = id;
			this.nombre = nombre;
			this.profesionales = new List<Profesional>();
		}
		
		
	}
}
