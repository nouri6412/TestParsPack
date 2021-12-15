using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWinForm.Model
{
    [Serializable]
   public class Comments
    {
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string comment { get; set; }
    }
}
