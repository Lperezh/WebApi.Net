using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTokenAuthentication.servicio;

namespace WebApiTokenAuthentication.Controllers
{
    [Authorize]
    public class FormsController : ApiController
    {
       
        public HttpResponseMessage getforms()
        {

            FormsClient servicio = new FormsClient();

            FormsResponseFUN response = new FormsResponseFUN();
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
                    if (response.status == 200)
                    {

                        respuesta.StatusCode = HttpStatusCode.OK;
                        respuesta.Content = new StringContent(JsonConvert.SerializeObject(response));
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
