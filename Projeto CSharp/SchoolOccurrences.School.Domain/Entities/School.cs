using Flunt.Validations;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.Shared.Commons.Entities;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using System.Collections.Generic;

namespace SchoolOccurrences.School.Domain.Entities
{
    public class School : Entity
    {
        //Utilizado pelo entity
        public School()
        {

        }

        //Utilizado para anticorrupção de código
        public School(string name, Document document, Address address, string phone)
        {
            Name = name;
            Document = document;
            Address = address;
            Phone = phone;

            AddNotifications(new Contract()
               .Requires()
               //Validações sobre o nome
               .IsNotNullOrEmpty(Name, "Name", SharedMessages.InvalidStreet)
               .HasMinLen(Name, 3, "Name", string.Format(SharedMessages.MinLength, "Nome", 3))
               .HasMaxLen(Name, 50, "Name", string.Format(SharedMessages.MaxLength, "Nome", 50))
               //Validação do telefone
               .IsNotNullOrEmpty(Phone, "Phone", SharedMessages.InvalidPhone)
               );
        }

        //Propriedades
        public string Name { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public string Phone { get; private set; }

        //Relacionamentos necessários
        public IReadOnlyCollection<Student> Students { get; private set; } = new List<Student>();
    }
}
