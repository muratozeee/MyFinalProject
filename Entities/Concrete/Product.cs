﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //we used the public because we can reach here from other layers...!
    public class Product:IEntity
    {

        public int ProductId { get; set; }
        public int CategoryId{ get; set; }
        public string ProductName { get; set; }
        public short UnitInStock { get; set; }
        public decimal UnitPrice  { get; set; }

    }
}
