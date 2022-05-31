/*
 * Created by SharpDevelop.
 * User: andre
 * Date: 24/5/2022
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TRABAJO_INTEGRADOR
{
	/// <summary>
	/// Description of Expediente.
	/// </summary>
	public class Expediente
	{
		private int      numero;
		private DateTime fecha;
		private string   titular; //Nombre y apellido del cliente para el cual se desarrolla el expediente
		private string   tipo; //Denuncia, penal, tramite de divorcio, estafa, etc.
		private string   estado; //Activo, archivado, en tramite.
		private Abogado  abogadoACargo;
		
		
		public Expediente()
		{
			this.abogadoACargo = new Abogado();
			this.fecha         = new DateTime();
		}
		public Expediente(int numero, DateTime fecha, string titular, string tipo, string estado, Abogado abogadoACargo)
		{
			this.numero        = numero;
			this.fecha         = fecha;
			this.titular       = titular;
			this.tipo          = tipo;
			this.estado 	   = estado;
			this.abogadoACargo = abogadoACargo;
		}
		public string toString()
		{
			string cadena =   "          Numero: "+ this.numero+
					        "\n           Fecha: "+ this.fecha.ToString()+
							"\n         Titular: "+ this.titular+
					        "\n            Tipo: "+ this.tipo+
					        "\n          Estado: "+ this.estado+
				            "\n Abogado a cargo: "+ this.abogadoACargo.getNombreYApellido()+
							               " DNI["+ this.abogadoACargo.getDni()+"]";
			
			return (cadena);
		}
			
		public string toStringEnUnaLinea()
		{
			string cadena = numero+";"+fecha.ToString()+";"+titular+";"+tipo+";"+estado+";"+"|"+
							  abogadoACargo.getNombreYApellido()+";"+abogadoACargo.getDni();  
			return cadena;
		}
		
		public static Expediente Parse(string cadenaConFormato)
			/*La cadena recibida contiene el formato:
			numero;fecha;titular;tipo;estado|nombreYapellido del abogado a cargo;DNI del abogado a cargo*/
		{
			Abogado abogado = new Abogado();
			Expediente expedienteRetorno = new Expediente();
			
			string[] expedienteYAbogado = cadenaConFormato.Split(new char[]{'|'});
			
			string[] datos = expedienteYAbogado[0].Split(new char[]{';'});
			string[] abogadoDatos = expedienteYAbogado[1].Split(new char[]{';'});
			
			abogado.setNombreApellido(abogadoDatos[0]);
			abogado.setDni((long.Parse(abogadoDatos[1])));
			
			expedienteRetorno.setNumero(int.Parse(datos[0]));
			expedienteRetorno.setFecha(DateTime.Parse(datos[1]));
			expedienteRetorno.setTitular(datos[2]);
			expedienteRetorno.setTipo(datos[3]);
			expedienteRetorno.setEstado(datos[4]);
			expedienteRetorno.setAbogadoACargo(abogado);
				
			return expedienteRetorno;
		}
		
		public int getNumero()
		{
			return this.numero;
		}
		
		public string getTitular()
		{
			return this.titular;
		}
		
		public string getTipo()
		{
			return this.tipo;
		}

		public string getEstado()
		{
			return this.estado;
		}		
		
		public Abogado getAbogadoACargo()
		{
			return this.abogadoACargo;
		}
		
		public DateTime getFecha()
		{
			return this.fecha;
		}
		
		public void setNumero(int numero)
		{
			this.numero = numero;
		}
		
		public void setTitular(string titular)
		{
			this.titular = titular;
		}
		
		public void setTipo(string tipo)
		{
			this.tipo = tipo;
		}
		
		public void setEstado(string estado)
		{
			this.estado = estado;
		}
		
		public void setAbogadoACargo(Abogado abogado)
		{
			this.abogadoACargo = abogado;
		}
		
		public void setFecha(DateTime fecha)
		{
			this.fecha = fecha;
		}
		
		public void setExpediente(int numero, string titular, string tipo, string estado, Abogado abogadoACargo, DateTime fecha)
		{
			this. numero		= numero;
			this.titular		= titular;
			this.tipo			= tipo;
			this.estado			= estado;
			this.abogadoACargo	= abogadoACargo;
			this.fecha			= fecha;
		}
	}
}
