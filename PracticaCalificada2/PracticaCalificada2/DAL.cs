using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PracticaCalificada2
{
    public class DAL
    {

        private SqlConnection conn;
        private static string connString = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        private SqlCommand command;
        private static List<Student> empList;

        public Student saveStudent(Student emp)
        {
            try
            {
                using (conn)
                {
                    Student objStudent = new Student();
                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "up_saveStudent";

                    SqlParameter nombres = new SqlParameter("@Nombre", emp.Nombre);
                    SqlParameter apePat = new SqlParameter("@ApellidoPaterno", emp.ApellidoPaterno);
                    SqlParameter apeMat = new SqlParameter("@ApellidoMaterno", emp.ApellidoMaterno);
                    SqlParameter edad = new SqlParameter("@Edad", emp.Edad);

                    command.Parameters.AddRange(new SqlParameter[] { nombres, apePat, apeMat, edad });
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) {
                        while (reader.Read())
                        {
                            objStudent.Nombre = reader.GetString(0);
                            objStudent.ApellidoPaterno = reader.GetString(1);
                            objStudent.ApellidoMaterno = reader.GetString(2);
                            objStudent.Edad = reader.GetInt32(3);
                            objStudent.Codigo = reader.GetInt32(4);
                        }
                    }
                    
                    
                    command.Connection.Close();

                    return objStudent;

                }
            }
            catch (Exception ex)
            {
                //err.ErrorMessage = ex.Message.ToString();
                throw;
            }

        }


        public Student UpdateStudent(String ID, Student emp)
        {
            try
            {
                using (conn)
                {
                    Student objStudent = new Student();
                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "up_updateStudent";

                    SqlParameter codigo = new SqlParameter("@Codigo", ID);
                    SqlParameter nombres = new SqlParameter("@Nombre", emp.Nombre);
                    SqlParameter apePat = new SqlParameter("@ApellidoPaterno", emp.ApellidoPaterno);
                    SqlParameter apeMat = new SqlParameter("@ApellidoMaterno", emp.ApellidoMaterno);
                    SqlParameter edad = new SqlParameter("@Edad", emp.Edad);

                    command.Parameters.AddRange(new SqlParameter[] { codigo, nombres, apePat, apeMat, edad });

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            objStudent.Nombre = reader.GetString(0);
                            objStudent.ApellidoPaterno = reader.GetString(1);
                            objStudent.ApellidoMaterno = reader.GetString(2);
                            objStudent.Edad = reader.GetInt32(3);
                            objStudent.Codigo = reader.GetInt32(4);
                        }
                    }
                    command.Connection.Close();

                    return objStudent;
                }
            }
            catch (Exception ex)
            {
                //err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public void DeletePersona(String iD)
        {
            try
            {
                using (conn)
                {
                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "up_deleteStudent";

                    SqlParameter IDparam = new SqlParameter("@Codigo", iD);
                    command.Parameters.Add(IDparam);
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                //err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }


        public Student GetStudentByID(String ID)
        {
            try
            {
                Student objStudent = new Student();

                conn = new SqlConnection(connString);

                command = new SqlCommand();
                command.Connection = conn;
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "up_getStudentByID";

                SqlParameter IDparam = new SqlParameter("@Codigo", ID);
                command.Parameters.Add(IDparam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objStudent.Nombre = reader.GetString(0);
                        objStudent.ApellidoPaterno = reader.GetString(1);
                        objStudent.ApellidoMaterno = reader.GetString(2);
                        objStudent.Edad = reader.GetInt32(3);
                        objStudent.Codigo = reader.GetInt32(4);
                    }
                }
                command.Connection.Close();

                return objStudent;
            }
            catch (Exception ex)
            {
                //err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }


        public List<Student> GetAllStudents()
        {
            try
            {
                using (conn)
                {
                    empList = new List<Student>();

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "up_getAllStudents";


                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student objStudent = new Student();
                        objStudent.Nombre = reader.GetString(0);
                        objStudent.ApellidoPaterno = reader.GetString(1);
                        objStudent.ApellidoMaterno = reader.GetString(2);
                        objStudent.Edad = reader.GetInt32(3);
                        objStudent.Codigo = reader.GetInt32(4);
                        empList.Add(objStudent);
                    }
                    command.Connection.Close();
                    return empList;
                }

            }
            catch (Exception ex)
            {
                //err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }


        public List<Student> GetSearchStudents(String query)
        {
            try
            {
                using (conn)
                {
                    empList = new List<Student>();

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "up_getSearchStudents";

                    SqlParameter IDparam = new SqlParameter("@query", query);
                    command.Parameters.Add(IDparam);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student objStudent = new Student();
                        objStudent.Nombre = reader.GetString(0);
                        objStudent.ApellidoPaterno = reader.GetString(1);
                        objStudent.ApellidoMaterno = reader.GetString(2);
                        objStudent.Edad = reader.GetInt32(3);
                        objStudent.Codigo = reader.GetInt32(4);
                        empList.Add(objStudent);
                    }
                    command.Connection.Close();
                    return empList;
                }

            }
            catch (Exception ex)
            {
                //err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }


    }
}