using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydienthoai
{
    class checkconnection
    {

        public static bool duplicateErrors(string s)
        {
            if (s.Equals(ConfigurationManager.ConnectionStrings["qldt"].ConnectionString))
                return true;

            return false;
        }

        public static bool emptyError(string s)
        {
            if (s.Equals(""))
            {

                return false;
            }
            return true;


        }

        


    }
}
// © 2020 Copyright by Tiendatmagic - All Rights Reserved | Designed by Tiendatmagic 😂