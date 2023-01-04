using JovemProgramadorMvc2.Data.Repositorio.Interfaces;
using JovemProgramadorMvc2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JovemProgramadorMvc2.Controllers
{
    public class AlunoController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunorepositorio;

        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunorepositorio = alunoRepositorio;
        }

        public IActionResult Index(AlunoModel filtroAluno)
        {
            List<AlunoModel> aluno = new();

            if (filtroAluno.Idade > 0)
            {
                aluno = _alunorepositorio.FiltroIdade(filtroAluno.Idade, filtroAluno.Operacao);
            }
            if (filtroAluno.Nome != null)
            {
                aluno = _alunorepositorio.FiltroNome(filtroAluno.Nome);
            }

            if (filtroAluno.Contato != null)
            {
                aluno = _alunorepositorio.FiltroContato(filtroAluno.Contato);
            }

            return View(_alunorepositorio.BuscarAlunos());
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Mensagem()
        {
            return View();
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            EnderecoModel enderecoModel = new();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();

                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(
                        await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });

                    if (enderecoModel.complemento == "")
                    {
                        enderecoModel.complemento = "Nenhum";

                    }

                    if (enderecoModel.logradouro == "")
                    {
                        enderecoModel.logradouro = "Cep Geral";
                    }
                }

                else
                {
                    ViewData["Mensagem"] = "Erro na busca do endereço!";
                    return View("Index");
                }
            }

            catch (Exception e)
            {

            }

            return View("BuscarEndereco", enderecoModel);
        }

        [HttpPost]
        public IActionResult Inserir(AlunoModel aluno)
        {
            var retorno = _alunorepositorio.Inserir(aluno);
            if (retorno != null)
            {
                TempData["Mensagem2"] = "Dados gravados com sucesso";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int Id)
        {
            var aluno = _alunorepositorio.BuscarId(Id);
            return View("Editar", aluno);
        }

        public IActionResult Atualizar(AlunoModel aluno)
        {
            var retorno = _alunorepositorio.Atualizar(aluno);

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int Id)
        {
            var retorno = _alunorepositorio.Excluir(Id);

            if (retorno)
            {
                TempData["Mensagem3"] = "Aluno excluído com sucesso";
            }

            else
            {
                TempData["Mensagem3"] = "Erro ao excluir aluno";
            }

            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> BuscarEndereco(AlunoModel aluno)
        //{
        //    var retorno = _alunorepositorio.BuscarId(aluno.Id);
        //    aluno = retorno;
        //    EnderecoModel enderecoModel = new();
        //}
    }
}
