using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoTarefaAPI.Models
{
    public class PaginacaoTarefa<T> where T:class
    {
        public int ContagemTotal { get; set; }
        public int TamanhoPagina { get; set; }
        public int NumeroPaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public bool PaginaAnterior { get; set; }
        public bool ProximaPagina { get; set; }
        public T Data { get; set; }

        public PaginacaoTarefa(T data, int contagemTotal, int numeroPaginaAtual, int tamanhoPagina){
            ContagemTotal = contagemTotal;
            Data = data;
            NumeroPaginaAtual = numeroPaginaAtual;
            TamanhoPagina = tamanhoPagina;

            TotalPaginas = (int)Math.Ceiling((double)ContagemTotal / (double)TamanhoPagina);
        
            PaginaAnterior = NumeroPaginaAtual > 1;
            ProximaPagina = NumeroPaginaAtual < TotalPaginas;
        }
    }
}