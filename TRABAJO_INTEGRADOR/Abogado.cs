/*
 * Created by SharpDevelop.
 * User: andre
 * Date: 24/5/2022
 * Time: 18:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TRABAJO_INTEGRADOR
{
	/// <summary>
	/// Description of Abogado.
	/// </summary>
	public class Abogado
	{
		private string	nombreYApellido;
		private long	dni;                //Se identifica a los abogados por el dni.
		private string	especialidad;       //Laboral, penal, comercial, familia, etc.
		private int		cantidadExpedientes;
		
		public Abogado()
		{
			
		}
		
		public Abogado( string nombreYApellido, long dni, string especialidad )
		{
			this.nombreYApellido 		= nombreYApellido;
			this.dni					= dni;
			this.especialidad			= especialidad;
			this.cantidadExpedientes	= 0;
		}
		
		public void setAbogado( string nombreYApellido, long dni, string especialidad, int cantidadExpedientes )
		{
			this.nombreYApellido 		= nombreYApellido;
			this.dni					= dni;
			this.especialidad			= especialidad;
			this.cantidadExpedientes	= cantidadExpedientes;
		}
		
		public string getNombreYApellido()
		{
			return this.nombreYApellido;
		}
		
		public long getDni()
		{
			return this.dni;
		}
		
		public string getEspecialidad()
		{
			return this.especialidad;
		}
		
		public int getCantidadExpedientes()
		{
			return this.cantidadExpedientes;
		}
		
		public void setNombreApellido(string nombreYApellido)
		{
			this.nombreYApellido = nombreYApellido ;
		}
		
		public void setDni(long dni)
		{
			this.dni = dni;
		}
		
		public void setEspecialidad(string especialidad)
		{
			this.especialidad = especialidad;
		}
		
		public void setCantidadExpedientes(int cantidadExpedientes)
		{
			this.cantidadExpedientes = cantidadExpedientes;
		}
		public string toString()  
		{
			string cadena =   "                 Abogado: "+ this.nombreYApellido+
			                "\n                   D.N.I: "+ this.dni+
			                "\n            Especialidad: "+ this.especialidad+
			                "\n Cantidad de expedientes: "+ this.cantidadExpedientes;
			
			return (cadena);
		}
		
		public string toStringLinea()
		{
			string cadena = nombreYApellido+";"+dni+" "+especialidad+";"+cantidadExpedientes;
			
			return (cadena);                  
		}
		
		public static Abogado ParseLinea(string cadenaConFormato)//nombreYApellido;dni;especialidad;cantidadExpedientes
		{
			Abogado abogadoRetorno = new Abogado();
			
			string[] datos = cadenaConFormato.Split(new char[]{';'});
			
			abogadoRetorno.setNombreApellido(datos[0]);
			abogadoRetorno.setDni(long.Parse(datos[1]));
			abogadoRetorno.setEspecialidad(datos[2]);
			abogadoRetorno.setCantidadExpedientes(int.Parse(datos[3]));
			
			return (abogadoRetorno);
			
		}
		
		public void incrementarCantidadExpedientes()
		{
			this.cantidadExpedientes++;
		}
		
		public void decrementarCantidadExpedientes()
		{
			this.cantidadExpedientes--;
		}
		
		public bool esIgual( Abogado abogado )
		{
			return ( this.dni == abogado.getDni() );
			
		}
		
		public bool esDistinto( Abogado abogado)
		{
			return ( this.dni != abogado.getDni() );
		}
		
		
	}
}
