using Microsoft.EntityFrameworkCore;
using PollMe.Domain;
using PollMe.Domain.Entities;
using System;

namespace PollMe.DataAccess
{
    public class PollMeContext: DbContext
    {
        public PollMeContext(DbContextOptions<PollMeContext> options) : base(options)
        {
        }

        public DbSet<Poll> Encuestas { get; set; }
        public DbSet<Answer> Respuestas { get; set; }
        public DbSet<Event> Eventos { get; set; }
    }
}
