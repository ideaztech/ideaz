using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solum.App_Code
{
   public class BottleDropJsonResponse
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public bool Verified { get; set; }
        public string Token { get; set; }
        public string[] Username { get; set; }
        public string Customer { get; set; }
        public string BagID { get; set; }
    }
}
