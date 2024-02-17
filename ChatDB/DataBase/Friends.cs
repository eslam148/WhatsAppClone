using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDB.DataBase
{
    public class Friends
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
