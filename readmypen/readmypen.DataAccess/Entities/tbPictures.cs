﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace readmypen.DataAccess.Entities
{
    public partial class tbPictures
    {
        public int pic_Id { get; set; }
        public string pic_PicturePath { get; set; }
        public int usr_Id { get; set; }

        public virtual tbUsers usr { get; set; }
    }
}