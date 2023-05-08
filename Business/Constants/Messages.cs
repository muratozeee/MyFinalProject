using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product was Added..!";
        public static string ProductNameInvalid = "Product Name is Invalid..!";
        public static string MaintainanceTime= "System is Maintenance..!";
        public static string ProductsListed="Product was Listed..!";
        public static string ProductCountCategoryError = "Category can not more than 15..!";

        public static string ProductUpdated = "Product was Updated..!";

        public static string ProductNameAlreadyExists = "Product Already Exists..!";
        public static string CategoryLimitExceded = "Category Number can not more than 15 ";
    }
}
