using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCSharp.Models
{
    public class Veiculos
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public short Ano { get; set; }
        public Veiculos(int id, string marca, string modelo, short ano)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
        }
    }
}