using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Entities
{
    public class Moto
    {
        public string Identificador { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;

        protected Moto() { } // Construtor privado para EF
        public Moto(string identificador, int ano, string modelo, string placa)
        {
            Identificador = identificador;
            Ano = ano;
            Modelo = modelo;
            Placa = placa;
        }

        // Factory method
        public static Moto Criar(string identificador, string modelo, int ano, string placa)
        {
            return new Moto
            {
                Identificador = identificador,
                Modelo = modelo,
                Ano = ano,
                Placa = placa
            };
        }

        public void AlterarPlaca(string novaPlaca)
        {
            if (string.IsNullOrWhiteSpace(novaPlaca))
                throw new InvalidOperationException("A nova placa não pode ser vazia.");

            if (novaPlaca == Placa)
                throw new InvalidOperationException("A nova placa é igual à placa atual.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(novaPlaca, @"^[A-Z]{3}-\d{4}$"))
                throw new InvalidOperationException("Placa inválida. O formato correto é ABC-1234.");

            Placa = novaPlaca;

        }
    }
}
