using PollMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PollMe.Domain
{
    [Table("Polls")]

    public class Poll
    {
        [Key]
        public int Id { get; set; }

        public string Pregunta { get; set; }

        public DateTime CreadoEn { get; set; }

        public virtual ICollection<Answer> Respuestas { get; } = new List<Answer>();

        public int EventoId { get; set; }
        [ForeignKey("EventoId")]
        public virtual Event Evento { get; set; }

    }
}
