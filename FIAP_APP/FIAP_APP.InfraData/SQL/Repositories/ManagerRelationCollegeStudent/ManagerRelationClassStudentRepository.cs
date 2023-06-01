using Dapper;
using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.ManagerRelationCollegeClass;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FIAP_APP.InfraData.SQL.Repositories.ManagerRelationCollegeStudent
{
    public class ManagerRelationClassStudentRepository : IManagerRelationCollegeClassRepository
    {
        private readonly IConfiguration _configuration;

        public ManagerRelationClassStudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task GetAllStudentsFromCollegeClass(int collegeClassId)
        {
            throw new NotImplementedException();
        }

        public List<RelationsClassStudent> GetRelationsClassStudent()
        {
            try
            {
                var query = "SELECT TURMA.turma as CollegeName, turma.id as CollegeClassID, aluno.nome as StudentName ,aluno.id as StudentId FROM  aluno_turma" +
                    "\r\nINNER JOIN TURMA \r\nON turma.id = aluno_turma.turma_id" +
                    "\r\ninner join aluno \r\non aluno.id =  aluno_turma.aluno_id";

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = connection.Query<RelationsClassStudent>(query).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error ao selecionar lista de de relações Aluno e Classes {ex.Message}");
            }
        }

        public Task InativateRelation(int userId, int collegeClassId)
        {
            throw new NotImplementedException();
        }

        public Task RelateCollegeWithStudent(int userId, int collegeClassId)
        {
            throw new NotImplementedException();
        }
    }
}
