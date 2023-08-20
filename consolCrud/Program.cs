
using System.Data.SqlClient;

namespace consolCrud;
internal class Program
{
    private static void Main(string[] args)
    {
        
        string connectionString = @"Data Source='Add Server name here' ;Initial Catalog=Consol_app;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        try
        {
            
            Console.WriteLine("Connection established successfully!");

            string answer;

            do
            {
                Console.WriteLine("Select from the option below \n1.Create\n2.Read\n3.Update\n4.Delete ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //Create => CRUD_C
                        Console.WriteLine("Enter your name");
                        string user_name = Console.ReadLine();
                        Console.WriteLine("Enter your age");
                        int user_age = int.Parse(Console.ReadLine());

                        string insertQuery = "INSERT INTO Details(user_name,user_age) VALUES ('" + user_name + "'," + user_age + ")";

                        SqlCommand insertcommand = new SqlCommand(insertQuery, sqlConnection);
                        insertcommand.ExecuteNonQuery();
                        Console.WriteLine("Data is successfully inserted into table");
                        break;
                    case 2:
                        //Read => CRUD_R
                        string displayQuery = "SELECT * FROM Details";
                        SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                        SqlDataReader dataReader = displayCommand.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Console.WriteLine("ID: " + dataReader.GetValue(0).ToString());
                            Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                            Console.WriteLine("Age: " + dataReader.GetValue(2).ToString());
                        }
                        dataReader.Close();
                        break;

                    case 3:
                        //Update => CRUD_U
                        int u_id;
                        int u_age;

                        Console.WriteLine("Enter the user id that you would like to update ");
                        u_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the age of the user");
                        u_age = int.Parse(Console.ReadLine());

                        string updateQuery = "UPDATE Details SET user_age = " + u_age + " WHERE user_id = " + u_id + "";

                        SqlCommand updatecommand = new SqlCommand(updateQuery, sqlConnection);
                        updatecommand.ExecuteNonQuery();

                        Console.WriteLine("User age is updated");
                        break;
                    case 4:
                        //Delete => CRUD_D
                        int ud_id;
                        Console.WriteLine("Enter the id of the record that is to be deleted");
                        ud_id = int.Parse(Console.ReadLine());

                        string deleteQuery = "DELETE FROM Details WHERE user_id =" + ud_id + "";

                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                        deleteCommand.ExecuteNonQuery();
                        Console.WriteLine("Deleted successfully");
                        break;

                    default:
                        Console.WriteLine("Invalide Input");
                        break;

                }

                Console.WriteLine("Do you want to continue? ");
                answer = Console.ReadLine().ToLower();

            } while (answer != "no");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally { sqlConnection.Close(); }
    }
}