using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.CollegeClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Services
{
    public class CollegeClassService 
    {
        private readonly ICollegeClassRepository _classRepository;

        public CollegeClassService(ICollegeClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task<CollegeClass> CreateCollegeClass(CollegeClass collegeClass)
        {
           var result = await _classRepository.HasClassWithSameName(collegeClass.Turma);
            if (result != null)
            {
                throw new Exception($"Já existe uma turma com o nome {collegeClass.Turma}");
            };

            if(collegeClass.Data.Date < DateTime.Now.Date.Date)
            {
                throw new Exception($"Não é possível criar turma com datas anterior a atual");
            }
           return await _classRepository.CreateCollegeClass(collegeClass);
        }

        public async Task EditCollegeClass(CollegeClass collegeClass)
        {

            await _classRepository.EditCollegeClass(collegeClass);
        }

        public  List<CollegeClass> GetAllClass()
        {
            var result = _classRepository.GetAllClass();

            return result;
        }

        public async Task InactivateCollegeClass(CollegeClass collegeClass)
        {
            await  _classRepository.InactivateCollegeClass(collegeClass);

        }
    }
    
}
