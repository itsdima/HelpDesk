using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Models
{
    public class SupportTicketContext : DbContext
    {
        public SupportTicketContext (DbContextOptions<SupportTicketContext> options)
            : base(options)
        {
        }

        public DbSet<HelpDesk.Models.SupportTicket> SupportTicket { get; set; }
    }
}
