using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BildChile.FUN
{
    [DataContract]
    public  class MensajeWCF<T>
    {
            [DataMember]
            public string CodigoError { get; set; }

            [DataMember]
            public string MensajeError { get; set; }

            [DataMember]
            public string MensajeHumano { get; set; }

            [DataMember]
            public string IdApp { get; set; }

            [DataMember]
            public List<T> Contenido { get; set; }
        

    }
}
