
using System;
using System.Collections.Generic;
using System.IO;
namespace Clinica
{
	/// <summary>
	/// Description of Consulta.
	/// </summary>
	    public class Consulta
    {
        public Paciente paciente;
        public Profesional profesional;
        public string tipoConsulta;
 		public string prioridad;         
        public int duracionMinutos;
        public double costo;
        public bool estado;

        public Consulta(Paciente paciente, string prioridad, Profesional profesional)
        {
            this.paciente = paciente;
            this.tipoConsulta = profesional.tipo;
            this.prioridad = prioridad.ToLower();
            this.profesional = profesional;
            // SIEMPRE sacamos estos datos del profesional
            this.duracionMinutos = profesional.tiempoConsulta;
            this.costo = profesional.honorarios;

            this.estado = false;
        }

		public override string ToString()
		{
		    string estadoTexto = estado ? "Atendido" : "En espera";
		
		    return string.Format(
		        "Paciente: {0}, Profesional: {1} ({2}), Prioridad: {3}, Costo: ${4}, Estado: {5}",
		        paciente.nombreCompleto,
		        profesional.nombre,
		        tipoConsulta,
		        prioridad,
		        costo,
		        estadoTexto
		    );
		}
        
		public void AgregarConsultaBD(ManejoArchivos archivo)
		{
		    string basePath = AppDomain.CurrentDomain.BaseDirectory;
		    string projectPath = Path.Combine(basePath, @"..\..");
		    string path = Path.GetFullPath(Path.Combine(projectPath, "BaseDatos", "Consultas.csv"));
		
		    string nuevaLinea = string.Format("{0};{1};{2};{3};{4};{5};{6}",
		        paciente.DNI,         
		        profesional.Id,   
		        tipoConsulta,        
		        prioridad,           
		        duracionMinutos,    
		        costo,             
		        estado          
		    );
		
		    File.AppendAllText(path, Environment.NewLine + nuevaLinea);
		}
}
}
