using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PollMe.Domain.Entities
{
    [Table("Events")]
    public class Event
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaEvento { get; set; }
    }
}
