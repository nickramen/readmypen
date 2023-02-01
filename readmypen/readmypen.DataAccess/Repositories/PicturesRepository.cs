using Dapper;
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
        public async Task InsertPicture(string picturePath, int userId)
        {
            const string SqlQuery = "UDP_Admin_tbPictures_Insert";
            var parameters = new DynamicParameters();
            parameters.Add("@pic_PicturePath", picturePath, DbType.String, ParameterDirection.Input);
            parameters.Add("@usr_Id", userId, DbType.Int32, ParameterDirection.Input);

            try
            {
                using (var db = new SqlConnection(readmypenDbContext.ConnectionString))
                {
                    await db.ExecuteAsync(SqlQuery, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
