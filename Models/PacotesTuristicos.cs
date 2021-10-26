using System;

namespace Atv_2.Models
{
    public class PacotesTuristicos
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Origem {get;set;}
        public string Destino {get;set;}
        public string Atrativos {get;set;}
        public DateTime Saida {get;set;}
        public DateTime Retorno {get;set;}
        public int Usuario {get;set;}
    }
}