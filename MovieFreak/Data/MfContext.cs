using Microsoft.EntityFrameworkCore;
using MovieFreak.Models;

namespace MovieFreak.Data
{
    public class MfContext
    {
        public DbSet<Film> Films { get; set; }
    }
}