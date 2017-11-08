using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BildChile.BLL.Dominio;
using BildChile.ENT;
using System.Data;
using System.Net;
using System.IO;
using System.Configuration;
using BildChile.FUN;

namespace BildChile.BLL.Manager
{
    public class FormsMgr
    {
        private const string POLITICA = "ErrorBLL";
        


        ///  Metodo que lista udsuarios de perfilameinto aplicando filtros
        /// </summary>
        /// <param name="p_Filtro"></param>
        /// <returns></returns>
        public static MensajeWCF<FormsFUN> ObtenerForms()
        {

            MensajeWCF<FormsFUN> retorno = new MensajeWCF<FormsFUN>();
            List<FormsFUN> response = new List<FormsFUN>();

            try
            {
                List<FormsFUN> listado = new List<FormsFUN>();
                List<Forms> listaForms = FormsDOM.ObtenerTodos();

                foreach (Forms form in listaForms)
                {
                    FormsFUN formfun = new FormsFUN();
                    formfun.name = form.Name;
                    formfun.inputs = new List<InputsFUN>();
                    foreach (Inputs item in InputsDOM.ObtenerPorIdForms(form.Id.ToString()).OrderByDescending(x => x.Id))
                    {

                        //implementar metodo aqui
                        formfun.inputs.Add(new InputsFUN
                        {
                            name = item.Name,
                            type = item.Type,
                            required = item.Required


                        });
                    }
                    listado.Add(formfun);
                }

        

                retorno.Contenido = listado;
                retorno.CodigoError = "E_00";
                retorno.MensajeError = "";
                retorno.MensajeHumano = Mensaje.MensajeError.E_00;

            }
            catch (DataException ex)
            {

                retorno.CodigoError = "E_01";
                retorno.MensajeError = ex.Message;
                retorno.MensajeHumano = Mensaje.MensajeError.E_01;
                bool err = ExceptionPolicy.HandleException(ex, POLITICA);

            }
            catch (Exception ex)
            {

                retorno.CodigoError = "E_02";
                retorno.MensajeError = ex.Message;
                retorno.MensajeHumano = Mensaje.MensajeError.E_02;
                bool err = ExceptionPolicy.HandleException(ex, POLITICA);
            }


            return retorno;
        }


      
    }
}
