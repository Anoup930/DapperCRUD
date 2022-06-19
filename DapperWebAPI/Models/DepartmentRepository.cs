using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DapperWebAPI.Models
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly string conStr;

        public DepartmentRepository(string ConnectionString)
        {
            conStr = ConnectionString;

        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(conStr);
            }

        }


        //INSERT
        public void Add(Department dep)
        {
            
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"
                             insert into dbo.Department
                             values (@DepartmentName)
                             ";
                dbConnection.Open();
                dbConnection.Execute(sql, dep);
                dbConnection.Close();
            }
        }

        //GET ALL
        public IEnumerable<Department> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"
                             select DepartmentId, DepartmentName from
                             dbo.Department
                            ";

                dbConnection.Open();
                return dbConnection.Query<Department>(sql);

                dbConnection.Close();


            }
        }



        //UPDATE
        public void Update(Department dep)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"
                            update dbo.Department
                            set DepartmentName= @DepartmentName
                            where DepartmentId=@DepartmentId
                            ";

                dbConnection.Open();
                dbConnection.Query(sql, dep);
                dbConnection.Close();

            }
        }

        //DELETE

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"
                            delete from dbo.Department
                            where DepartmentId=@DepartmentId
                            ";
                dbConnection.Open();
                dbConnection.Query(sql, new { Id = id });
                dbConnection.Close();

            }
        }
    }
}

