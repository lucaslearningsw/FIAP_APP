﻿using Dapper;
using FIAP_APP.Domain.Repositories.CollegeClass;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using FIAP_APP.Domain.Models;


namespace FIAP_APP.InfraData.SQL.Repositories.CollegeClass
{
    public class CollegeClassRepository : ICollegeClassRepository
    {

        private readonly IConfiguration _configuration;

        public CollegeClassRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Domain.Models.CollegeClass> CreateCollegeClass(Domain.Models.CollegeClass collegeClass)
        {
            try
            {
                var query = "INSERT INTO TURMA (turma, ano) values (@turma, @ano)" +
                               "SELECT CAST(SCOPE_IDENTITY() AS int)";

                var parameters = new DynamicParameters();

                parameters.Add("turma", collegeClass.Turma, DbType.String);
                parameters.Add("ano", collegeClass.Data.Year, DbType.Int32);

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var id = await connection.QuerySingleAsync<int>(query, parameters);

                    var createdCollegeClass = new Domain.Models.CollegeClass
                    {
                        Id= id, 
                        Data = collegeClass.Data.Date, 
                        Turma = collegeClass.Turma,
                    };

                    return createdCollegeClass;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error para criar turma {ex.Message}");
            }
        }

        public async Task EditCollegeClass(Domain.Models.CollegeClass collegeClass)
        {
            try
            {
                var query = "UPDATE turma SET turma = @turma, ano = @ano where Id = @id";

                var parameters = new DynamicParameters();

                parameters.Add("turma", collegeClass.Turma, DbType.String);
                parameters.Add("ano", collegeClass.Data.Date.Year, DbType.Int32);
                parameters.Add("Id", collegeClass.Id, DbType.Int32);

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error para criar usuario {ex.Message}");
            }
        }

        public List<Domain.Models.CollegeClass> GetAllClass()
        {
            try
            {
                var query = "SELECT id, turma, ano FROM TURMA";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = connection.Query<Domain.Models.CollegeClass>(query).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error ao selecionar lista de alunos {ex.Message}");
            }
        }

        public async Task<Domain.Models.CollegeClass> GetCollegeClass(int id)
        {

            try
            {
                var query = "SELECT * FROM turma WHERE Id = @id";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<Domain.Models.CollegeClass>(query, new { id });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro para selecionar turma{ex.Message}");
            }
        }

        public async Task<Domain.Models.CollegeClass> HasClassWithSameName(string className)
        {
            try
            {
                var query = "SELECT * FROM turma WHERE UPPER(turma) = @className";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<Domain.Models.CollegeClass>(query, new { className });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro para selecionar turma{ex.Message}");
            }
           
        }

        public async Task InactivateCollegeClass(int id)
        {
            try
            {
                var query = "DELETE FROM turma where Id = @id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error para excluir turma {ex.Message}");
            }
        }
    }
}
