using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Entities
{
    public class Entregador
    {
        public string Identificador { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string NumeroCNH { get; set; } = string.Empty;
        public string TipoCNH { get; set; } = string.Empty;
        public string? ImagemCNHUrl { get; set; } = string.Empty;

        protected Entregador() { }

        public Entregador(string identificador, string nome, string cnpj, DateTime dataNascimento, string numeroCnh, string tipoCnh)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório");

            if (string.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("CNPJ é obrigatório");

            if (string.IsNullOrWhiteSpace(numeroCnh))
                throw new ArgumentException("Número da CNH é obrigatório");

            if (!new[] { "A"}.Contains(tipoCnh))
                throw new ArgumentException("Tipo de CNH inválido. Valores aceitos: A");

            Identificador = identificador;
            Nome = nome;
            CNPJ = cnpj;
            DataNascimento = dataNascimento;
            NumeroCNH = numeroCnh;
            TipoCNH = tipoCnh;
        }

        public void AtualizarFotoCNH(string caminhoCompleto)
        {
            if (string.IsNullOrWhiteSpace(caminhoCompleto))
                throw new ArgumentException("O caminho da CNH não pode ser vazio.");

            ImagemCNHUrl = caminhoCompleto;
        }
    }
}