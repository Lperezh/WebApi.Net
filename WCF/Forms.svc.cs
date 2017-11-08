using BildChile.BLL.Manager;
using BildChile.FUN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Forms" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Forms.svc o Forms.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Forms : IForms
    {
        private const string POLITICA = "Informacion";


        public FormsResponseFUN ObtenerForms()
        {
            FormsResponseFUN response = new FormsResponseFUN();
            MensajeWCF<FormsFUN> respuesta = FormsMgr.ObtenerForms();
            if(respuesta.CodigoError == "E_00")
            {
                response.status = 200;
                response.error = "";
                response.msg = respuesta.Contenido;
            }
            else
            {
                response.status = 500;
                response.error = "Internal Error";
                response.msg = new List<FormsFUN>();
            }
            
            return response;

        }
    }
}
