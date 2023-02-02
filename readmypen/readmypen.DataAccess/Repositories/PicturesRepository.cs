using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class PicturesRepository: IPicturesRepository
    {
        public int InsertPicture(string pic_PicturePath, int usr_Id)
        {
            const string SqlQuery = "UDP_Admin_tbPictures_Insert";
            var result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@pic_PicturePath", pic_PicturePath, DbType.String, ParameterDirection.Input);
            parameters.Add("@usr_Id", usr_Id, DbType.Int32, ParameterDirection.Input);

            try
            {
                using (var db = new SqlConnection(readmypenDbContext.ConnectionString))
                {
                    result = db.ExecuteScalar<int>(SqlQuery, parameters, commandType: CommandType.StoredProcedure);

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
