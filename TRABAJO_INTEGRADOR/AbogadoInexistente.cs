/*
 * Created by SharpDevelop.
 * User: andre
 * Date: 25/5/2022
 * Time: 22:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace TRABAJO_INTEGRADOR
{
	/// <summary>
	/// Description of AbogadoInexistente.
	/// </summary>
	public class AbogadoInexistente : Exception
	{
		private string mensaje;
		
		public AbogadoInexistente()
		{
		}

	 	public AbogadoInexistente(string mensaje)
		{
	 		this.mensaje = mensaje;
		}
	 	
	 	public string getMensaje()
	 	{
	 		return this.mensaje;
	 	}

	}
}