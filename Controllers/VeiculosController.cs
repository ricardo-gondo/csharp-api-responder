using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCSharp.Models;

namespace WebApiCSharp.Controllers
{
    public class VeiculosController : ApiController
    {
        public static List<Veiculos> listaVeiculos = new List<Veiculos>();

        [HttpGet]
        [Route("api/veiculos/popular")]
        public JObject Popular()
        {
            listaVeiculos.Add(new Veiculos(1,"Ford","Fiesta",2023));
            listaVeiculos.Add(new Veiculos(2,"Honda", "Civic", 2022));
            //return "populado";
            var resultado = JObject.Parse("{resultado: \"populado\"}");
            return resultado;
        }
        // GET api/values
        //public string Get()
        public List<Veiculos> Get()
        {
            //return JsonConvert.SerializeObject(listaVeiculos);
            return listaVeiculos;
        }

        // GET api/values/5
        //public string Get(int id)
        public Veiculos Get(int id)
        {
            //return JsonConvert.SerializeObject(listaVeiculos.Find(x=>x.Id.Equals(id)));
            return listaVeiculos.Find(x => x.Id.Equals(id));
        }

        // POST api/values
        public JObject Post([FromBody] Veiculos veiculo)
        {
            var resultado = "";
            if (veiculo.Id == 0)
                resultado = "{resultado: \"Id não pode ser nulo\"}";

            if (String.IsNullOrEmpty(resultado))
                { 
                listaVeiculos.Add(new Veiculos(veiculo.Id, veiculo.Marca, veiculo.Modelo, veiculo.Ano));
                resultado = "{resultado : \"ok\"}";
                }
            return JObject.Parse(resultado);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Veiculos veiculo)
        {
            var v = listaVeiculos.Single(x => x.Id.Equals(id));
            v.Marca = veiculo.Marca;
            v.Modelo = veiculo.Modelo;
        }

        // DELETE api/values/5
        [HttpGet]
        [Route("api/veiculos/excluir/{id}")]
        //public string Excluir(int id)
        public JObject Excluir(int id)
        {
            var veiculo = listaVeiculos.Single(x => x.Id.Equals(id));
            listaVeiculos.Remove(veiculo);
            //return "ok";
            var resultado = JObject.Parse("{resultado: \"ok\"}");
            return resultado;
        }

        public void Delete(int id)
        {
            int item = listaVeiculos.FindIndex(x => x.Id.Equals(id));
            listaVeiculos.RemoveAt(item);
        }
    }
}
