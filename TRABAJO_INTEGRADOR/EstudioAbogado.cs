using System;
using System.Collections;

namespace TRABAJO_INTEGRADOR
{
	/// <summary>
	/// Description of EstudioAbogado.
	/// </summary>
	public class EstudioAbogado
	{
		private int       limiteDeAbogados;
		private int       maximoExpedientesPorAbogado;
		private ArrayList abogados;
		private int       indiceAbogados;
		private ArrayList expedientes;
		private int       indiceExpedientes;
		
		public EstudioAbogado()
		{
			
		}
		
		public EstudioAbogado(int limite, int maximoExpedientesPorAbogado) 
		{
			this.limiteDeAbogados            = limite;
			this.maximoExpedientesPorAbogado = maximoExpedientesPorAbogado;
			this.abogados                    = new ArrayList();
			this.expedientes                 = new ArrayList();
		}
		
		public void comenzarAbogados()
		{
			this.indiceAbogados = 0;
		}
		
		public void siguienteAbogado()
		{
			this.indiceAbogados++;		
		}
		
		public Abogado pedirAbogado()
		{
			return ((Abogado)(this.abogados[indiceAbogados]));
		}
		
		public Abogado pedirAbogadoPorPosicion(int i)
		{
			return ((Abogado)(this.abogados[i]));
		}
		
		public int cantidadDeAbogados()
		{
			return (this.abogados.Count);
		}
		
		public void comenzarExpedientes()
		{
			this.indiceExpedientes = 0;
		}
		
		public void siguienteExpediente()
		{
			this.indiceExpedientes++;
		}
		
		public Expediente pedirExpediente()
		{
			return ((Expediente)(this.expedientes[indiceExpedientes]));
		}
		
		public int cantidadDeExpedientes()
		{
			return (this.expedientes.Count);
		}
		
		public bool existeDniAbogado(long dni)
		{
			int i;
			i = 0;
			while( (i < this.abogados.Count) && (((Abogado)(this.abogados[i])).getDni() != dni ) ) 
				//Mientras no llegó al limite del arreglo y no encontró el dni.
			{
				i++;
			};
			
			return ((i < this.abogados.Count) && (((Abogado)(this.abogados[i])).getDni() == dni));
					//No llegó al final y se encontró el dni.
		}
		
		public void agregarAbogado(Abogado abogado)
		{
			if(!this.existeDniAbogado(abogado.getDni()))
			{
				if(this.limiteDeAbogados > abogados.Count)//Si no llegó a limite de abogados.
				{
					this.abogados.Add(abogado);
					Console.WriteLine(" EL ABOGADO FUE AGREGADO EXITOSAMENTE");
				}
				else
				{
					throw new SobrepasoLimiteDeAbogados(" ERROR: SOBRECARGA DEL LIMITE DE ABOGADOS");
				}
					
			}
			else
			{
				throw new AbogadoRepetido(" ERROR: EL ABOGADO QUE INTENTA AGREGAR YA EXISTE EN LA LISTA DE ABOGADOS");
			}
		}
		
		public void modificarAbogadoDeExpedientes(Abogado abogado)
		{
			int j;
			j = 0;
			//Buscamos el abogado nuevo para incrementar la cantidad de expedientes a su cargo.
			while((j<this.abogados.Count) && (((Abogado)(this.abogados[j])).esDistinto(abogado)))
				//Mientras no llegó al limite del arreglo y no encontro el abogado.
			{
				j++;
			};
			if(((Abogado)(this.abogados[j])).getCantidadDeExpedientes() < (this.maximoExpedientesPorAbogado))
			{
				((Abogado)(this.abogados[j])).incrementarCantidadDeExpedientes();
			}
			else 
			{
				throw new SobrepasoLimiteDeExpedientes(" EL ABOGADO NO PUEDE ESTAR A CARGO DE TANTOS EXPEDIENTES...");
			}
			
			for(int i = 0; i < this.expedientes.Count; i++)//Se recorren todos los expedientes
			{						
				if (((Expediente)(this.expedientes[i])).getAbogadoACargo().esIgual(abogado))
				{
				   ((Expediente)(this.expedientes[i])).setAbogadoACargo(abogado);
					//Expediente modificado				   	
				}		
			}
		}
		public int buscarAbogado(long dni)
		{
			int posicion;
			posicion = 0;
			
			while( (posicion < this.abogados.Count) && (((Abogado)(this.abogados[posicion])).getDni() != dni ) )
				//Mientras no llegó al limite del arreglo y no encontró el dni.
			{
				posicion++;
			};
			
			if( (posicion < this.abogados.Count) && (((Abogado)(this.abogados[posicion])).getDni() == dni ))
			{
				return posicion; //Retorna la posicion donde se encuentra el abogado buscado.
			}
			else 
				throw new AbogadoInexistente(" ERROR: EL ABOGADO QUE BUSCA NO EXISTE");
			
		}
		
		public Abogado buscarAbogadoConMenosExpedientes()
		{
			int menor = this.maximoExpedientesPorAbogado;
			Abogado abogadoRetorno = new Abogado();
			
			for (int i = 0 ; i < this.abogados.Count; i++)
			{
				if(((Abogado)abogados[i]).getCantidadDeExpedientes() < menor)
				{
					menor = ((Abogado)abogados[i]).getCantidadDeExpedientes();
					abogadoRetorno = (Abogado)(abogados[i]);
				}
			}
			
			return (abogadoRetorno);
		}
		
		private void eliminarAbogadoACargoEnExpedientes(Abogado abogado)//recibe el abogado a ser eliminado
		{
			bool error;
			error = false;
			
			for(int i= 0; i < this.expedientes.Count; i++) //recorro la lista de expedientes
			{
				if(((Expediente)(this.expedientes[i])).getAbogadoACargo().esIgual(abogado))//encuentro el expediente del abogado
				{
					Abogado abogadoNuevo;
					if(this.abogados.Count == 0)//Si ya no hay abogados
					{
						abogadoNuevo = null;
						Console.WriteLine(" ABOGADO A CARGO DEL EXPEDIENTE NUMERO[{0}] SERA REASIGNADO", ((Expediente)(this.expedientes[i])).getNumero());
						Console.WriteLine(" NUEVO ABOGADO ASIGNADO: NINGUN ABOGADO A CARGO");
						((Expediente)(this.expedientes[i])).setAbogadoACargo(abogadoNuevo);
						error = true;
					}
					else
					{
						abogadoNuevo = this.buscarAbogadoConMenosExpedientes();//Optengo una referencia al abogado con menos expedientes a cargo.
						if(abogadoNuevo.getCantidadDeExpedientes() < this.maximoExpedientesPorAbogado)//Si hay abogados que no llegaron a limite de expedientes
						{
							abogadoNuevo.incrementarCantidadDeExpedientes();//Incremento la cantidad de expedientes del abogado nuevo
						
							((Expediente)(this.expedientes[i])).setAbogadoACargo(abogadoNuevo);//Seteo el nuevo abogado con la candidad de expedientes incrementada
						
							Console.WriteLine(" ABOGADO A CARGO DEL EXPEDIENTE NUMERO[{0}] REASIGNADO", ((Expediente)(this.expedientes[i])).getNumero());
							Console.Write(" NUEVO ABOGADO ASIGNADO: {0}  ", abogadoNuevo.getNombreYApellido());
							Console.WriteLine(" D.N.I : {0}", abogadoNuevo.getDni());
						}
						else							
						{
							abogadoNuevo = null;
							Console.WriteLine(" ABOGADO A CARGO DEL EXPEDIENTE NUMERO[{0}] SERA REASIGNADO", ((Expediente)(this.expedientes[i])).getNumero());
							Console.WriteLine(" NUEVO ABOGADO ASIGNADO: NINGUN ABOGADO A CARGO");
							((Expediente)(this.expedientes[i])).setAbogadoACargo(abogadoNuevo);
							error = true;
						}
					}
				}
			}
			if(error)
			{
				throw new SobrepasoLimiteDeExpedientes(" HAY EXPEDIENTES QUE NO PUDIERON REASIGNARSELE NINGUN ABOGADO A CARGO");
			}
		}
		
		
		public void eliminarAbogado(long dni)
		{			
			if(existeDniAbogado(dni))//Si el abogado que voy a eliminar está dentro del estudio.
			{
				int posicionAbogado   = buscarAbogado(dni);    //Optengo el indice de la lista de abogados
				Abogado abogado = (Abogado)(this.abogados[posicionAbogado]); //Optengo el abogado en una variable
				
				this.abogados.RemoveAt(posicionAbogado); //Elimino el abogado de la lista de abogados.
				eliminarAbogadoACargoEnExpedientes(abogado); //Reasigno los expedientes del abogado
				
				Console.WriteLine(" EL ABOGADO [{0}] D.N.I.: [{1}] FUE ELIMINADO", abogado.getNombreYApellido(), abogado.getDni());
				
			}
			else
				throw new AbogadoInexistente(" ERROR: EL ABOGADO QUE INTENTA ELIMINAR NO EXISTE...");
		}
		
		public void agregarExpediente(Expediente expedienteNuevo)
		{
			Abogado abogado;
			
			abogado = expedienteNuevo.getAbogadoACargo();
			
			int i;
			i = 0;
			
			if(this.abogados.Count > 0)
			{
				while((i<this.abogados.Count) && (((Abogado)(this.abogados[i])).esDistinto(abogado)))
						//Mientras no llegó al limite del arreglo y no encontro el abogado.
				{
					i++;
				};
				
				if(((Abogado)(this.abogados[i])).getCantidadDeExpedientes() < (this.maximoExpedientesPorAbogado))
				{
					((Abogado)(this.abogados[i])).incrementarCantidadDeExpedientes();//Incremento la cantidad de expedientes
					expedienteNuevo.setAbogadoACargo((Abogado)this.abogados[i]);//Actualizo el abogado en la lista de expedientes
				
					expedientes.Add(expedienteNuevo); //Agrego el expediente al estudio.
					Console.WriteLine(" Expediente agregado correctamente");
				
				}
				else 
				{
					throw new SobrepasoLimiteDeExpedientes(" EL ABOGADO ["+((Abogado)(this.abogados[i])).getNombreYApellido()+
					                                       "] NO PUEDE ESTAR A CARGO DE TANTOS EXPEDIENTES...\n" +
				 	                                       " EL EXPEDIENTE NO PUDO SER AGREGADO\n" +
					                                       " DEBE PONER OTRO ABOGADO A CARGO DEL EXPEDIENTE");
			
				}
			}
			else 
			{
				expedientes.Add(expedienteNuevo);
				Console.WriteLine(" EL EXPEDIENTE SE AGREGO SIN NINGUN ABOGADO");
				Console.WriteLine(" INGRESE ABOGADOS A LA LISTA DE ABOGADOS PARA MODIFICAR ESTE EXPEDIENTE");
			}
	
		}
		
		public void modificarEstadoDeUnExpediente(int numeroExpediente, string nuevoEstado)
		{
			int i;
			i = 0;
			
			while((i < this.expedientes.Count)&&(((Expediente)(this.expedientes[i])).getNumero() != numeroExpediente))
				//Mientras no llegé al final de la lista y no encontré el expediente.
			{
				i++;
			}
			if((i < this.expedientes.Count)&&(((Expediente)(this.expedientes[i])).getNumero() == numeroExpediente))
				//Si encontré el expediente.
			{
				((Expediente)(this.expedientes[i])).setEstado(nuevoEstado);
				Console.WriteLine(((Expediente)(this.expedientes[i])).toString()); //Muestro el expediente que fue modificado
				Console.WriteLine("");
				Console.WriteLine(" EL ESTADO DEL EXPEDIENTE FUE MODIFICADO");
			}
			else 
				throw new ExpedienteInexistente(" ERROR: EL EXPEDIENTE QUE INTENTA MODIFICAR NO EXISTE");
				
		}
		
		public void modificarAbogadoACargoDeUnExpediente(int numeroDeExpediente, Abogado nuevoAbogado)
		{
			int i;
			i = 0;
			
			while((i < this.expedientes.Count)&&(((Expediente)(this.expedientes[i])).getNumero() != numeroDeExpediente))
				//Mientras no llegé al final de la lista y no encontré el expediente.
			{
				i++;
			}
			if((i < this.expedientes.Count)&&(((Expediente)(this.expedientes[i])).getNumero() == numeroDeExpediente))
				//Si encontré el expediente.
			{
				if(((Expediente)(this.expedientes[i])).getAbogadoACargo() != null )
				{
					((Expediente)(this.expedientes[i])).getAbogadoACargo().decrementarCantidadDeExpedientes();
					
				}
				((Expediente)(this.expedientes[i])).setAbogadoACargo(nuevoAbogado);
				Console.WriteLine(((Expediente)(this.expedientes[i])).toString()); //Muestro el expediente que fue modificado
				Console.WriteLine("");
				Console.WriteLine(" EL ABOGADO A CARGO DEL EXPEDIENTE FUE MODIFICADO");
				
				int posicion = buscarAbogado(nuevoAbogado.getDni());
				((Abogado)(this.abogados[posicion])).incrementarCantidadDeExpedientes();
			}
			else 
				throw new ExpedienteInexistente(" ERROR: EL EXPEDIENTE QUE INTENTA MODIFICAR NO EXISTE");
			
		}
		
		public void eliminarExpediente(int numeroExpediente)
		{
			int i;
			i = 0;
			
			while((i < this.expedientes.Count)&&(((Expediente)(this.expedientes[i])).getNumero() != numeroExpediente))
				//Mientras no llegé al final de la lista y no encontré el expediente.
			{
				i++;
			}
			if((i < this.expedientes.Count)&&(((Expediente)(this.expedientes[i])).getNumero() == numeroExpediente))
				//Si encontré el expediente.
			{
				Abogado abogadoACargo = ((Expediente)(this.expedientes[i])).getAbogadoACargo();
				//Le pido al expediente el abogado a cargo; Me devuelve una referencia al abogado.
				
				abogadoACargo.incrementarCantidadDeExpedientes();
				
				Console.WriteLine(((Expediente)(this.expedientes[i])).toString());//Informo el expediente eliminado
				Console.WriteLine("");
				
				this.expedientes.RemoveAt(i);
				//Elimino el expediente en la posicion "i" de la lista de expedientes.
				
				Console.WriteLine(" EL EXPEDIENTE CON NUMERO[{0}] FUE ELIMINADO", numeroExpediente);
			}
			else 
				throw new ExpedienteInexistente(" ERROR: EL EXPEDIENTE QUE INTENTA ELIMINAR NO EXISTE");
		}
		
		
	}
}
