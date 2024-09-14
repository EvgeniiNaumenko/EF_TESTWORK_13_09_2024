using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //-----
        public UserSettings Settings { get; set; }
        //-----
        public ICollection<Transaction> Transactions { get; set; }
    }
}
