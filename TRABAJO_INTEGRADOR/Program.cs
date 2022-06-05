/*
 * Created by SharpDevelop.
 * User: andre
 * Date: 24/5/2022
 * Time: 17:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace TRABAJO_INTEGRADOR
{
	class Program
	{
		const int LIMITE_DE_ABOGADOS = 5;
		const int MAXIMO_DE_EXPEDIENTES_POR_ABOGADOS = 6;
		
		static void menu()
		{
			Console.WriteLine("\n"+
			                  " [0] Salir\n" +
			                  " [1] Agregar un nuevo abogado a la lista de abogados\n" +
			                  " [2] Eliminar abogado\n" +
			                  " [3] Listar abogados\n" +
			                  " [4] Listar expedientes\n" +
			                  " [5] Agregar un nuevo expediente a la lista de expedientes\n" +
			                  " [6] Modificar estado de un expediente\n" +
			                  " [7] Modificar abogado a cargo de un expediente\n" +
			                  " [8] Eliminar expediente\n" +
			                  " [9] Listar expedientes 'AUDIENCIA' en un mes determinado\n\n");
			
			Console.Write(" ELIJA UNA OPCION: ");
		}
		
		static Abogado leerAbogado()
		{
			string nombreYApellido, especialidad;
			long dni;
			
			Abogado abogado; 
			
			Console.Write(" Nombre y apellido del abogado: "); nombreYApellido = Console.ReadLine();
			Console.Write("                        D.N.I.: "); dni = long.Parse(Console.ReadLine());
			Console.Write("                  Especialidad: "); especialidad = Console.ReadLine();
			
			abogado = new Abogado(nombreYApellido, dni, especialidad);
			
			return abogado;
		}
		
		static DateTime convertirEnDateTime(string fechaString) //Recibe (DD/MM/AAAA)
		{
			string[] fecha = fechaString.Split(new char[] {'/'});
			
			int dia  = int.Parse(fecha[0]);
			int mes  = int.Parse(fecha[1]);
			int anio = int.Parse(fecha[2]);
			
			DateTime fechaRetorno = new DateTime(anio,mes,dia); //AAA/MM/DD
			
			return (fechaRetorno);
		}
		static void imprimirAbogado(Abogado abogado)
		{
			Console.WriteLine("                         Abogado: {0}", abogado.getNombreYApellido());
			Console.WriteLine("                          D.N.I.: {0}", abogado.getDni());
			Console.WriteLine("                    Especialidad: {0}", abogado.getEspecialidad());
			Console.WriteLine(" Candidad de expedientes a cargo: {0}\n", abogado.getCantidadDeExpedientes());
		}
			
		
		static Abogado elegirAbogadoParaExpediente(EstudioAbogado estudio)
			//Se elige un abogado dentro de los que no sobrepasaron el limite de expedientes y se lo retorna
		{
			Abogado abogadoElegido = new Abogado();
			int posicion;
			int contador;
			contador = 0;
			
			Console.WriteLine("______________________________________________________________");
			Console.WriteLine("[[[[[[[[[[[[[[[ LISTA DE ABOGADOS DISPONIBLES ]]]]]]]]]]]]]]]]\n");
			
			estudio.comenzarAbogados();
			for(int i = 0; i < estudio.cantidadDeAbogados(); i++)
			{
				if(estudio.pedirAbogado().getCantidadDeExpedientes() < MAXIMO_DE_EXPEDIENTES_POR_ABOGADOS )
				{
					contador++;
					Console.WriteLine("               [NUMERO DE POSICION: {0}]", (i+1));//Enumera los abogados desde 1
					imprimirAbogado(estudio.pedirAbogado());
				}
				estudio.siguienteAbogado();
			}
			Console.WriteLine("______________________________________________________________");
			
			if(contador > 0)
			{
				try 
				{
					Console.WriteLine(" ELIJA UN ABOGADO A CARGO DE LA LISTA DE ABOGADOS DISPONIBLES");
					Console.Write(" NUMERO DE POSICION DEL ABOGADO ELEGIDO: ");
					posicion = int.Parse((Console.ReadLine()));
					abogadoElegido = (estudio.pedirAbogadoPorPosicion(posicion-1)); //Se le resta 1 a la opcion elegida para que concuerde con el indice del arreglo.
				}
				catch (FormatException)
				{
					Console.WriteLine(" ERROR: LA OPCION DEBE SER UN NUMERO ENTERO");
				}
				catch(IndexOutOfRangeException)
				{
					Console.WriteLine(" ERROR: EL NUMERO DE POSICION QUE INGRESO NO ES VALIDO");
				}
			}
			else 
			{
				Console.WriteLine(" NO HAY ABOGADOS DISPONIBLES");
				abogadoElegido = null;
			}
			return (abogadoElegido);//Retorna el abogado elegido.
		}
		
		static Expediente leerExpediente(EstudioAbogado estudio)
		{
			int numero;
			DateTime fecha;
			string titular, tipo, estado;
			Abogado abogadoACargo = new Abogado();
			
			abogadoACargo = elegirAbogadoParaExpediente(estudio);
			
			Console.WriteLine("");
			Console.Write(" Nombre y apellido del titular: "); titular = Console.ReadLine();
			Console.Write("          Numero de expediente: "); numero  = int.Parse(Console.ReadLine());
			Console.Write("            Fecha [dd/mm/aaaa]: "); fecha   = convertirEnDateTime(Console.ReadLine());
			Console.Write("            Tipo de expediente: "); tipo    = Console.ReadLine();
			Console.Write("         Estado del expediente: "); estado  = Console.ReadLine();
			
			Expediente expedienteNuevo = new Expediente(numero, fecha, titular, tipo, estado, abogadoACargo);
			
			return (expedienteNuevo);
		}
		
		static void cargarAbogados(ref EstudioAbogado estudio)
		{ 
			int repeticiones;
			Abogado abogado;
			
			do{
				Console.WriteLine("\n Puede agregar un maximo de {0} abogados", LIMITE_DE_ABOGADOS);
				Console.Write(" ¿Cuantos abogados va a cargar? ");
				repeticiones = int.Parse(Console.ReadLine());
				if((repeticiones > LIMITE_DE_ABOGADOS) || (repeticiones < 0))
				{
					Console.WriteLine(" DEBE INGRESAR UN ENTERO ENTRE  0 y {0}", LIMITE_DE_ABOGADOS);
				}
			}while((repeticiones > LIMITE_DE_ABOGADOS) || (repeticiones < 0));
			
			Console.Clear();
			for(int i = 0; i < repeticiones; i++)
			{
				Console.WriteLine("\n CARGANDO ABOGADO {0}° DE {1}\n", (i+1), repeticiones);
				abogado = leerAbogado();
				estudio.agregarAbogado(abogado);
			}
			              
		}
		
		
		static void cargarExpedientes(ref EstudioAbogado estudio)
		{
			Expediente nuevoExpediente = new Expediente();
			int repeticiones;
			
			int capacidad = estudio.cantidadDeAbogados()*MAXIMO_DE_EXPEDIENTES_POR_ABOGADOS;
			do {
				Console.WriteLine("\n CARGA DE EXPEDIENTES\n");
				Console.WriteLine(" Puede agregar un maximo de {0} expedientes", capacidad);
				Console.Write(" ¿Cuantos expedientes va a cargar? ");
				repeticiones = int.Parse(Console.ReadLine());
				Console.Clear();
				if((repeticiones > capacidad) || (repeticiones < 0))
				{
					Console.WriteLine(" DEBE INGRESAR UN ENTERO ENTRE  0 y {0}", capacidad);
				}
			}while((repeticiones > capacidad) || (repeticiones < 0));
			
			Console.Clear();
			for(int i = 0; i < repeticiones; i++)
			{
				Console.Clear();
				Console.WriteLine("\n CARGANDO EXPEDIENTE {0}° DE {1}\n", i+1, repeticiones);
				nuevoExpediente = leerExpediente(estudio);
				estudio.agregarExpediente(nuevoExpediente);
				Console.Clear();
			}
		}
		
		static void listarAbogados(EstudioAbogado estudio)
		{
			if(estudio.cantidadDeAbogados() > 0)
			{
				estudio.comenzarAbogados();
				for(int i = 0; i < estudio.cantidadDeAbogados(); i++)
				{
					Console.WriteLine(estudio.pedirAbogado().toString());
					Console.WriteLine("");
					estudio.siguienteAbogado();
				}
			}
			else
			{
				Console.WriteLine(" NO HAY ABOGADOS CARGADOS AUN");
			}
		}
		
		static void listarExpedientes(EstudioAbogado estudio)
		{
			if(estudio.cantidadDeExpedientes() > 0)
			{
				estudio.comenzarExpedientes();
				for(int i = 0; i < estudio.cantidadDeExpedientes(); i++)
				{
					Console.WriteLine(estudio.pedirExpediente().toString());
					Console.WriteLine("");
					estudio.siguienteExpediente();
				}
			}
			else
			{
				Console.WriteLine(" NO HAY EXPEDIENTES CARGADOS AUN");
			}
		}
		
		static void listarExpedientes(EstudioAbogado estudio, int mes, string tipo)
		{
			int mesActual; string tipoActual;
			int contador;
			
			if(estudio.cantidadDeExpedientes() > 0)
			{
				contador = 0;
				estudio.comenzarExpedientes();
				for(int i = 0; i < estudio.cantidadDeExpedientes(); i++)
				{
					mesActual  = estudio.pedirExpediente().getFecha().Month ;
					tipoActual = estudio.pedirExpediente().getTipo().ToUpper();
				
					if ((mesActual == mes)&&(tipoActual == tipo))
					{
						Console.WriteLine(estudio.pedirExpediente().toString());
						Console.WriteLine("");
						contador++;
						
					}
					estudio.siguienteExpediente();
				}
				if(contador == 0)
				{
					Console.WriteLine(" NO HAY EXPEDIENTES TIPO '{0}' EN EL MES {1}", tipo, mes);
				}
			}
			else
			{
				Console.WriteLine(" NO HAY EXPEDIENTES CARGADOS AUN");
			}
		}
		
		public static void Main(string[] args)
		{
			int opcion, numeroExpediente;
			Abogado        abogado     = new Abogado();
			long           dni;
			Expediente     expediente  = new Expediente();
			EstudioAbogado estudio     = new EstudioAbogado(LIMITE_DE_ABOGADOS, MAXIMO_DE_EXPEDIENTES_POR_ABOGADOS);
			bool ok;
			
			
			//CARGA DE ABOGADOS
			do 
			{
				try 
				{
					Console.Clear();
					ok = true;
					cargarAbogados(ref estudio);						
				}
				catch(FormatException)
				{
					ok = false;
					Console.WriteLine(" NO INGRESO UN DATO CORRECTAMENTE");
					Console.ReadKey(true);
					Console.Clear();
					continue;
				}
			}while(!ok);
			
			//CARGA DE EXPEDIENTES	
			if(estudio.cantidadDeAbogados() > 0)
			{
				do 
				{
					try 
					{
						Console.Clear();
						ok = true;
						cargarExpedientes(ref estudio);						
					}
					catch(FormatException)
					{
						ok = false;
						Console.WriteLine(" NO INGRESO UN DATO CORRECTAMENTE");
						Console.ReadKey(true);
						Console.Clear();
						continue;
					}
				}while(!ok);
			}
       		//MENU PRINCIPAL			
			do{
				try {
					
						Console.Clear();
						menu();
						opcion = int.Parse(Console.ReadLine());
					
						Console.Clear();
						switch(opcion)
						{
							case 1 :
								Console.WriteLine("\n            AGREGAR UN NUEVO ABOGADO\n");
								abogado = leerAbogado();
								Console.WriteLine("");
								estudio.agregarAbogado(abogado);
								break;
							case 2 :
								Console.WriteLine("\n                ELIMINAR UN ABOGADO\n");
								if(estudio.cantidadDeAbogados() > 0)
								{
									listarAbogados(estudio);
									Console.WriteLine("______________________________________________________________");
									Console.Write(" ingrese D.N.I. del abogado que desea eliminar: ");
									dni = long.Parse(Console.ReadLine());
									Console.WriteLine("");
									estudio.eliminarAbogado(dni);
								}
								else
								{
									Console.WriteLine(" DEBE INGRESAR ABOGADOS A LISTA DE ABOGADOS PRIMERO");
								}
								break;
							case 3 :
								Console.WriteLine("\n                  LISTAR ABOGADOS\n");
								listarAbogados(estudio);
								break;
							case 4 :
								Console.WriteLine("\n                 LISTAR EXPEDIENTES\n");
								listarExpedientes(estudio);
								break;
							case 5:
								Console.WriteLine("\n                AGREGAR UN NUEVO EXPEDIENTE\n ");
								expediente = leerExpediente(estudio);
								Console.WriteLine("");
								estudio.agregarExpediente(expediente);
								break;
							case 6 :
								Console.WriteLine("\n         MODIFICAR ESTADO DE UN EXPEDIENTE\n");
								if(estudio.cantidadDeExpedientes() > 0)
								{
									listarExpedientes(estudio);
									Console.WriteLine("______________________________________________________________");
									Console.Write(" Ingrese el numero de expediente para MODIFICAR ESTADO: ");
									numeroExpediente = int.Parse(Console.ReadLine());
									Console.Write(" Ingrese nuevo estado del expediente: ");
									string nuevoEstado = Console.ReadLine();
									Console.WriteLine("");
									estudio.modificarEstadoDeUnExpediente(numeroExpediente, nuevoEstado);
								}
								else
								{
									Console.WriteLine(" DEBE INGRESAR EXPEDIENTES A LA LISTA DE EXPEDIENTES PRIMERO");
								}
								break;
							case 7 :
								Console.WriteLine("\n         MODIFICAR ABOGADO A CARGO DE UN EXPEDIENTE\n");
								if(estudio.cantidadDeAbogados() > 0)
								{
									if(estudio.cantidadDeExpedientes() > 0)
									{
										listarExpedientes(estudio);
										Console.WriteLine("______________________________________________________________");
										Console.Write(" Ingrese el numero de expediente para MODIFICAR ABOGADO A CARGO: ");
										numeroExpediente = int.Parse(Console.ReadLine());
										abogado = elegirAbogadoParaExpediente(estudio);
										Console.WriteLine("");
										estudio.modificarAbogadoACargoDeUnExpediente(numeroExpediente, abogado);
									}
									else
									{
										Console.WriteLine(" DEBE INGRESAR EXPEDIENTES A LA LISTA DE EXPEDIENTES PRIMERO");
									}
								}
								else
								{
									Console.WriteLine(" DEBE INGRESAR ABOGADOS A LISTA DE ABOGADOS PRIMERO");
								}
								break;
							case 8 :
								Console.WriteLine("\n          ELIMINAR UN EXPEDIENTE\n");
								if(estudio.cantidadDeExpedientes() > 0)
								{
									Console.Write(" Ingrese el numero de expediente que desea ELIMINAR: ");
									numeroExpediente = int.Parse(Console.ReadLine());
									Console.WriteLine("");
									estudio.eliminarExpediente(numeroExpediente);
								}
								else
								{
									Console.WriteLine(" DEBE INGRESAR EXPEDIENTES A LA LISTA PRIMERO");
								}
								break;
							case 9 :
								Console.WriteLine("\n       LISTAR 'AUDIENCIAS' EN UN MES DETERMINADA\n");
								Console.Write(" Ingrese el NUMERO DEL MES para conocer las audiencias en ese mes: ");
								int mes = int.Parse(Console.ReadLine());
								Console.WriteLine("");
								listarExpedientes(estudio, mes, "AUDIENCIA");
								break;
							case 0 :
								break;
							default :
								Console.WriteLine(" {0} NO es una opcion valida", opcion);
								Console.WriteLine(" DEBE INGRESAR UNA OPCION ENTRE 0 Y 9");
								break;
						}
						Console.Write(" Presione una tecla para continuar...");
						Console.ReadKey(true);
				}
				catch (FormatException)
				{
					Console.WriteLine(" ERROR: INGRESO UN DATO INCORRECTO");
					Console.ReadKey(true);
					opcion = -1;
					continue;
				}
				catch (AbogadoInexistente ex)
				{
					Console.WriteLine(ex.getMensaje());
					Console.ReadKey(true);
					opcion = -1;
					continue;
				}
				catch (AbogadoRepetido ex)
				{
					Console.WriteLine(ex.getMensaje());
					Console.ReadKey(true);
					opcion = -1;
					continue;
				}
				catch (ExpedienteInexistente ex)
				{
					Console.WriteLine(ex.getMensaje());
					Console.ReadKey(true);
					opcion = -1;
					continue;
				}
				catch (SobrepasoLimiteDeAbogados ex)
				{
					Console.WriteLine(ex.getMensaje());
					Console.ReadKey(true);
					opcion = -1;
					continue;
				}
				catch (SobrepasoLimiteDeExpedientes ex)
				{
					Console.WriteLine(ex.getMensaje());
					Console.ReadKey(true);
					opcion = -1;
					continue;
				}
			}while(opcion != 0);	
		}
	}
}
