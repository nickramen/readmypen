using Microsoft.AspNetCore.Http;
using readmypen.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readmypen.DataAccess.Interfaces
{
    public interface IPicturesRepository
    {
        public int InsertPicture(string pic_PicturePath, int usr_Id);
    }
}
