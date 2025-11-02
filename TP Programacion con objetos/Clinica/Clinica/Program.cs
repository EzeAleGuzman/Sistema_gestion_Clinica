/*
 * Created by SharpDevelop.
 * User: Sarabe89
 * Date: 18/10/2025
 * Time: 20:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Clinica
{
	class Program
	{
		public static void Main(string[] args)
		{
			Persona ezequiel = new Persona(34931575,"Guzman Ezequiel",new DateTime(2026,10,19));
			
			Console.WriteLine(ezequiel.CalcularEdad());
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}