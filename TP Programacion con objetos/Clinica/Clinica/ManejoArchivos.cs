/*
 * Created by SharpDevelop.
 * User: Sarabe89
 * Date: 3/11/2025
 * Time: 20:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
namespace Clinica
{
	/// <summary>
	/// Description of ManejoArchivos.
	/// </summary>
	public class ManejoArchivos
	{
		
		public ManejoArchivos()
		{
			  if (File.Exists("A:/POO/TP Programacion con objetos/Clinica/Pacientes.csv") && File.Exists("A:/POO/TP Programacion con objetos/Clinica/Profesionales.csv") && File.Exists("A:/POO/TP Programacion con objetos/Clinica/Areas.csv") )
            {
                Console.WriteLine("Base de datos Encontrada");
                Console.WriteLine("Cargando Archivos...");
            }
            else
            {
                Console.WriteLine("No se Encontro Base de datos Anterior. Generando nueva BD...");
                File.Create("A:/POO/TP Programacion con objetos/Clinica/Pacientes.csv");
               	File.Create("A:/POO/TP Programacion con objetos/Clinica/Profesionales.csv");
               	File.Create("A:/POO/TP Programacion con objetos/Clinica/Areas.csv").Close();
            }
		}
	}
}
