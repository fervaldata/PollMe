using Microsoft.EntityFrameworkCore;
using PollMe.Business.Services.DTO;
using PollMe.DataAccess;
using PollMe.Domain;
using PollMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PollMe.Business.Services
{
    public interface IPollService
    {
        void CreatePoll(PollDTO Encuesta);

        void CreateEvent(EventDTO Evento);

        void DeleteEvent(int id);

        void DeletePoll(int id);

        PollDTO Get(int id);

        void Vote(int Id);

       

    }


    public class PollService : IPollService
    {
        private readonly PollMeContext Context;
        public PollService(PollMeContext ctx)
        {
            this.Context = ctx;
        }


        public void CreateEvent(EventDTO Evento)
        {
            if (Evento == null)
                throw new Exception("Evento null");

            var entity = new Event()
            {
                Nombre = Evento.Nombre,
                FechaEvento = DateTime.UtcNow,
            };


            Context.Eventos.Add(entity);
            Context.SaveChanges();
        }

        public void CreatePoll(PollDTO Encuesta)
        {
            var Poll = RegistrarEncuesta(Encuesta);

            RegistrarRespuestas(Encuesta.Respuestas, Poll.Id);
       

        }

        private Poll RegistrarEncuesta(PollDTO Encuesta)
        {
            var enc = new Poll()
            {
                Pregunta = Encuesta.Pregunta,
                CreadoEn = DateTime.UtcNow,
                EventoId = Encuesta.EventoId
            };

            var Result = Context.Add(enc).Entity;
            Context.SaveChanges();
            return Result;
        }

        private void RegistrarRespuestas(List<AnswerDTO> Respuestas, int EncuestaId)
        {
            var ans = new List<Answer>();

            foreach (var respuesta in Respuestas)
            {
                var obj = new Answer()
                {
                    EncuestaId = EncuestaId,
                    Respuesta = respuesta.Respuesta,
                };

                ans.Add(obj);
            }

            Context.Respuestas.AddRange(ans);
            Context.SaveChanges();


        }

        public PollDTO Get(int Id)
        {

            var Encuesta = Context.Encuestas.Include(x => x.Respuestas).Where(x => x.Id == Id).FirstOrDefault();

            var Respuestas = new List<AnswerDTO>();

            Encuesta.Respuestas.ToList().ForEach(x => Respuestas.Add(new AnswerDTO() { Id = x.Id, Respuesta = x.Respuesta, Votos = x.Votos }));

            var Poll = new PollDTO()
            {
                Id = Encuesta.Id,
                Pregunta = Encuesta.Pregunta,
                Respuestas = Respuestas
            };



            return Poll;

        }

        public void Vote(int id)
        {
            var respuesta = Context.Respuestas.Where(x => x.Id == id).FirstOrDefault();

            if (respuesta == null)
                throw new Exception("La respuesta no existe.");

            respuesta.Votos++;

            Context.Respuestas.Update(respuesta);
            Context.SaveChanges();

        }

        public void DeleteEvent(int id)
        {
            var Evento = Context.Eventos.Single(x => x.Id == id);

            if (Evento == null)
                throw new Exception("El evento ingresado no existe.");

            Context.Eventos.Remove(Evento);
            Context.SaveChanges();
        }

        public void DeletePoll(int id)
        {
            var Encuesta = Context.Encuestas.Single(x => x.Id == id);

            if (Encuesta == null)
                throw new Exception("La encuesta ingresada no existe.");

            Context.Encuestas.Remove(Encuesta);
            Context.SaveChanges();
        }
    }
}
