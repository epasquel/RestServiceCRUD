using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PracticaCalificada2
{
    [ServiceContract]
    public interface IServiceStudents
    {

        [OperationContract]
        [WebInvoke(UriTemplate = "/students", Method = "POST")]
        Student CreateStudent(Student createPerson);

        [OperationContract]
        [WebGet(UriTemplate = "/students")]
        List<Student> GetAllStudents();

        [OperationContract]
        [WebGet(UriTemplate = "/students/{ID}")]
        Student GetStudentByID(String ID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/students/{ID}", Method = "PUT")]
        Student UpdateStudent(String ID, Student updatePerson);

        [OperationContract]
        [WebInvoke(UriTemplate = "/students/{ID}", Method = "DELETE")]
        void DeleteStudent(String ID);

        [OperationContract]
        [WebGet(UriTemplate = "/students/search/{query}")]
        List<Student> GetSearchStudents(String query);

    }


    #region Student Entity

    [DataContract]
    public class Student
    {
        [DataMember]
        public Int32 Codigo;

        [DataMember]
        public String Nombre;

        [DataMember]
        public String ApellidoPaterno;

        [DataMember]
        public String ApellidoMaterno;

        [DataMember]
        public Int32 Edad;
        
    }

    #endregion

}
