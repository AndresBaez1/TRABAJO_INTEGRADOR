/*
 * Created by SharpDevelop.
 * User: andre
 * Date: 25/5/2022
 * Time: 23:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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