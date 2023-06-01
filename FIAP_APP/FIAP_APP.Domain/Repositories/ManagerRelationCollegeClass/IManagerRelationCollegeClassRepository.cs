using FIAP_APP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Repositories.ManagerRelationCollegeClass
{
    public interface IManagerRelationCollegeClassRepository
    {
        List<RelationsClassStudent> GetRelationsClassStudent();

        Task InativateRelation(int userId, int collegeClassId);
        Task RelateCollegeWithStudent(int userId, int collegeClassId);

        Task GetAllStudentsFromCollegeClass(int collegeClassId);
    }
}
