using System;
using System.Collections.Generic;
using System.Text;

namespace PollMe.Business.Services.DTO
{
    public class PollDTO
    {
        public int Id { get; set; }
     
        public string Pregunta { get; set; }

        public DateTime CreadoEn { get; set; }

        public List<AnswerDTO> Respuestas { get; set; }

        public int EventoId { get; set; }
    }
}
