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
        public  ResponseObject CreateCollegeClass(CollegeClass collegeClass)
        {

            if (_classRepository.HasClassWithSameName(collegeClass))
            {
                throw new Exception($"Já existe uma turma com o nome {collegeClass.Turma}");

            };
           return  _classRepository.CreateCollegeClass(collegeClass);

            
        }

        public ResponseObject EditCollegeClass(CollegeClass collegeClass)
        {
            var result =  _classRepository.EditCollegeClass(collegeClass);

            return result;
        }

        public  List<CollegeClass> GetAllClass()
        {
            var result = _classRepository.GetAllClass();

            return result;
        }

        public ResponseObject InactivateCollegeClass(CollegeClass collegeClass)
        {
            var result =  _classRepository.InactivateCollegeClass(collegeClass);

            return result;
        }
    }
    
}
