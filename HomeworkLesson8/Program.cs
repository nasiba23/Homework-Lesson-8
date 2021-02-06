using System;
using System.Data.SqlClient;

namespace HomeworkLesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=NASIBANOSIROVA\SQLEXPRESS;Initial Catalog=Person;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Connected");
                Console.Write("What do you want to do: ");
                string operation = Console.ReadLine();
                int number;

                switch(operation) 
                {
                    case "add":
                    Console.Write("LastName: ");
                    string lastName1 = Console.ReadLine();
                    Console.Write("FirstName: ");
                    string firstName1 = Console.ReadLine();
                    Console.Write("MiddleName: ");
                    string middleName1 = Console.ReadLine();
                    Console.Write("Birthdate: ");
                    string birthDate1 = Console.ReadLine();
                    string sqlExpressionAdd = $"INSERT INTO PEOPLE LastName = {lastName1}, FirstName = {firstName1}, MiddleName = {middleName1}, BirthDate = {birthDate1}";
                    SqlCommand addCommand = new SqlCommand(sqlExpressionAdd, connection);
                    number = addCommand.ExecuteNonQuery();
                    Console.WriteLine("Added: {0}", number);
                    break;
                    case "delete":
                    Console.Write("Enter Id of the entry you want to delete: ");
                    int id1 = Int32.Parse(Console.ReadLine());
                    string sqlExpressionDelete = $"DELETE FROM PEOPLE WHERE Id = {id1}";
                    SqlCommand deleteCommand = new SqlCommand(sqlExpressionDelete, connection);
                    number = deleteCommand.ExecuteNonQuery();
                    Console.WriteLine("Added: {0}", number);
                    break;
                    case "select all":
                    string sqlExpressionSelectAll = "SELECT * FROM People";
                    SqlCommand SelectAllCommand = new SqlCommand(sqlExpressionSelectAll, connection);
                    SqlDataReader reader = SelectAllCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"" +
                        $"Id: {reader["Id"]}, \t" +
                        $"LastName: {reader["LastName"]}, \t" +
                        $"FirstName: {reader["FirstName"]}, \t" +
                        $"MiddleName: {reader["MiddleName"]}, \t" +
                        $"BirthDate: {reader["BirthDate"]}, \t");
                    }
                    break;
                    case "select by id":
                    Console.Write("Enter Id of the entry you want to see: ");
                    int id2 = Int32.Parse(Console.ReadLine());
                    string sqlExpressionSelectById = $"SELECT FROM PEOPLE WHERE ID = {id2}";
                    SqlCommand SelectByIdCommand = new SqlCommand(sqlExpressionSelectById, connection);
                    object entry = SelectByIdCommand.ExecuteScalar();
                    Console.WriteLine(entry);
                    break;
                    case "update":
                    Console.Write("Enter Id of the entry you want to update: ");
                    int id3 = Int32.Parse(Console.ReadLine());
                    Console.Write("New LastName: ");
                    string lastName2 = Console.ReadLine();
                    Console.Write("New FirstName: ");
                    string firstName2 = Console.ReadLine();
                    Console.Write("New MiddleName: ");
                    string middleName2 = Console.ReadLine();
                    Console.Write("New BirthDate: ");
                    string birthDate2 = Console.ReadLine();
                    string sqlExpressionUpdate = $"UPDATE PEOPLE LastName = {lastName2}, FirstName = {firstName2}, MiddleName = {middleName2}, BirtDate = {birthDate2}";
                    SqlCommand updateCommand = new SqlCommand(sqlExpressionUpdate);
                    number = updateCommand.ExecuteNonQuery();
                    break;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Disconnected");
                }
            }
        }
    }
}
