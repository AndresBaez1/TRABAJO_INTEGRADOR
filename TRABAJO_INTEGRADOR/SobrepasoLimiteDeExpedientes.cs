using System;
using System.Runtime.Serialization;

namespace TRABAJO_INTEGRADOR
{
	/// <summary>
	/// Description of SobrepasoLimiteDeExpedientes.
	/// </summary>
	public class SobrepasoLimiteDeExpedientes : Exception
	{
		private string mensaje;
		
		public SobrepasoLimiteDeExpedientes()
		{
		}

	 	public SobrepasoLimiteDeExpedientes(string mensaje)
		{
	 		this.mensaje = mensaje;
		}
	 	
	 	public string getMensaje()
	 	{
	 		return this.mensaje;
	 	}

	}
}