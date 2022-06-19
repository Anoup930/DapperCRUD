using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperWebAPI.Models
{
    public class EmployeeRepository 
    {
        private readonly string conStr;

        public EmployeeRepository()
        {
            conStr = "DefaultConnection": "server=DESKTOP-D81NGBO;database=mytestdb;trusted_connection=true;"
                " Integrated";
                " Security=true";
                     
            
        }

       

        public IDbConnection Connection 
        {
            get 
            {
                return new SqlConnection(conStr);
            }
        
        }


        //INSERT
        public void Add(Employee employee) 
        {
 
            using (IDbConnection dbConnection = Connection) 
            {
                string sql = @"
                           insert into dbo.Employee
                           (EmployeeName,Department,DateOfJoining,PhotoFileName)
                           values (@EmployeeName,@Department,@DateOfJoining,@PhotoFileName)
                            ";
                dbConnection.Open();
                dbConnection.Execute(sql, employee);
                dbConnection.Close();
            }
        }

        //GET ALL
        public IEnumerable<Employee> GetAll() 
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"
                            select EmployeeId, EmployeeName,Department,
                            convert(varchar(10),DateOfJoining,120) as DateOfJoining,PhotoFileName
                            from
                            dbo.Employee
                            ";
                dbConnection.Open();
                return dbConnection.Query<Employee>(sql);

                dbConnection.Close();
                
                
            }
        }

        
        //GET BY ID
        public Employee GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT * FROM dbo.Employee WHERE EmployeeId=@id";
                dbConnection.Open();
                return dbConnection.Query<Employee>(sql, new {Id=id}).FirstOrDefault();
                dbConnection.Close();

            }
        }
        //UPDATE
        public void Update(Employee employee)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"
                            update dbo.Employee
                            set EmployeeName= @EmployeeName,
                            Department=@Department,
                            DateOfJoining=@DateOfJoining,
                            PhotoFileName=@PhotoFileName
                            where EmployeeId=@EmployeeId
                            ";

                dbConnection.Open();
                dbConnection.Query(sql,employee);
                dbConnection.Close();

            }
        }

        //DELETE

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"
                            delete from dbo.Employee
                            where EmployeeId=@EmployeeId
                            ";
                dbConnection.Open();
                dbConnection.Query(sql, new { Id=id});
                dbConnection.Close();

            }
        }
    }
}
