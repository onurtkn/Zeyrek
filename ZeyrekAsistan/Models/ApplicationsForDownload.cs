using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeyrekAsistan.Models
{
    public class ApplicationsForDownload
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public string ApplicationPath { get; set; }

        public ApplicationsForDownload(string name, string image, string applicationpath)
        {
            Name = name;
            Image = image;
            ApplicationPath = applicationpath;
        }

        
    }
}
