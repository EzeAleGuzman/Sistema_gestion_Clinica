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

		public static void opciones_menu()
		{
			Console.WriteLine("Por favor, ingrese el número de la opción correspondiente para continuar");
			Console.WriteLine("1. Agregar nuevo paciente");
			Console.WriteLine("2. Buscar paciente");
			Console.WriteLine("3. Mostrar el historial del paciente");
			Console.WriteLine("4. Crear un nuevo médico clínico");
			Console.WriteLine("5. Crear un nuevo médico emergentólogo");
			Console.WriteLine("6. Crear un nuevo especialista");
			Console.WriteLine("7. Simular día de trabajo");
			Console.WriteLine("8. Salir del sistema");
		}

		public static void opcion1()
		{
			string nombre;
			int dni;
			int edad;
			string coberturaSalud;
			Console.WriteLine("Por favor, ingrese el nombre del paciente");
			nombre = Console.ReadLine();
			Console.WriteLine("Por favor, ingrese el dni del paciente");
			dni = Convert.toInt32(Console.ReadLine());
			Console.WriteLine("Por favor, ingrese la edad del paciente");
			edad = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Por favor, ingrese la cobertura de salud del paciente");
			coberturaSalud = Console.ReadLine();
			paciente p1 = new Paciente(nombre, dni, edad, coberturaSalud);
		}
		
		public static void Main(string[] args)
		{
			
			ManejoArchivos archivos = new ManejoArchivos();
			Clinica cli = new Clinica(archivos);
			cli.MostrarProfesionales(cli.profesionales);

			Area urgencias = new Area("Urgencias",archivos);
			cli.MostrarAreas(cli.areas);
			


			while (opcion_seleccionada != 8)
			{
				opciones_menu();
				opcion_seleccionada = Convert.ToInt32(Console.ReadLine());
				switch(opcion_seleccionada)
				{
					case 1: opcion1();
					break;
					case 2: opcion2();
					break;
					case 3: opcion3();
					break;
					case 4: opcion4();
					break;
					case 5: opcion5();
					break;
					case 6: opcion6();
					break;
					case 7: opcion7();
					break;
					default: Console.WriteLine("No es una opción válida");
					break;
				}
			}

			
			//  Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
