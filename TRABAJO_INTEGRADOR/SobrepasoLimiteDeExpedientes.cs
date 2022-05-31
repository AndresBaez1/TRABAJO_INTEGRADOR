/*
 * Created by SharpDevelop.
 * User: andre
 * Date: 26/5/2022
 * Time: 14:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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