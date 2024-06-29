using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MHDecora.Site.Infra.Repositories
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly string _connectionString;
        public OrcamentoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleDbConnection");
        }
        public async Task<bool> EnviarOrcamento(Orcamento orcamento)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                                                INSERT INTO TABELA_CARLAO (CAMPO_CARLAO, CAMPO_CARLAO, CAMPO_CARLAO, CAMPO_CARLAO, CAMPO_CARLAO, CAMPO_CARLAO)
                                                VALUES (:Nome, :Email, :Telefone, :Data, :NoDate, :Mensagem)";

                        command.Parameters.Add(new OracleParameter("CAMPO_CARLAO", orcamento.Nome));
                        command.Parameters.Add(new OracleParameter("CAMPO_CARLAO", orcamento.Email));
                        command.Parameters.Add(new OracleParameter("CAMPO_CARLAO", orcamento.Telefone));
                        command.Parameters.Add(new OracleParameter("CAMPO_CARLAO", orcamento.Data));
                        command.Parameters.Add(new OracleParameter("CAMPO_CARLAO", orcamento.AindaNaoDefiniODia ? 1 : 0));
                        command.Parameters.Add(new OracleParameter("CAMPO_CARLAO", orcamento.MaisInformacoes));

                        int result = await command.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
