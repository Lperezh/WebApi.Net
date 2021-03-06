

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
	/// Clase que encapsula la lógica de acceso a datos para la entidad "Inputs".
	/// Transaccionalidad: AdoDotNet
	/// Concurrencia optimista: False
	/// </summary>
	public partial class InputsDAL
	{
		#region Miembros privados

		private static Database _baseDeDatos;
		private const string POLITICA_ERRORES = "ErrorDatos";
		
		#endregion
		
		#region Constructor estático

		/// <summary>
		/// Constructor que inicializa la instancia actual de la base de datos.
		/// </summary>
		static InputsDAL()
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
		private InputsDAL()
		{}
		
		#endregion
		
		#region Métodos públicos 
		
		/// <summary>	
		/// Obtiene un entidad a partir de la(s) llave(s) primaria(s).
		/// </summary>	
		public static Inputs Obtener(string llaveId)
		{
			try
			{			
				// Inicializa los objetos
				IDataReader salida = null;
				Inputs entidad = null;

				// Fija el nombre del SP a ejecutar
				string sqlCommand = "spInputsObtener";
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
		public static List<Inputs> ObtenerTodos()
		{			
			try
			{
				// Inicializa los objetos
				IDataReader salida = null;
				Inputs entidad = null;				
				List<Inputs> resultado = new List<Inputs>();
				
										
				// Fija el nombre del SP a ejecutar
				string sqlCommand = "spInputsObtener" ;
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
		/// Obtiene las filas a partir de la(s) llave(s) foranea(s) FK_Inputs_Forms
		/// </summary>	
		public static List<Inputs> ObtenerVariosPorFK_Inputs_Forms(string parametroIdForms)
		{
			try
			{
				// Inicializa los objetos
				IDataReader salida = null;
				Inputs entidad = null;
				List<Inputs> resultado = new List<Inputs>();
										
				// Fija el nombre del SP a ejecutar
				string sqlCommand = "spInputsObtenerTodosFK_Inputs_Forms";
				DbCommand comandoObtenerTodosPor = _baseDeDatos.GetStoredProcCommand(sqlCommand);

				// Conversión de parámetros
						
				if (parametroIdForms == "")
				{
					_baseDeDatos.AddInParameter(comandoObtenerTodosPor,"@IdForms",DbType.Int32,DBNull.Value);											
				}
				else
				{
					Int32 _parametroIdForms;
					 _parametroIdForms = Convert.ToInt32(parametroIdForms);
					_baseDeDatos.AddInParameter(comandoObtenerTodosPor,"@IdForms",DbType.Int32,_parametroIdForms);						 
				}

				
				salida = _baseDeDatos.ExecuteReader(comandoObtenerTodosPor);
				
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
		public static void Insertar(Inputs entidad)
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
		public static void Insertar(Inputs entidad, DbTransaction transaccion)
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
		public static void Insertar(List<Inputs> entidades)
		{
			try
			{
				foreach(Inputs entidad in entidades)
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
		public static void Insertar(List<Inputs> entidades, DbTransaction transaccion)
		{
			try
			{
				foreach(Inputs entidad in entidades)
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
		public static void Actualizar(Inputs entidad)
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
		public static void Actualizar(Inputs entidad, DbTransaction transaccion)
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
		public static void Actualizar(List<Inputs> entidades)
		{
			try
			{
				foreach(Inputs entidad in entidades)
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
		public static void Actualizar(List<Inputs> entidades, DbTransaction transaccion)
		{
			try
			{
				foreach(Inputs entidad in entidades)
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
		public static void Eliminar(Inputs entidad)
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
		public static void Eliminar(Inputs entidad, DbTransaction transaccion)
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
		public static void Eliminar(List<Inputs> entidades)
		{
			try
			{
				foreach(Inputs entidad in entidades)
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
		public static void Eliminar(List<Inputs> entidades, DbTransaction transaccion)
		{
			try
			{
				foreach(Inputs entidad in entidades)
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
		private static Inputs CargarEntidad(IDataReader salida)
		{
			Inputs entidad = new Inputs();

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

					case "IDFORMS":								
						if (!salida.IsDBNull(i))
							entidad.IdForms = salida.GetInt32(i);
						break;

					case "NAME":								
						if (!salida.IsDBNull(i))
							entidad.Name = salida.GetString(i);
						break;

					case "TYPE":								
						if (!salida.IsDBNull(i))
							entidad.Type = salida.GetString(i);
						break;

					case "REQUIRED":								
						if (!salida.IsDBNull(i))
							entidad.Required = salida.GetBoolean(i);
						break;

				}
			}

			return entidad;
		}
		
		/// <summary>	
		/// Prepara un objeto DBComandWrapper para realizar una insercción.
		/// </summary>	
		private static DbCommand PrepararComandoInsertar(Inputs entidad)
		{
			try
			{
				DbCommand comandoInsertar;
								
				// Define el comando para insertar las entidades en la base de datos
				comandoInsertar = _baseDeDatos.GetStoredProcCommand("spInputsInsertar");								
				_baseDeDatos.AddOutParameter(comandoInsertar,"@Id",DbType.Int32,4);
				
				if (!entidad.EsNulo("IdForms"))								
					_baseDeDatos.AddInParameter(comandoInsertar,"@IdForms",DbType.Int32,entidad.IdForms);
				else										
					_baseDeDatos.AddInParameter(comandoInsertar,"@IdForms",DbType.Int32,DBNull.Value);
				
				if (!entidad.EsNulo("Name"))								
					_baseDeDatos.AddInParameter(comandoInsertar,"@Name",DbType.String,entidad.Name);
				else										
					_baseDeDatos.AddInParameter(comandoInsertar,"@Name",DbType.String,DBNull.Value);
				
				if (!entidad.EsNulo("Type"))								
					_baseDeDatos.AddInParameter(comandoInsertar,"@Type",DbType.String,entidad.Type);
				else										
					_baseDeDatos.AddInParameter(comandoInsertar,"@Type",DbType.String,DBNull.Value);
				
				if (!entidad.EsNulo("Required"))								
					_baseDeDatos.AddInParameter(comandoInsertar,"@Required",DbType.Boolean,entidad.Required);
				else										
					_baseDeDatos.AddInParameter(comandoInsertar,"@Required",DbType.Boolean,DBNull.Value);
								
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
		private static DbCommand PrepararComandoActualizar(Inputs entidad)
		{
			try
			{
				DbCommand comandoActualizar;
								
				// Define el comando para actualizar las entidades en la base de datos
				comandoActualizar = _baseDeDatos.GetStoredProcCommand("spInputsActualizar");
				if (!entidad.EsNulo("Id"))								
					_baseDeDatos.AddInParameter(comandoActualizar,"@Id",DbType.Int32,entidad.Id);
				else
					_baseDeDatos.AddInParameter(comandoActualizar,"@Id",DbType.Int32,DBNull.Value);
		
				if (!entidad.EsNulo("IdForms"))								
					_baseDeDatos.AddInParameter(comandoActualizar,"@IdForms",DbType.Int32,entidad.IdForms);
				else
					_baseDeDatos.AddInParameter(comandoActualizar,"@IdForms",DbType.Int32,DBNull.Value);
		
				if (!entidad.EsNulo("Name"))								
					_baseDeDatos.AddInParameter(comandoActualizar,"@Name",DbType.String,entidad.Name);
				else
					_baseDeDatos.AddInParameter(comandoActualizar,"@Name",DbType.String,DBNull.Value);
		
				if (!entidad.EsNulo("Type"))								
					_baseDeDatos.AddInParameter(comandoActualizar,"@Type",DbType.String,entidad.Type);
				else
					_baseDeDatos.AddInParameter(comandoActualizar,"@Type",DbType.String,DBNull.Value);
		
				if (!entidad.EsNulo("Required"))								
					_baseDeDatos.AddInParameter(comandoActualizar,"@Required",DbType.Boolean,entidad.Required);
				else
					_baseDeDatos.AddInParameter(comandoActualizar,"@Required",DbType.Boolean,DBNull.Value);
		
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
		private static DbCommand PrepararComandoEliminar(Inputs entidad)
		{
			try
			{
				DbCommand comandoEliminar;
								
				// Define el comando para eliminar una entidad de la base de datos
				comandoEliminar = _baseDeDatos.GetStoredProcCommand("spInputsEliminar");
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
		private static void CopiarCamposIdentidad(DbCommand comandoInsertar, Inputs entidad)
		{
			entidad.Id = Convert.ToInt32(_baseDeDatos.GetParameterValue(comandoInsertar,"@Id"));			
		}

		#endregion		

	}

}	
				

