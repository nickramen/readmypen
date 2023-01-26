using Dapper;
using Microsoft.Extensions.Configuration;
using readmypen.DataAccess.Entities;
using readmypen.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readmypen.DataAccess.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        public tbUsers Login(string username, string password)
        {
            const string SqlQuery = "UDP_Acce_tbUsers_Login";
            var result = new tbUsers();
            var parameters = new DynamicParameters();
            parameters.Add("@usr_Username", username, DbType.String, ParameterDirection.Input);
            parameters.Add("@usr_Password", password, DbType.String, ParameterDirection.Input);

            try
            {
                using (var db = new SqlConnection(readmypenDbContext.ConnectionString))
                {
                    result = db.QueryFirstOrDefault<tbUsers>(SqlQuery, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
            return result;
        }
    }
}
