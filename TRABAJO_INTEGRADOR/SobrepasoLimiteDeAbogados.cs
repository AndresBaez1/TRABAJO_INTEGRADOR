/*
 * Created by SharpDevelop.
 * User: andre
 * Date: 25/5/2022
 * Time: 21:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace TRABAJO_INTEGRADOR
{
	/// <summary>
	/// Description of SobrepasoLimiteDeAbogados.
	/// </summary>
	public class SobrepasoLimiteDeAbogados : Exception
	{
		private string mensaje;
			
		public SobrepasoLimiteDeAbogados()
		{
		}

	 	public SobrepasoLimiteDeAbogados(string mensaje)
		{
	 		this.mensaje = mensaje;
		}
	 	
	 	public string getMensaje()
	 	{
	 		return this.mensaje;
	 	}

	}
}