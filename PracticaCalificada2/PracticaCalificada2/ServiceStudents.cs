using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ServiceModel.Activation;
using System.ServiceModel;

namespace PracticaCalificada2
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceStudents:IServiceStudents
    {

        DAL objDal = new DAL();

        public Student CreateStudent(Student createPerson)
        {
            return objDal.saveStudent(createPerson);
        }

        public List<Student> GetAllStudents()
        {
            return objDal.GetAllStudents();
        }

        public Student GetStudentByID(string ID)
        {
            return objDal.GetStudentByID(ID);
        }

        public Student UpdateStudent(string ID, Student updatePerson)
        {
            return objDal.UpdateStudent(ID,updatePerson);
        }

        public void DeleteStudent(string ID)
        {
            objDal.DeletePersona(ID);
        }

        public List<Student> GetSearchStudents(string query)
        {
            return objDal.GetSearchStudents(query);
        }
    }


}