using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.ManagerRelationCollegeClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Services.ManagerRelationClassStudent
{
    public class ManagerRelationClassStudentService
    {
        private readonly IManagerRelationCollegeClassRepository _managerRelationRepository;

        public ManagerRelationClassStudentService(IManagerRelationCollegeClassRepository managerRelationRepository)
        {
            _managerRelationRepository = managerRelationRepository;
        }
        public List<RelationsClassStudent> GetRelationsClassStudent()
        {
            var result = _managerRelationRepository.GetRelationsClassStudent();
            return result;
        }

        public Task InativateRelation(int userId, int collegeClassId)
        {
            throw new NotImplementedException();
        }

        public Task RelateCollegeWithStudent(int userId, int collegeClassId)
        {
            throw new NotImplementedException();
        }

        public Task GetAllStudentsFromCollegeClass(int collegeClassId)
        {
            throw new NotImplementedException();
        }


    }

    
}
