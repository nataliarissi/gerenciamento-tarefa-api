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
        public int MyProperty { get; set; }
        public int NumeroPaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public bool PaginaAnterior { get; set; }
        public bool ProximaPagina { get; set; }
        public T Data { get; set; }

        public PaginacaoTarefa(int contagemTotal, T data, int numeroPaginaAtual, int tamanhoPagina){
            ContagemTotal = contagemTotal;
            Data = data;
            NumeroPaginaAtual = numeroPaginaAtual;
            TamanhoPagina = tamanhoPagina;

            TotalPaginas = (int)Math.Ceiling((double)TotalPaginas / (double)TamanhoPagina);
        
            PaginaAnterior = NumeroPaginaAtual > 1;
            ProximaPagina = NumeroPaginaAtual < TotalPaginas;
        }
    }
}