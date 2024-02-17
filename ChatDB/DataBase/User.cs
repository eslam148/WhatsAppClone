using ChatDB.DataBase;
using Microsoft.AspNetCore.Identity;

namespace ChatDB 
{
    public class User: IdentityUser
    {
        public string Name { get; set; }

        public List<Friends> Friends { get; set; }
    }
}
