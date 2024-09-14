using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork
{
    public class UserSettings
    {
        public int UserSettingsId { get; set; }
        public bool ReceiveNotifications { get; set; }
        public string Currency { get; set; }
        //--------
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
