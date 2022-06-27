using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FitnessApp
{
    internal static class Database
    {
        internal static void Read(string workoutTable)
        {
            string constr;

            SqlConnection conn;

            constr = @"Data Source=localhost;Initial Catalog=WorkoutDatabase;User ID=sa;Password=t3ddy123";

            conn = new SqlConnection(constr);

            conn.Open();

            SqlCommand cmd;

            SqlDataReader dreader;

            string sql, output = "";

            sql = $"Select Name from {workoutTable} order by Name";

            cmd = new SqlCommand(sql, conn);

            dreader = cmd.ExecuteReader();

            while (dreader.Read())
            {
                output = output + dreader.GetValue(0) + "\n";
            }

            Console.Write(output);

            dreader.Close();
            cmd.Dispose();

            conn.Close();
        }

        internal static bool Insert(string workoutTable, string newWorkout)
        {
            string constr;

            SqlConnection conn;

            constr = @"Data Source=localhost;Initial Catalog=WorkoutDatabase;User ID=sa;Password=t3ddy123";

            conn = new SqlConnection(constr);

            conn.Open();

            SqlCommand cmd;

            SqlDataAdapter adap = new SqlDataAdapter();

            string sql = "";

            sql = $"insert into {workoutTable} values('{newWorkout}')";

            cmd = new SqlCommand(sql, conn);

            adap.InsertCommand = new SqlCommand(sql, conn);

            try
            {
                adap.InsertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Console.WriteLine("Workout already exists.");
                    cmd.Dispose();
                    conn.Close();
                    return false;
                }
            }
;
            cmd.Dispose();
            conn.Close();
            return true;
        }

        internal static void Update()
        {
            string constr;

            // for the connection to
            // sql server database
            SqlConnection conn;

            // Data Source is the name of the
            // server on which the database is stored.
            // The Initial Catalog is used to specify
            // the name of the database
            // The UserID and Password are the credentials
            // required to connect to the database.
            constr = @"Data Source=localhost;Initial Catalog=WorkoutDatabase;User ID=sa;Password=t3ddy123";

            conn = new SqlConnection(constr);

            // to open the connection
            conn.Open();

            // use to perform read and write
            // operations in the database
            SqlCommand cmd;

            // data adapter object is use to
            // insert, update or delete commands
            SqlDataAdapter adap = new SqlDataAdapter();

            string sql = "";

            // use the define sql
            // statement against our database
            sql = "update LegWorkouts set Name='Hip Thrust' where Name='Hip Thrusts'";

            // use to execute the sql command so we
            // are passing query and connection object
            cmd = new SqlCommand(sql, conn);

            // associate the insert SQL
            // command to adapter object
            adap.InsertCommand = new SqlCommand(sql, conn);

            // use to execute the DML statement against
            // our database
            adap.InsertCommand.ExecuteNonQuery();

            // closing all the objects
            cmd.Dispose();
            conn.Close();
        }

        internal static void Delete()
        {
            string constr;

            // for the connection to
            // sql server database
            SqlConnection conn;

            // Data Source is the name of the
            // server on which the database is stored.
            // The Initial Catalog is used to specify
            // the name of the database
            // The UserID and Password are the credentials
            // required to connect to the database.
            constr = @"Data Source=localhost;Initial Catalog=WorkoutDatabase;User ID=sa;Password=t3ddy123";

            conn = new SqlConnection(constr);

            // to open the connection
            conn.Open();

            // use to perform read and write
            // operations in the database
            SqlCommand cmd;

            // data adapter object is use to
            // insert, update or delete commands
            SqlDataAdapter adap = new SqlDataAdapter();

            string sql = "";

            // use the define SQL statement
            // against our database
            sql = "delete from LegWorkouts where Name='Romanian Deadlift'";

            // use to execute the sql command so we
            // are passing query and connection object
            cmd = new SqlCommand(sql, conn);

            // associate the insert SQL
            // command to adapter object
            adap.InsertCommand = new SqlCommand(sql, conn);

            // use to execute the DML statement
            // against our database
            adap.InsertCommand.ExecuteNonQuery();

            // closing all the objects
            cmd.Dispose();
            conn.Close();
        }
    }
}
