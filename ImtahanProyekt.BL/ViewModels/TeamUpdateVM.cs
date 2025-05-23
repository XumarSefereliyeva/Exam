using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImtahanProyekt.BL.ViewModels
{
    public class TeamUpdateVM
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
