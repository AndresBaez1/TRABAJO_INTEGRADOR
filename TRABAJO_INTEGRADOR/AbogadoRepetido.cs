using System;
using System.Runtime.Serialization;

namespace TRABAJO_INTEGRADOR
{
	/// <summary>
	/// Description of AbogadoRepetido.
	/// </summary>
	public class AbogadoRepetido : Exception
	{
		private string mensaje;
		
		public AbogadoRepetido()
		{
		}

	 	public AbogadoRepetido(string mensaje)
		{
	 		this.mensaje = mensaje;
		}
	 	
	 	public string getMensaje()
	 	{
	 		return this.mensaje;
	 	}
	}
}