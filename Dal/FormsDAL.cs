  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.Common;
  using System.Data.SqlClient;
  using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BildChile.ENT;

namespace BildChile.DAL
{
	/// <summary>
	/// Clase que encapsula la lógica de acceso a datos para la entidad "Forms".
	/// Transaccionalidad: AdoDotNet
	/// Concurrencia optimista: False
	/// </summary>
	public partial class FormsDAL
	{
		#region Miembros privados

		private static Database _baseDeDatos;
		private const string POLITICA_ERRORES = "ErrorDatos";
		
		#endregion
		
		#region Constructor estático

		/// <summary>
		/// Constructor que inicializa la instancia actual de la base de datos.
		/// </summary>
		static FormsDAL()
		{
			try
			{
				// Obtiene la referencia a la base de datos actual.
				_baseDeDatos = BaseDeDatos.Instancia;		
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}
		}	

		/// <summary>
		/// Constructor suprimido para evitar instanciación.
		/// </summary>
		private FormsDAL()
		{}
		
		#endregion
		
		#region Métodos públicos 
		
		/// <summary>	
		/// Obtiene un entidad a partir de la(s) llave(s) primaria(s).
		/// </summary>	
		public static Forms Obtener(string llaveId)
		{
			try
			{			
				// Inicializa los objetos
				IDataReader salida = null;
				Forms entidad = null;

				// Fija el nombre del SP a ejecutar
				string sqlCommand = "spFormsObtener";
				DbCommand comandoObtener = _baseDeDatos.GetStoredProcCommand(sqlCommand);	
				_baseDeDatos.AddInParameter(comandoObtener,"@Id",DbType.Int32,llaveId);
				salida = _baseDeDatos.ExecuteReader(comandoObtener);
			
				// Obtiene la entidad solicitada
				if (!salida.IsClosed)
				{					
					if (salida.Read())
					{
						entidad = CargarEntidad(salida);
					}
				}
        
        salida.Close();
        salida.Dispose();
				return entidad;
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
				else
					return null;
			}
		}			

		/// <summary>	
		/// Obtiene todas las entidades.
		/// </summary>	
		public static List<Forms> ObtenerTodos()
		{			
			try
			{
				// Inicializa los objetos
				IDataReader salida = null;
				Forms entidad = null;				
				List<Forms> resultado = new List<Forms>();
				
										
				// Fija el nombre del SP a ejecutar
				string sqlCommand = "spFormsObtener" ;
				DbCommand comandoObtenerTodos = _baseDeDatos.GetStoredProcCommand(sqlCommand); 			
				salida = _baseDeDatos.ExecuteReader(comandoObtenerTodos);
				
				// Crea el ArraList de salida con las entidades
				if (!salida.IsClosed)
				{
					while (salida.Read())
					{
						entidad = CargarEntidad(salida);
						resultado.Add(entidad);						
					}
				}
				
				
        salida.Close();
        salida.Dispose();
			
				return resultado;			
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
				else
					return null;
			}
		}
		
		
		/// <summary>	
		/// Inserta una entidad.
		/// </summary>	
		public static void Insertar(Forms entidad)
		{
			try
			{
				DbCommand comandoInsertar = PrepararComandoInsertar(entidad);
				_baseDeDatos.ExecuteNonQuery(comandoInsertar);
				CopiarCamposIdentidad(comandoInsertar,entidad);
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Inserta una entidad en contexto transaccional.
		/// </summary>	
		public static void Insertar(Forms entidad, DbTransaction transaccion)
		{
			try
			{
				DbCommand comandoInsertar = PrepararComandoInsertar(entidad);
				_baseDeDatos.ExecuteNonQuery(comandoInsertar,transaccion);
				CopiarCamposIdentidad(comandoInsertar,entidad);
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Inserta un conjunto de entidades.
		/// </summary>
		public static void Insertar(List<Forms> entidades)
		{
			try
			{
				foreach(Forms entidad in entidades)
				{
					DbCommand comandoInsertar = PrepararComandoInsertar(entidad);
					_baseDeDatos.ExecuteNonQuery(comandoInsertar);
					CopiarCamposIdentidad(comandoInsertar,entidad);
				}
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Inserta un conjunto de entidades en contexto transaccional.
		/// </summary>
		public static void Insertar(List<Forms> entidades, DbTransaction transaccion)
		{
			try
			{
				foreach(Forms entidad in entidades)
				{
					DbCommand comandoInsertar = PrepararComandoInsertar(entidad);
					_baseDeDatos.ExecuteNonQuery(comandoInsertar,transaccion);
					CopiarCamposIdentidad(comandoInsertar,entidad);
				}
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Actualiza una entidad.
		/// </summary>	
		public static void Actualizar(Forms entidad)
		{
			try
			{
				DbCommand comandoActualizar = PrepararComandoActualizar(entidad);
				_baseDeDatos.ExecuteNonQuery(comandoActualizar);					
				

			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Actualiza una entidad en contexto transaccional.
		/// </summary>	
		public static void Actualizar(Forms entidad, DbTransaction transaccion)
		{
			try
			{
				DbCommand comandoActualizar = PrepararComandoActualizar(entidad);
				_baseDeDatos.ExecuteNonQuery(comandoActualizar,transaccion);	
				
						
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Actualiza un conjunto de entidades.
		/// </summary>	
		public static void Actualizar(List<Forms> entidades)
		{
			try
			{
				foreach(Forms entidad in entidades)
				{
					DbCommand comandoActualizar = PrepararComandoActualizar(entidad);
					_baseDeDatos.ExecuteNonQuery(comandoActualizar);	
					
						
				}
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Actualiza un conjunto de entidades en contexto transaccional.
		/// </summary>	
		public static void Actualizar(List<Forms> entidades, DbTransaction transaccion)
		{
			try
			{
				foreach(Forms entidad in entidades)
				{
					DbCommand comandoActualizar = PrepararComandoActualizar(entidad);
					_baseDeDatos.ExecuteNonQuery(comandoActualizar,transaccion);		
					
							
				}
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}
		
		/// <summary>	
		/// Elimina una entidad.
		/// </summary>	
		public static void Eliminar(Forms entidad)
		{
			try
			{
				DbCommand comandoEliminar = PrepararComandoEliminar(entidad);
				_baseDeDatos.ExecuteNonQuery(comandoEliminar);				
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Elimina una entidad en contexto transaccional.
		/// </summary>	
		public static void Eliminar(Forms entidad, DbTransaction transaccion)
		{
			try
			{
				DbCommand comandoEliminar = PrepararComandoEliminar(entidad);
				_baseDeDatos.ExecuteNonQuery(comandoEliminar,transaccion);				
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Elimina un conjunto de entidades.
		/// </summary>	
		public static void Eliminar(List<Forms> entidades)
		{
			try
			{
				foreach(Forms entidad in entidades)
				{
					DbCommand comandoEliminar = PrepararComandoEliminar(entidad);
					_baseDeDatos.ExecuteNonQuery(comandoEliminar);					
				}
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}

		/// <summary>	
		/// Elimina un conjunto de entidades en contexto transaccional.
		/// </summary>	
		public static void Eliminar(List<Forms> entidades, DbTransaction transaccion)
		{
			try
			{
				foreach(Forms entidad in entidades)
				{
					DbCommand comandoEliminar = PrepararComandoEliminar(entidad);
					_baseDeDatos.ExecuteNonQuery(comandoEliminar,transaccion);					
				}
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
			}			
		}		

		/// <summary>	
		/// Carga una entidad con el contenido de un DataReader
		/// </summary>			
		private static Forms CargarEntidad(IDataReader salida)
		{
			Forms entidad = new Forms();

			string columna;

			for (int i=0; i<salida.FieldCount; i++)
  {
  columna = salida.GetName(i);
  switch(columna.ToUpper())
  {			
					case "ID":								
						if (!salida.IsDBNull(i))
							entidad.Id = salida.GetInt32(i);
						break;

					case "NAME":								
						if (!salida.IsDBNull(i))
							entidad.Name = salida.GetString(i);
						break;

				}
			}

			return entidad;
		}
		
		/// <summary>	
		/// Prepara un objeto DBComandWrapper para realizar una insercción.
		/// </summary>	
		private static DbCommand PrepararComandoInsertar(Forms entidad)
		{
			try
			{
				DbCommand comandoInsertar;
								
				// Define el comando para insertar las entidades en la base de datos
				comandoInsertar = _baseDeDatos.GetStoredProcCommand("spFormsInsertar");								
				_baseDeDatos.AddOutParameter(comandoInsertar,"@Id",DbType.Int32,4);
				
				if (!entidad.EsNulo("Name"))								
					_baseDeDatos.AddInParameter(comandoInsertar,"@Name",DbType.String,entidad.Name);
				else										
					_baseDeDatos.AddInParameter(comandoInsertar,"@Name",DbType.String,DBNull.Value);
								
				return comandoInsertar;
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
				else
					return null;
			}
		}
		
		/// <summary>	
		/// Prepara un objeto DBComandWrapper para realizar una actualización.
		/// </summary>	
		private static DbCommand PrepararComandoActualizar(Forms entidad)
		{
			try
			{
				DbCommand comandoActualizar;
								
				// Define el comando para actualizar las entidades en la base de datos
				comandoActualizar = _baseDeDatos.GetStoredProcCommand("spFormsActualizar");
				if (!entidad.EsNulo("Id"))								
					_baseDeDatos.AddInParameter(comandoActualizar,"@Id",DbType.Int32,entidad.Id);
				else
					_baseDeDatos.AddInParameter(comandoActualizar,"@Id",DbType.Int32,DBNull.Value);
		
				if (!entidad.EsNulo("Name"))								
					_baseDeDatos.AddInParameter(comandoActualizar,"@Name",DbType.String,entidad.Name);
				else
					_baseDeDatos.AddInParameter(comandoActualizar,"@Name",DbType.String,DBNull.Value);
		
				return comandoActualizar;
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
				else
					return null;
			}
		}								

		#endregion
		
		#region Métodos privados
			
		/// <summary>	
		/// Prepara un objeto DBComandWrapper para realizar una eliminación.
		/// </summary>	
		private static DbCommand PrepararComandoEliminar(Forms entidad)
		{
			try
			{
				DbCommand comandoEliminar;
								
				// Define el comando para eliminar una entidad de la base de datos
				comandoEliminar = _baseDeDatos.GetStoredProcCommand("spFormsEliminar");
				_baseDeDatos.AddInParameter(comandoEliminar,"@Id",DbType.Int32,entidad.Id);				
				return comandoEliminar;
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex,POLITICA_ERRORES);
				if (rethrow)
					throw;
				else
					return null;
			}
		}	

		/// <summary>	
		/// Actualiza una entidad con los valores de los campos de identidad.
		/// </summary>			
		private static void CopiarCamposIdentidad(DbCommand comandoInsertar, Forms entidad)
		{
			entidad.Id = Convert.ToInt32(_baseDeDatos.GetParameterValue(comandoInsertar,"@Id"));			
		}

		#endregion		

	}

}	
				

