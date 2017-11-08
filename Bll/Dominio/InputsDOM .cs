using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BildChile.DAL;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BildChile.ENT;

namespace BildChile.BLL.Dominio
{
   public  class InputsDOM
    {
       private const string POLITICA = "ErrorBLL";

       #region Metodos Publicos

       public static List<Inputs> ObtenerTodos()
       {
           try
           {
               return InputsDAL.ObtenerTodos();
           }
           catch (Exception ex)
           {
               bool err = ExceptionPolicy.HandleException(ex, POLITICA);
               if (err)
                   throw;
               throw new Exception(ex.Message);

           }
       }

       public static Inputs ObtenerPorId(string parametro)
       {
           try
           {
               return InputsDAL.Obtener(parametro);
           }
           catch (Exception ex)
           {
               bool err = ExceptionPolicy.HandleException(ex, POLITICA);
               if (err)
                   throw;
               throw new Exception(ex.Message);

           }
       }

        public static List<Inputs> ObtenerPorIdForms(string parametro)
        {
            try
            {
                return InputsDAL.ObtenerVariosPorFK_Inputs_Forms(parametro);
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
        public static void Insertar(Inputs entidad)
       {
           try
           {
               InputsDAL.Insertar(entidad);
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
       public static void Eliminar(Inputs entidad)
       {
           try
           {
               InputsDAL.Eliminar(entidad);
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
