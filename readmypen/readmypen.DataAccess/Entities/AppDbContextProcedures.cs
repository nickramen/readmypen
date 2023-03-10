// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using readmypen.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace readmypen.DataAccess.Entities
{
    public partial class AppDbContext
    {
        private IAppDbContextProcedures _procedures;

        public virtual IAppDbContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new AppDbContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IAppDbContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UDP_Acce_tbUsers_LoginResult>().HasNoKey().ToView(null);
        }
    }

    public partial class AppDbContextProcedures : IAppDbContextProcedures
    {
        private readonly AppDbContext _context;

        public AppDbContextProcedures(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<int> UDP_Acce_tbUsers_InsertAsync(string usr_Username, string usr_Password, int? rol_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "usr_Username",
                    Size = 50,
                    Value = usr_Username ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "usr_Password",
                    Size = 50,
                    Value = usr_Password ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "rol_Id",
                    Value = rol_Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UDP_Acce_tbUsers_Insert] @usr_Username, @usr_Password, @rol_Id", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<UDP_Acce_tbUsers_LoginResult>> UDP_Acce_tbUsers_LoginAsync(string usr_Username, string usr_Password, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "usr_Username",
                    Size = 50,
                    Value = usr_Username ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "usr_Password",
                    Size = 50,
                    Value = usr_Password ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<UDP_Acce_tbUsers_LoginResult>("EXEC @returnValue = [dbo].[UDP_Acce_tbUsers_Login] @usr_Username, @usr_Password", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> UDP_Admin_tbPictures_InsertAsync(string pic_PicturePath, int? usr_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "pic_PicturePath",
                    Size = -1,
                    Value = pic_PicturePath ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "usr_Id",
                    Value = usr_Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UDP_Admin_tbPictures_Insert] @pic_PicturePath, @usr_Id", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
