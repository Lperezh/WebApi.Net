using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BildChile.DAL;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BildChile.ENT;

namespace BildChile.BLL.Dominio
{
   public  class FormsDOM
    {
       private const string POLITICA = "ErrorBLL";

       #region Metodos Publicos

       public static List<Forms> ObtenerTodos()
       {
           try
           {
                return FormsDAL.ObtenerTodos();
           }
           catch (Exception ex)
           {
               bool err = ExceptionPolicy.HandleException(ex, POLITICA);
               if (err)
                   throw;
               throw new Exception(ex.Message);

           }
       }

       public static Forms ObtenerPorId(string parametro)
       {
           try
           {
               return FormsDAL.Obtener(parametro);
           }
           catch (Exception ex)
           {
               bool err = ExceptionPolicy.HandleException(ex, POLITICA);
               if (err)
                   throw;
               throw new Exception(ex.Message);

           }
       }

		/// <summary>	
		/// Inserta una entidad.
		/// </summary>	
       public static void Insertar(Forms entidad)
       {
           try
           {
               FormsDAL.Insertar(entidad);
           }
           catch (Exception ex)
           {
               bool err = ExceptionPolicy.HandleException(ex, POLITICA);
               if (err)
                   throw;
               throw new Exception(ex.Message);

           }
       }


       /// <summary>	
       /// Inserta una entidad.
       /// </summary>	
       public static void Eliminar(Forms entidad)
       {
           try
           {
               FormsDAL.Eliminar(entidad);
           }
           catch (Exception ex)
           {
               bool err = ExceptionPolicy.HandleException(ex, POLITICA);
               if (err)
                   throw;
               throw new Exception(ex.Message);

           }
       }


       #endregion

    }
}
