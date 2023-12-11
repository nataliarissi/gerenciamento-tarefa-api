using GerenciamentoTarefaAPI.Models;
using System.Text.RegularExpressions;
using Xunit;

namespace GerenciamentoTarefasAPI.Testes
{
    public class TarefaTests
    {
        [Fact]
        public void AlteracaoValida_Id0_Erro()
        {
            Tarefa tarefa = new Tarefa();

            tarefa.Id = 0; 

            var resultado = tarefa.AlteracaoValida();

            Assert.Equal("Id menor ou igual a 0", resultado);
        }

        [Fact]
        public void AlteracaoValida_TituloMaior50_Erro()
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = 1;
            tarefa.Titulo = "Aliquam pretium dignissim eros, quis accumsan enim porta a. Quisque dignissim egestas tellus eu tempor. Suspendisse sapien lectus, tincidunt ac maximus ac, iaculis ac dolor. Sed mattis purus ut elementum aliquet. Sed ut dolor laoreet, fermentum libero non, ornare tortor. Integer congue non arcu sit amet scelerisque. Donec pharetra, diam.";

            var resultado = tarefa.AlteracaoValida();

            Assert.Equal("T�tulo possui mais de 50 caracteres", resultado);
        }

        [Fact]
        public void AlteracaoValida_DescricaoMaior100_Erro()
        {
            Tarefa tarefa = new Tarefa();

            tarefa.Descricao = "Preparar bolinhos de chuva, receita simples e afetiva, fritos at� a perfei��o, um deleite doce que encanta a todos com seu sabor caseiro e textura irresist�vel";
            tarefa.Id = 1;
            tarefa.Titulo = "Fazer Bolinhos de Chuva";
            tarefa.DataCriacao = DateTime.Now;

            var resultado = tarefa.AlteracaoValida();

            Assert.Equal("Descri��o ultrapassa de 100 caracteres", resultado);
        }

        [Fact]
        public void AlteracaoValida_DataCriacao_Erro()
        {
            Tarefa tarefa = new Tarefa();

            tarefa.DataCriacao = DateTime.Now.AddHours(-10);
            tarefa.Id = 1;
            tarefa.Titulo = "O Pequeno Pr�ncipe";
            tarefa.Descricao = "Em sua jornada, o Pequeno Pr�ncipe passa por v�rios planetas antes de chegar na Terra.";

            var resultado = tarefa.AlteracaoValida();

            Assert.Equal("A data de cria�ao � menor que a data atual", resultado);
        }
    }
}