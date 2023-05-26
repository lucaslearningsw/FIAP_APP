using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.Student;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace FIAP_APP.InfraData.SQL.Repositories.Student
{
    public class StudentRepository : IStudentRepository
    {

        private readonly IConfiguration _configuration;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Domain.Models.Student> CreateStudent(Domain.Models.Student student)
        {

            try
            {
                var query = "INSERT INTO ALUNO (nome, usuario,senha) values (@nome, @usuario, @senha)" +
                               "SELECT CAST(SCOPE_IDENTITY() AS int)";

                var parameters = new DynamicParameters();

                parameters.Add("nome", student.Nome, DbType.String);
                parameters.Add("usuario", student.Usuario, DbType.String);
                parameters.Add("senha", student.Senha, DbType.String);

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var id = await connection.QuerySingleAsync<int>(query, parameters);

                    var createdStudent = new Domain.Models.Student
                    {
                        Id = id,
                        Nome = student.Nome,
                        Usuario = student.Usuario,
                        Senha = student.Senha,
                    };

                    return createdStudent;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error para criar usuario {ex.Message}");
            }

        }

        public async Task EditStudent(Domain.Models.Student student)
        {
            try
            {
                var query = "UPDATE ALUNO SET nome = @nome, usuario = @usuario, senha = @senha where Id = @id";

                var parameters = new DynamicParameters();

                parameters.Add("nome", student.Nome, DbType.String);
                parameters.Add("usuario", student.Usuario, DbType.String);
                parameters.Add("senha", student.Senha, DbType.String);
                parameters.Add("Id", student.Id, DbType.Int32);

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

        public  List<Domain.Models.Student> GetAllStudents()
        {
            try
            {
                var query = "SELECT * FROM ALUNO";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result =  connection.Query<Domain.Models.Student>(query).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error ao selecionar lista de alunos {ex.Message}");
            }


        }

        public async Task<Domain.Models.Student> GetStudent(int id)
        {
            try
            {
                var query = "SELECT * FROM ALUNO WHERE Id = @Id";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<Domain.Models.Student>(query, new { id });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro para selecionar estudante{ex.Message}");
            }
           
        }

        public async Task<Domain.Models.Student> InactivateStudent(Domain.Models.Student student)
        {
            throw new NotImplementedException();
        }

    }
}
