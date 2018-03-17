using Lab3EDI_1C18.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDA.Clases;

namespace Lab3EDI_1C18.DBContext
{
    public class DefaultConnection
    {
        private static volatile DefaultConnection Instance;
        private static object syncRoot = new Object();

        ArbolAVL<Partido, int> arbolNoPartido = new ArbolAVL<Partido, int>();
        List<Partido> listaNoPartido = new List<Partido>();

        ArbolAVL<Partido, DateTime> arbolFechaPartido = new ArbolAVL<Partido, DateTime>();
        List<Partido> listaFechaPartido = new List<Partido>();


        public int IDActual { get; set; }

        private DefaultConnection()
        {
            IDActual = 0;
        }

        public static DefaultConnection getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new DefaultConnection();
                        }
                    }
                }
                return Instance;
            }
        }
    }
}