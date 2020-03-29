using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PollMe.Business.Services.DTO
{

    public class AnswerDTO
    {
        [Key]
        public int Id { get; set; }

        public string Respuesta { get; set; }

        public int Votos { get; set; }



    }
}
