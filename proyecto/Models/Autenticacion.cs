using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Models
{
    public class Autenticacion
    {
        public List<Data> _data = new List<Data>();
        public State _error = new State();

        public Autenticacion(State error, List<Data> data)
        {
            _error = error;
            _data = data;
        }
        public Autenticacion(State error)
        {
            _error = error;
            _data = null;
        }
        public class Data
        {
            public System.String Usuario { get; set; }
            public System.String Password { get; set; }
            public System.String Dominio { get; set; }
            public DateTime FechaUltimoLogin { get; set; }
        }
        public class State
        {
            public System.Int32 error { get; set; }
            public System.String descripcion { get; set; }
        }
    }
}