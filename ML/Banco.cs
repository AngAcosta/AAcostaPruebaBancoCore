using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Banco
    {
        public int IdBanco { get; set; }

        public string Nombre { get; set; }

        public int NoEmpleados { get; set; }

        public int NoSucursales { get; set; }

        public ML.Pais Pais{ get; set; }

        public decimal Capital { get; set; }

        public ML.RazonSocial RazonSocial { get; set; }

        public int NoClientes { get; set; }

        public List<object> Bancos { get; set; }
    }
}