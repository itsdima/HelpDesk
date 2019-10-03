using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string UserQuery { get; set; }

    }
}
