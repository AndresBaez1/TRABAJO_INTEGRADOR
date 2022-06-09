using System;
using System.Runtime.Serialization;

namespace TRABAJO_INTEGRADOR
{
	/// <summary>
	/// Description of ExpedienteInexistente.
	/// </summary>
	public class ExpedienteInexistente : Exception
	{
		private string mensaje;
		
		public ExpedienteInexistente()
		{
		}

	 	public ExpedienteInexistente(string mensaje) 
		{
	 		this.mensaje = mensaje;
		}
	 	
	 	public string getMensaje()
	 	{
	 		return this.mensaje;
	 	}

	}
}