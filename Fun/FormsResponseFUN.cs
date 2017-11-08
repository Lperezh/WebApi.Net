using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BildChile.FUN
{
    public class FormsResponseFUN
    {
        public int status { get; set; }
        public string error { get; set; }
        public List<FormsFUN> msg { get; set; }
    }
}
