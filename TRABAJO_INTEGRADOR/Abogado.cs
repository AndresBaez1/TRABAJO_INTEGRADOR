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
		private int     cantidadDeExpedientes;
		
		public Abogado()
		{
			
		}
		
		public Abogado( string nombreYApellido, long dni, string especialidad )
		{
			this.nombreYApellido        = nombreYApellido;
			this.dni                    = dni;
			this.especialidad           = especialidad;
			this.cantidadDeExpedientes  = 0;
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
		
		public int getCantidadDeExpedientes()
		{
			return this.cantidadDeExpedientes;
		}
		
		public void setNombreYApellido(string nombreYApellido)
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
		
		public void setCantidadDeExpedientes(int cantidadDeExpedientes)
		{
			this.cantidadDeExpedientes = cantidadDeExpedientes;
		}
		public string toString()  
		{
			string cadena =   "                 Abogado: "+ this.nombreYApellido+
			                "\n                   D.N.I: "+ this.dni+
			                "\n            Especialidad: "+ this.especialidad+
			                "\n Cantidad de expedientes: "+ this.cantidadDeExpedientes;
			
			return (cadena);
		}
		
		public string toStringLinea()
		{
			string cadena = nombreYApellido+";"+dni+" "+especialidad+";"+cantidadDeExpedientes;
			
			return (cadena);                  
		}
		
		public static Abogado ParseLinea(string cadenaConFormato)//nombreYApellido;dni;especialidad;cantidadExpedientes
		{
			Abogado abogadoRetorno = new Abogado();
			
			string[] datos = cadenaConFormato.Split(new char[]{';'});
			
			abogadoRetorno.setNombreYApellido(datos[0]);
			abogadoRetorno.setDni(long.Parse(datos[1]));
			abogadoRetorno.setEspecialidad(datos[2]);
			abogadoRetorno.setCantidadDeExpedientes(int.Parse(datos[3]));
			
			return (abogadoRetorno);
			
		}
		
		public void incrementarCantidadDeExpedientes()
		{
			this.cantidadDeExpedientes++;
		}
		
		public void decrementarCantidadDeExpedientes()
		{
			this.cantidadDeExpedientes--;
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
