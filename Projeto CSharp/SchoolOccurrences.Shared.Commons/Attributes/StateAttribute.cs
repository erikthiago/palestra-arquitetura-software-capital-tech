using System;

namespace SchoolOccurrences.Shared.Commons.Attributes
{
    //Usada no enum dos estados para que possa informar a sigla e nome do estado
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class StateAttribute : Attribute
    {
        public StateAttribute(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }

        public string Sigla { get; private set; }
        public string Nome { get; private set; }
    }
}
