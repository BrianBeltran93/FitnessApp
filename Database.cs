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

            SqlConnection conn;

            constr = @"Data Source=localhost;Initial Catalog=WorkoutDatabase;User ID=sa;Password=t3ddy123";

            conn = new SqlConnection(constr);

            conn.Open();

            SqlCommand cmd;

            SqlDataAdapter adap = new SqlDataAdapter();

            string sql = "";

            sql = "update LegWorkouts set Name='Hip Thrust' where Name='Hip Thrusts'";

            cmd = new SqlCommand(sql, conn);

            adap.InsertCommand = new SqlCommand(sql, conn);

            adap.InsertCommand.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        internal static void Delete()
        {
            string constr;

            SqlConnection conn;

            constr = @"Data Source=localhost;Initial Catalog=WorkoutDatabase;User ID=sa;Password=t3ddy123";

            conn = new SqlConnection(constr);

            conn.Open();

            SqlCommand cmd;

            SqlDataAdapter adap = new SqlDataAdapter();

            string sql = "";

            sql = "delete from LegWorkouts where Name='Romanian Deadlift'";

            cmd = new SqlCommand(sql, conn);

            adap.InsertCommand = new SqlCommand(sql, conn);

            adap.InsertCommand.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
    }
}
