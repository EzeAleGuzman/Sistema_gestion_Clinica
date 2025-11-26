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
	
	static ManejoArchivos archivos= new ManejoArchivos();
	static Clinica cli = new Clinica(archivos);
	
	// Revisa el valor para revisar si es valido (lo hice mas que nada por el null)
    static int RevisarOpcion()
    {
        while (true)
        {
            string input = Console.ReadLine();
            int n;

            if (int.TryParse(input, out n))
                return n;

            Console.WriteLine("Opción inválida. Ingrese un número:");
        }
    }


    //Vista de los menus


    public static void MenuPrincipal()
    {
        Console.WriteLine("========= MENÚ PRINCIPAL =========");
        Console.WriteLine("1. Paciente");
        Console.WriteLine("2. Profesional");
        Console.WriteLine("3. Área");
        Console.WriteLine("4. Simular día");
        Console.WriteLine("5. Salir\n");
        Console.Write("Seleccione una opción: ");
    }

    public static void MenuPaciente()
    {
        Console.WriteLine("====== MENÚ PACIENTES ======");
        Console.WriteLine("1. Buscar paciente");
        Console.WriteLine("2. Agregar paciente");
        Console.WriteLine("3. Eliminar paciente");
        Console.WriteLine("4. Ver Listado de pacientes");
        Console.WriteLine("5. Volver");
        Console.Write("Seleccione una opción: ");
    }

    public static void MenuProfesional()
    {
        Console.WriteLine("====== MENÚ PROFESIONALES ======");
        Console.WriteLine("1. Buscar profesional");
        Console.WriteLine("2. Agregar profesional");
        Console.WriteLine("3. Eliminar profesional");
        Console.WriteLine("4. Volver");
        Console.Write("Seleccione una opción: ");
    }

    public static void MenuArea()
    {
        Console.WriteLine("====== MENÚ ÁREAS ======");
        Console.WriteLine("1. Buscar área");
        Console.WriteLine("2. Agregar área");
        Console.WriteLine("3. Eliminar área");
        Console.WriteLine("4. Ver areas");
        Console.WriteLine("5. Volver");
        Console.Write("Seleccione una opción: ");
    }


    // submenus
    
    public static void SubMenuPaciente()
    {
        Console.WriteLine("====== SUBMENÚ DEL PACIENTE ======");
        Console.WriteLine("1. Ver historial");
        Console.WriteLine("2. Ver turnos");
        Console.WriteLine("3. Volver");
        Console.Write("Seleccione una opción: ");
    }

    public static void SubMenuMedico()
    {
        Console.WriteLine("====== SUBMENÚ DEL PROFESIONAL ======");
        Console.WriteLine("1. Ver agenda");
        Console.WriteLine("2. Ver pacientes asignados");
        Console.WriteLine("3. Volver");
        Console.Write("Seleccione una opción: ");
    }

    public static void SubMenuArea()
    {
        Console.WriteLine("====== SUBMENÚ DEL ÁREA ======");
        Console.WriteLine("1. Ver turnos");
        Console.WriteLine("2. Ver médicos");
        Console.WriteLine("4. Volver");
        Console.Write("Seleccione una opción: ");
    }


   //PACIENTE--------------------------------------------------------------------------------- 
    public static void MenuPacientes()
    {
        int op = 0;
        while (op != 5)
        {
            Console.Clear();
            MenuPaciente();
            op = RevisarOpcion();

            switch (op)
            {
                case 1: 
            		BuscarPaciente(); 
            		break;
                case 2: 
            		AgregarPaciente();
                	break;
                case 3: 
                	Console.WriteLine("Eliminando paciente..."); 
                	break;
                case 4:
                	VerListaPacientes();
                	break;
                case 5: 
                	return;
                default: 
                	Console.WriteLine("Opción inválida"); 
                	break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
    
    
	
    public static void BuscarPaciente()
    {
        Console.Write("Ingrese DNI del paciente: ");
        int dni = int.Parse(Console.ReadLine());
        foreach (Paciente p in cli.pacientes)
        {
        	if (p.DNI == dni)
        	{	
        		Console.WriteLine(p);
        		   // Mostrar submenu
		        int op = 0;
		        while (op != 3)
		        {
		            SubMenuPaciente();
		            op = RevisarOpcion();
		
		            switch (op)
		            {
		                case 1: Console.WriteLine("Mostrando historial..."); break;
		                case 2: Console.WriteLine("Mostrando turnos..."); break;
		                case 3: return;
		                default: Console.WriteLine("Opción inválida"); break;
		            }
		
		            
        		}
        	}
        	else
        		Console.WriteLine("No EXiste este paciente en la base de datos");
        }

		Console.WriteLine("\nPresione una tecla para continuar...");
		Console.ReadKey();
        

     
    }

    public static void AgregarPaciente()
    {
    	Console.WriteLine("ingrese el nombre completo");
    	string nombrecompleto = Console.ReadLine();
    	Console.WriteLine("ingrese DNI");
    	int DNI = int.Parse(Console.ReadLine());
    	Console.WriteLine("ingrese edad");
    	int edad = int.Parse(Console.ReadLine());
    	Console.WriteLine("ingrese Obra Social");
    	string obrasocial = Console.ReadLine();
    	Paciente p = new Paciente(nombrecompleto,DNI,edad,obrasocial,archivos);
    	cli.pacientes.Add(p);
    	
    }

    public static void VerListaPacientes()
    {
    	foreach (Paciente p in cli.pacientes)
    	{
    		Console.WriteLine(p);
    	}
    }
    
    public static void EliminarPaciente()
    {
    	Console.WriteLine("Ingrese Dni del paciente a eliminar");
    	int dni = int.Parse(Console.ReadLine());
    	
    	foreach (Paciente p in cli.pacientes)
    	{
    		if (p.DNI == dni)
    		{
    			cli.pacientes.Remove(p);
    		}
    	}
    }
    //PROFESIONAL---------------------------------------------------------------
    public static void MenuProfesionales()
    {
        int op = 0;
        while (op != 4)
        {
            Console.Clear();
            MenuProfesional();
            op = RevisarOpcion();

            switch (op)
            {
                case 1: BuscarProfesional(); break;
                case 2: Console.WriteLine("Agregando profesional..."); break;
                case 3: Console.WriteLine("Eliminando profesional..."); break;
                case 4: return;
                default: Console.WriteLine("Opción inválida"); break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void BuscarProfesional()
    {
        Console.Write("Ingrese id del profesional: ");
        string id = Console.ReadLine();
        
        
		//Profesional test
        bool encontrado = id == "123";

        if (!encontrado)
        {
            Console.WriteLine("No existe un profesional con esa id.");
            return;
        }

        Console.WriteLine("\nProfesional encontrado:");
        Console.WriteLine("Nombre: Dra. Ana Torres");
        Console.WriteLine("Especialidad: Pediatría\n");

        int op = 0;
        while (op != 3)
        {
            SubMenuMedico();
            op = RevisarOpcion();

            switch (op)
            {
                case 1: 
            		Console.WriteLine("Mostrando agenda..."); 
            		break;
                case 2: 
            		Console.WriteLine("Mostrando pacientes...");
            		break;
                case 3: 
            		return;
                default: 
            		Console.WriteLine("Opción inválida"); 
            		break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }



    ///ÁREA--------------------------------------------------------------------------
    public static void MenuAreas()
    {
        int op = 0;

        while (op != 4)
        {
            Console.Clear();
            MenuArea();
            op = RevisarOpcion();

            switch (op)
            {
                case 1: 
            		BuscarArea(); 
            		break;
                case 2: 
            		Console.WriteLine("Agregando área..."); 
            		break;
                case 3: 
            		Console.WriteLine("Eliminando área..."); 
            		break;
                case 4: 
            		Console.WriteLine("Las areas de la clinica son:");
						cli.MostrarAreas();            		
            		break;
                case 5: 
            		return;
                default: 
            		Console.WriteLine("Opción inválida"); 
            		break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void BuscarArea()
    {
        Console.Write("Ingrese id del área: ");
        string id = Console.ReadLine().ToLower();

        //area test 
        bool encontrada = id == "123";

        if (!encontrada)
        {
            Console.WriteLine("No existe un área con ese id.");
            return;
        }

        Console.WriteLine("\nÁrea encontrada:");
        Console.WriteLine("Nombre: Odotologia");
        Console.WriteLine("Cantidad de médicos: 6\n");

        int op = 0;
        while (op != 3)
        {
            SubMenuArea();
            op = RevisarOpcion();

            switch (op)
            {
                case 1: Console.WriteLine("Mostrando turnos..."); break;
                case 2: Console.WriteLine("Mostrando médicos..."); break;
                case 3: return;
                default: Console.WriteLine("Opción inválida"); break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }


  
    
    //main
    public static void Main(string[] args)
    {
    	
    	
    	int opcion = 0;

        while (opcion != 5)
        {
            Console.Clear();
            MenuPrincipal();
            opcion = RevisarOpcion();

            switch (opcion)
            {
                case 1: 
            		MenuPacientes(); 
            		break;
                case 2: 
            		MenuProfesionales(); 
            		break;
                case 3: 
            		MenuAreas(); 
            		break;
                case 4: 
            		Console.WriteLine("Simulando día..."); 
            		Console.ReadKey(); break;
                case 5: 
            		Console.WriteLine("Saliendo..."); 
            		break;
                default: 
            		Console.WriteLine("Opción inválida"); 
            		break;
            }
        }
    }
}
}