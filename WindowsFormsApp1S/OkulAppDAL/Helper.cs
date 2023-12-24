﻿using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Configuration;

namespace OkulAppDAL
{
    public class Helper
    {
        SqlConnection cn = null;    
        SqlCommand cmd = null;

        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;    
        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p=null)
        {
            using(cn=new SqlConnection(cstr))
            {
                using(cmd=new SqlCommand(cmdtext,cn))
                { 
                    if (p != null) 
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cn.Open();
                    return cmd.ExecuteNonQuery();

                }
            }

        }



    }
}
