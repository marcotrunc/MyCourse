using System.Data;
using System.Data.SqlClient;

namespace MyCourse.Models.Services.Infrastructure
{
    public class SqlServerDatabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(string query)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=MyCourse.db;Integrated Security=True;Pooling=False"))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataSet dataSet = new DataSet();
                        do
                        {
                            DataTable dataTable = new DataTable();
                            dataSet.Tables.Add(dataTable);
                            dataTable.Load(reader);
                        } while (!reader.IsClosed);
                        return dataSet;
                    }
                }
            }
        }
    }
}
