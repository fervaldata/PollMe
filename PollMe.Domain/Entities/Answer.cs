using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PollMe.Domain.Entities
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public int EncuestaId { get; set; }
        [ForeignKey("EncuestaId")]
        public virtual Poll Encuesta { get; set; }

        public string Respuesta { get; set; }

        public int Votos { get; set; }



       
    }
}
