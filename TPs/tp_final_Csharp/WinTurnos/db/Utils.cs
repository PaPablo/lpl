using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace LibTurnos.db
{
    class Utils
    {
        public static Npgsql.NpgsqlConnection conn=new NpgsqlConnection();
    }
}
