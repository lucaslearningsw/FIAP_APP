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
 
           await ValidateClass(collegeClass);

           return await _classRepository.CreateCollegeClass(collegeClass);
        }



        public async Task EditCollegeClass(CollegeClass collegeClass)
        {
            await ValidateClass(collegeClass);

            await _classRepository.EditCollegeClass(collegeClass);
        }


        public async Task<CollegeClass> GetCollegeClass(int id)
        {
            try
            {
                var collegeClasse = await _classRepository.GetCollegeClass(id);
             
                return collegeClasse;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async Task ValidateClass(CollegeClass collegeClass)
        {
            if (collegeClass.Data.Date < DateTime.Now.Date)
            {
                throw new Exception($"Não é possível criar turma com datas anteriores a atual");
            }

            var result = await _classRepository.HasClassWithSameName(collegeClass.Turma.ToUpper());
            if (result != null)
            {
                throw new Exception($"Já existe uma turma com o nome {collegeClass.Turma}");
            };
        }

        public  List<CollegeClass> GetAllClass()
        {
            try
            {
                var result = _classRepository.GetAllClass();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task InactivateCollegeClass(int id)
        {
            await  _classRepository.InactivateCollegeClass(id);

        }
    }
    
}
