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
using System.Collections.Generic;
namespace Clinica
{
	/// <summary>
	/// Description of ManejoArchivos.
	/// </summary>
	/// 
	
	
	public class ManejoArchivos
	{
		
		public ManejoArchivos()
		{		
		string basePath = AppDomain.CurrentDomain.BaseDirectory;
		//trabaja la raiz del Proyecto, asi no quedan en la bin los archivos
        string projectPath = Path.Combine(basePath, @"..\.."); 
        string carpetaClinica = Path.Combine(projectPath, "BaseDatos");

        // Crear carpeta si no existe
        if (!Directory.Exists(carpetaClinica))
            Directory.CreateDirectory(carpetaClinica);

        string pacientes = Path.Combine(carpetaClinica, "Pacientes.csv");
        string profesionales = Path.Combine(carpetaClinica, "Profesionales.csv");
        string areas = Path.Combine(carpetaClinica, "Areas.csv");
        string consultas = Path.Combine(carpetaClinica, "Consultas.csv");

        if (File.Exists(pacientes) && File.Exists(profesionales) && File.Exists(areas))
        {
            Console.WriteLine("Base de datos encontrada.");
            Console.WriteLine("Cargando archivos...");
        }
        else
        {
            Console.WriteLine("No se encontró base de datos anterior. Generando nueva BD...");
            using (StreamWriter sw = File.CreateText(pacientes))
                   {
                   		//Creo Los Encabezados del Archivo de Pacientes
                   		sw.WriteLine("DNI;NombreCompleto;Edad;ObraSocial");
                   }
            using (StreamWriter sw = File.CreateText(profesionales))
                   {
                   		sw.WriteLine("Id;Nombre;Tipo;Honorarios;MaxPacientes");
                   }
            using (StreamWriter sw = File.CreateText(areas))
                   {
                   		sw.WriteLine("Id;Nombre;");
                   }                   
            using (StreamWriter sw = File.CreateText(consultas))
		           {
		                sw.WriteLine("DNI;IdProfesional;TipoConsulta;Prioridad;Duracion;Costo;Fecha;Estado");
		           }
        }
		}
        
        //Metodo para leer cualquier csv y volverlo una lista de string para luego manipularlos
        public List<string[]> LeerCsv(string path) 
        {
        	var lineas = new List<string[]>();
        	using( var sr = new StreamReader(path))
	        	{
        		string linea;
        		bool encabezado = true;
        		while ((linea = sr.ReadLine())!= null )
        		{
        			if (encabezado)
        			{
        				encabezado = false;
        				continue;
        			}
                	lineas.Add(linea.Split(';'));
        			}
        		}     		
	        return lineas;     	
        }
        
		
        //Esta funcion se utiliza para generar los id automaticos para los metodos de creacion de los objetos 
        public int GenerarId(string path)
        	
        {
        	//verifica si el archivo existe
        	if (!File.Exists(path))
        	{
        		throw new FileNotFoundException("No se encontro el Archivo");
        	}
        	
        	string[] lineas = File.ReadAllLines(path);
        	
        	//si solo esta el encabezado el id va a ser 1
        	if (lineas.Length <=1)
        	{
        		return 1;
        	}
        	
        	//Lee la cantidad de filas que trae del archivo y le descuenta 1 para darle el valor al proximo ID
        	string ultimaLinea = lineas[lineas.Length-1];
   			string[] campos = ultimaLinea.Split(';');

    		int ultimoId = int.Parse(campos[0]);
   			return ultimoId + 1;
        }
        
		}
	}
