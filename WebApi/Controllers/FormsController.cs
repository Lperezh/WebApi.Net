using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using WebApi.FormsSvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
   

    public class FormsController : ApiController
    {
        
        public HttpResponseMessage Get()
        {

            FormsClient servicio = new WebApi.FormsSvc.FormsClient();

            MensajeWCFOfFormsFUN response = new MensajeWCFOfFormsFUN();
            List<FormsFUN> listaEntidad = new List<FormsFUN>();
            HttpResponseMessage respuesta = new HttpResponseMessage();
            

            bool BadRequest = false;

            //token de validacion
            // if (token == "null" || token == string.Empty || token == null) { BadRequest = true; };
            string validaToken = "E_00";

            if (!BadRequest)
            {
                if (validaToken == "E_00")
                {

                    response = servicio.ObtenerForms();
                    if (response.CodigoError == "E_00")
                    {
                        respuesta.StatusCode = HttpStatusCode.OK;
                        respuesta.Content = new StringContent(JsonConvert.SerializeObject(response.Contenido));
                    }
                    else
                    {
                        respuesta.StatusCode = HttpStatusCode.InternalServerError;
                    }

                }
                else
                {
                    respuesta.StatusCode = HttpStatusCode.Unauthorized;

                }

            }
            else
            {
                respuesta.StatusCode = HttpStatusCode.BadRequest;
            }

            return respuesta;

        }
    }
}
