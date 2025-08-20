using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Entregador.UploadCNH
{
    public class UploadCNHResult
    {
        public string Identificador { get; set; } = string.Empty;
        public string CaminhoArquivo { get; set; } = string.Empty;
        public bool Sucesso { get; set; }
    }
}
