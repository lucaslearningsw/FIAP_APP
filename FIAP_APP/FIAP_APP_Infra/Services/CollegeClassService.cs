using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.CollegeClass;
using FIAP_APP.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Infra.Services
{
    public class CollegeClassService : ICollegeClassService
    {
        private readonly ICollegeClassRepository _classRepository;

        public CollegeClassService(ICollegeClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task<ResponseObject> CreateCollegeClass(CollegeClass collegeClass)
        {

            if (await _classRepository.HasClassWithSameName(collegeClass))
            {
                return new ResponseObject()
                {
                    code = 303,
                    message = $"Já existe uma classe com o nome {collegeClass.Turma}"
                };

            };
           return  await _classRepository.CreateCollegeClass(collegeClass);

            
        }

        public async Task<ResponseObject> EditCollegeClass(CollegeClass collegeClass)
        {
            var result = await  _classRepository.EditCollegeClass(collegeClass);

            return result;
        }

        public async Task<List<CollegeClass>> GetAllClass()
        {
            var result = await _classRepository.GetAllClass();

            return result;
        }

        public async Task<ResponseObject> InactivateCollegeClass(CollegeClass collegeClass)
        {
            var result = await _classRepository.InactivateCollegeClass(collegeClass);

            return result;
        }
    }
    
}
