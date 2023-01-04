using JovemProgramadorMvc2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc2.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        AlunoModel Inserir(AlunoModel aluno);

        List<AlunoModel> BuscarAlunos();

        AlunoModel BuscarId(int Id);

        bool Atualizar(AlunoModel aluno);

        bool Excluir(int Id);

        List<AlunoModel> FiltroIdade(int idade, string operacao);

        List<AlunoModel> FiltroNome(string nome);

        List<AlunoModel> FiltroContato(string contato);
        EnderecoModel InserirEndereco(EnderecoModel endereco);
    }
}
