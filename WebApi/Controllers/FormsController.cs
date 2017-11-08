using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using WebApi.FormsSvc;
using Newtonsoft.Json;
using AttributeRouting.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("Forms")]

    public class FormsController : ApiController
    {

        [GET("getforms")]
        public HttpResponseMessage getforms()
        {

            FormsClient servicio = new WebApi.FormsSvc.FormsClient();

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
