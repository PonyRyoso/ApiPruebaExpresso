using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaApis.Models.WS
{
    public class ModeloPrincipal
    {
        public Boolean      error          { get; set; }
        public object      data           { get; set; }
        public string      message           { get; set; }
    }
}