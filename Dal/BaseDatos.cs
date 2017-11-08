using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

namespace  BildChile.DAL
{
    public class BaseDeDatos
    {
        private static object syncRoot = new object();
        private static volatile Database baseDeDatos;

        private BaseDeDatos() { }

        public static Database Instancia
        {
            get
            {
                if (baseDeDatos == null)
                {
                    lock (syncRoot)
                    {
                        try
                        {
                            if (baseDeDatos == null)
                                baseDeDatos = DatabaseFactory.CreateDatabase("strCon");

                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }
                    }
                }
                return baseDeDatos;
            }
        }
    }
}
