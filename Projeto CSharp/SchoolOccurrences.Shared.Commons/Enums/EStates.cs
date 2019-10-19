using SchoolOccurrences.Shared.Commons.Attributes;

namespace SchoolOccurrences.Shared.Commons.Enums
{
    public enum  EStates
    {
        [State(sigla: "AC", nome: "Acre")]
        AC = 1,
        [State(sigla: "AL", nome: "Alagoas")]
        AL = 2,
        [State(sigla: "AP", nome: "Amapá")]
        AP = 3,
        [State(sigla: "AM", nome: "Amazonas")]
        AM = 4,
        [State(sigla: "BA", nome: "Bahia")]
        BA = 5,
        [State(sigla: "CE", nome: "Ceará")]
        CE = 6,
        [State(sigla: "DF", nome: "Distrito Federal")]
        DF = 7,
        [State(sigla: "ES", nome: "Espírito Santo")]
        ES = 8,
        [State(sigla: "GO", nome: "Goiás")]
        GO = 9,
        [State(sigla: "MA", nome: "Maranhão")]
        MA = 10,
        [State(sigla: "MT", nome: "Mato Grosso")]
        MT = 11,
        [State(sigla: "MS", nome: "Mato Grosso do Sul")]
        MS = 12,
        [State(sigla: "MG", nome: "Minas Gerais")]
        MG = 13,
        [State(sigla: "PA", nome: "Pará")]
        PA = 14,
        [State(sigla: "PB", nome: "Paraíba")]
        PB = 15,
        [State(sigla: "PR", nome: "Paraná")]
        PR = 16,
        [State(sigla: "PE", nome: "Pernambuco")]
        PE = 17,
        [State(sigla: "PI", nome: "Piauí")]
        PI = 18,
        [State(sigla: "RN", nome: "Rio Grande do Norte")]
        RN = 19,
        [State(sigla: "RS", nome: "Rio Grande do Sul")]
        RS = 20,
        [State(sigla: "RJ", nome: "Rio de Janeiro")]
        RJ = 21,
        [State(sigla: "RO", nome: "Rondônia")]
        RO = 22,
        [State(sigla: "RR", nome: "Roraima")]
        RR = 23,
        [State(sigla: "SC", nome: "Santa Catarina")]
        SC = 24,
        [State(sigla: "SP", nome: "São Paulo")]
        SP = 25,
        [State(sigla: "SE", nome: "Sergipe")]
        SE = 26,
        [State(sigla: "TO", nome: "Tocantins")]
        TO = 27
    }
}
