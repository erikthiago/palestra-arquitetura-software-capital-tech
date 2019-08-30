using System;

namespace SchoolOccurrences.Shared.Commons.Interfaces.IQuery
{
    // Interface responsável por implementar o Id e reuso de código
    public interface IQuery
    {
        Guid Id { get; set; }
    }
}
