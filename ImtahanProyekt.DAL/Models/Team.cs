﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImtahanProyekt.DAL.Models
{
    public class Team:BaseClass
    {
        public string Name { get; set; }
        public string Position {  get; set; }
        public string ImgUrl {  get; set; }
    }
}
