using Flunt.Notifications;
using System;

namespace SchoolOccurrences.Shared.Commons.Entities
{
    // Classe que será herdada por todos os models. Geração do ID automatica. Abstrata para que não se implemente nada.
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public void ChangeId(Guid id)
        {
            this.Id = id;
        }
    }
}
