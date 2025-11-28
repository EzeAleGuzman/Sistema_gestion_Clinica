/*
 * Created by SharpDevelop.
 * User: Sarabe89
 * Date: 18/10/2025
 * Time: 20:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

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
            {
                return n;
            }
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
        Console.WriteLine("5. Editar Paciente");
        Console.WriteLine("6. volver");
        Console.Write("Seleccione una opción: ");
    }

    public static void MenuProfesional()
    {
        Console.WriteLine("====== MENÚ PROFESIONALES ======");
        Console.WriteLine("1. Buscar profesional");
        Console.WriteLine("2. Agregar profesional");
        Console.WriteLine("3. Eliminar profesional");
        Console.WriteLine("4. Ver Profesionales");
        Console.WriteLine("5. Volver");
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
                	EditarPaciente();
                	break;
                case 6: 
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
    
    public static void EditarPaciente()
	{
	    Console.WriteLine("Ingrese DNI del paciente a editar: ");
	    string dniTexto = Console.ReadLine();
	    int dniBuscado;
	
	    if (!int.TryParse(dniTexto, out dniBuscado))
	    {
	        Console.WriteLine("DNI inválido.");
	        Console.WriteLine("\nPresione una tecla para continuar...");
	        Console.ReadKey();
	        return;
	    }
	
	    Paciente encontrado = null;
	
	    // Buscar en la lista de pacientes de la clínica
	    foreach (Paciente p in cli.pacientes)
	    {
	        if (p.DNI == dniBuscado)
	        {
	            encontrado = p;
	            break;
	        }
	    }
	
	    if (encontrado == null)
	    {
	        Console.WriteLine("No existe un paciente con ese DNI.");
	        Console.WriteLine("\nPresione una tecla para continuar...");
	        Console.ReadKey();
	        return;
	    }
	
	    Console.WriteLine("\nPaciente encontrado:");
	    Console.WriteLine("Nombre: " + encontrado.nombreCompleto);
	    Console.WriteLine("DNI: " + encontrado.DNI);
	    Console.WriteLine("Edad: " + encontrado.edad);
	    Console.WriteLine("Obra social: " + encontrado.obraSocial);
	
	    int op = 0;
	    while (op != 5)
	    {
	        Console.WriteLine("\n¿Qué desea editar?");
	        Console.WriteLine("1) Nombre");
	        Console.WriteLine("2) Edad");
	        Console.WriteLine("3) Obra social");
	        Console.WriteLine("4) DNI");
	        Console.WriteLine("5) Volver");
	
	        int.TryParse(Console.ReadLine(), out op);
	
	        switch (op)
	        {
	            case 1:
	                Console.Write("Nuevo nombre: ");
	                string nuevoNombre = Console.ReadLine();
	                encontrado.nombreCompleto = nuevoNombre;
	                Console.WriteLine("Nombre actualizado.");
	                break;
	
	            case 2:
	                Console.Write("Nueva edad: ");
	                int nuevaEdad;
	                if (int.TryParse(Console.ReadLine(), out nuevaEdad))
	                {
	                    encontrado.edad = nuevaEdad;
	                    Console.WriteLine("Edad actualizada.");
	                }
	                else
	                {
	                    Console.WriteLine("Valor inválido.");
	                }
	                break;
	
	            case 3:
	                Console.Write("Nueva obra social: ");
	                string nuevaObra = Console.ReadLine();
	                encontrado.obraSocial = nuevaObra;
	                Console.WriteLine("Obra social actualizada.");
	                break;
	
	            case 4:
	                Console.Write("Nuevo DNI: ");
	                int nuevoDNI;
	                if (int.TryParse(Console.ReadLine(), out nuevoDNI))
	                {
	                    encontrado.DNI = nuevoDNI;
	                    Console.WriteLine("DNI actualizado.");
	                }
	                else
	                {
	                    Console.WriteLine("Valor inválido.");
	                }
	                break;
	
	            case 5:
	                Console.WriteLine("Volviendo al menú...");
	                break;
	
	            default:
	                Console.WriteLine("Opción inválida.");
	                break;
	        }
	    }

    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
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
                case 2: AgregarProfesional(); break;
                case 3: EliminarProfesional(); break;
                case 4: VerProfesionales(); break;
                case 5: return;
                default: Console.WriteLine("Opción inválida"); break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
    
    

    //busca en la lista de profesionales y compara por nombre(Es mas facil xd...)
    public static void BuscarProfesional()
    {
        Console.WriteLine("Ingrese nombre del profesional: ");
        string nombre = Console.ReadLine();
        nombre = nombre.ToLower();
        
         Profesional encontrado = null;

	  
	    foreach (Profesional p in cli.profesionales)
	    {
	        if (p.nombre.ToLower() == nombre)
	        {
	            encontrado = p;
	            break; 
	        }
	    }
	
	    if (encontrado == null)
	    {
	        Console.WriteLine("No existe un profesional con ese nombre.");
	        Console.WriteLine("\nPresione una tecla para continuar...");
	        Console.ReadKey();
	        return;
	    }
	
	    Console.WriteLine(encontrado);


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

    public static void AgregarProfesional(){
    	Console.WriteLine("Nombre del Profesional");
    	string nombre = Console.ReadLine();
    	Console.WriteLine("Tipo de Profesional (Especialista-Clinico-Emergentologo)");
    	string tipo = Console.ReadLine();
    	tipo= tipo.ToLower();
    	if (tipo == "especialista")
    	{	
    		Especialista esp = new Especialista(nombre,archivos);
    		cli.profesionales.Add(esp);
    	}
    	else if (tipo == "clinico")
    	{	
    		MedicoClinico med = new MedicoClinico(nombre,archivos);
    		cli.profesionales.Add(med);
    	}
    	else if (tipo == "emergentologo")
    	{	
    		Emergentologo emer = new Emergentologo(nombre,archivos);
    		cli.profesionales.Add(emer);
    	}
    	else 
    	{
    		Console.WriteLine("Verifique el tipo de profesional");
    	}
    }
    
    //Metodo de eliminacion, trabaja con la lista que se crea al cargar los datos, no con el regiostros csv(Manejando la idea de la eliminacion logica)
    public static void EliminarProfesional()
    {
    	Console.WriteLine("Ingrese nombre de profesional a eliminar");
    	string nombre = Console.ReadLine();
    	nombre = nombre.ToLower();
    	
    	foreach (Profesional p in cli.profesionales)
    	{
    		if (p.nombre == nombre)
    		{
    			cli.profesionales.Remove(p);
    		}
    	}
    }
    
    public static void VerProfesionales()
    {
    	foreach (Profesional p in cli.profesionales)
    	{
    		if (cli.profesionales != null )
    		{
    			Console.WriteLine(p);
    		}
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
            		AgregarArea();
            		break;
                case 3: 
            		EliminarArea();
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
    
    public static void AgregarArea(){
    Console.WriteLine("Por favor ponga el nombre del Area");
    archivos.AgregarRegistro(archivos.areas, archivos.GenerarId(archivos.areas) +";" + Console.ReadLine().ToLower());
    Console.WriteLine("Agregando área...");
    
    }
    
    public static void EliminarArea(){
    	Console.WriteLine("Por favor ponga el ed del Area");
    	try {
    	archivos.EliminarRegistro(archivos.areas, Console.ReadLine().ToLower());
    	Console.WriteLine("Eliminando Area...");
    	}
    	catch (Exception ex) {
    		Console.WriteLine("ocurrio un error: "+ ex.Message);
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
                case 1: 
            		Console.WriteLine("Mostrando turnos...");
                	break;
                case 2: 
                	Console.WriteLine("Mostrando médicos..."); 
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


    public static  void SimularDia()
{
    Console.WriteLine("\n=== SIMULACION DEL DIA ===\n");

    // Limpia listas por si se simula mas de una vez
    foreach (Profesional prof in cli.profesionales)
    {
        prof.listadoAtencion.Clear();
        prof.listadoConsultasPendientes.Clear();
    }

    // 1) Asignar cada consulta a su profesional
    foreach (Consulta c in cli.consultas)
    {
        c.profesional.listadoConsultasPendientes.Add(c);
    }

    // 2) Ordenar por prioridad
    foreach (Profesional prof in cli.profesionales)
    {
        prof.listadoConsultasPendientes.Sort((a, b) =>
        {
            int pa = a.prioridad == "urgente" ? 0 : 1;
            int pb = b.prioridad == "urgente" ? 0 : 1;
            return pa.CompareTo(pb);
        });
    }

    // 3) Atender segun limite diario
    foreach (Profesional prof in cli.profesionales)
    {
        Console.WriteLine(string.Format(
            "\nProfesional: {0} (ID {1})",
            prof.nombre,
            prof.Id
        ));

        Console.WriteLine(string.Format("Puede atender: {0} pacientes", prof.maxPacientesDia));
        Console.WriteLine(string.Format("Consultas asignadas: {0}", prof.listadoConsultasPendientes.Count));

        int atendidos = 0;

        foreach (Consulta c in prof.listadoConsultasPendientes)
        {
            if (atendidos < prof.maxPacientesDia)
            {
                c.realizada = true;
                prof.listadoAtencion.Add(c);
                atendidos++;
            }
            else
            {
                c.realizada = false;
            }
        }

        Console.WriteLine(string.Format("Atendidas: {0}", prof.listadoAtencion.Count));
        Console.WriteLine(string.Format("Pendientes: {0}", prof.listadoConsultasPendientes.Count - prof.listadoAtencion.Count));
    }

} 
    
		    public static void MostrarResultadosDelDia()
		{
		    Console.WriteLine("\n===== RESULTADOS DEL DÍA =====\n");
		
		    int totalAtendidos = 0;
		    int totalTiempo = 0;
		    double costoTotal = 0;
		
		    Console.WriteLine("=== Detalle por Profesional ===\n");
		
		    foreach (Profesional prof in cli.profesionales)
		    {
		        int atendidas = prof.listadoAtencion.Count;
		        int pendientes = prof.listadoConsultasPendientes.Count;
		
		        // Tiempo total del profesional
		        int tiempoProfesional =+ prof.tiempoConsulta;
		
		        // Costo del profesional (honorarios * atendidas)
		        double costoProfesional = atendidas * prof.honorarios;
		
		        // Ocupación diaria
		        double ocupacion = (double)atendidas / prof.maxPacientesDia * 100;
		
		        // Acumular para reporte general
		        totalAtendidos += atendidas;
		        totalTiempo += tiempoProfesional;
		        costoTotal += costoProfesional;
		
		        // Mostrar profesional
		        Console.WriteLine(string.Format("Profesional: {0} (ID {1})", prof.nombre, prof.Id));
		        Console.WriteLine("-----------------------------------");
		        Console.WriteLine(string.Format("Atendidas: {0}", atendidas));
		        Console.WriteLine(string.Format("Pendientes: {0}", pendientes));
		        Console.WriteLine(string.Format("Tiempo total trabajado: {0} min", tiempoProfesional));
		        Console.WriteLine(string.Format("Costo generado: {0}", costoProfesional));
		        Console.WriteLine(string.Format("Ocupación del día: {0:0.00}%", ocupacion));
		        Console.WriteLine();
		    }
		
		    Console.WriteLine("\n=== Resumen General del Día ===\n");
		
		    Console.WriteLine(string.Format("Total de pacientes atendidos: {0}", totalAtendidos));
		
		    double promedio = totalAtendidos > 0 ? (double)totalTiempo / totalAtendidos : 0;
		    Console.WriteLine(string.Format("Promedio de tiempo por consulta: {0:0.0} min", promedio));
		
		    Console.WriteLine(string.Format("Costo operativo total: {0}", costoTotal));
		
		    Console.WriteLine("\n=== Listado de Pacientes Pendientes ===\n");
		
		    foreach (Profesional prof in cli.profesionales)
		    {
		        foreach (Consulta c in prof.listadoConsultasPendientes)
					{
				    if (!c.realizada)
				    {
				        Console.WriteLine(string.Format(
				            "Pendiente: {0} - Prioridad: {1}",
				            c.paciente.nombreCompleto,
				            c.prioridad
				        ));
				    }
		    }
		
		    
		}
		    Console.WriteLine("\n===== FIN DEL REPORTE =====");
		    }
    
    //main
    public static void Main(string[] args)
    {   
    	Clinica cli = new Clinica(archivos);
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
            		SimularDia();
            		MostrarResultadosDelDia();
            		Console.ReadKey(); 
            		break;
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