using System;
using System.Data.SqlClient;

Dictionary<int, string> workoutTablesDict = new Dictionary<int, string>
{
    {1, "AbWorkouts"},
    {2, "BackWorkouts"},
    {3, "BicepWorkouts"},
    {4, "ChestWorkouts"},
    {5, "LegWorkouts"},
    {6, "ShoulderWorkouts"},
    {7, "TricepWorkouts"},
};

while (true)
{
    string? workoutTable = SelectSetofWorkouts(workoutTablesDict);

    Console.WriteLine("-----------------------------------------\n");

    EditWorkoutTable(workoutTable);

}

string SelectSetofWorkouts(Dictionary<int, string> workoutTablesDict)
{
    Console.WriteLine("Which set of workouts would you like to see? \n\nAbs (1) \nBack (2) \nBiceps (3) \nChest (4) \nLegs (5) \n" +
            "Shoulders (6) \nTriceps (7) \n");

    string? workoutTable = null;
    while (workoutTable == null)
    {
        workoutTable = Console.ReadLine();
        Console.WriteLine();
        if (!int.TryParse(workoutTable, out int userInputInt) || userInputInt < 1 || userInputInt > 7)
        {
            Console.WriteLine("Not an accepted number!");
            workoutTable = null;
        }
        else
        {
            workoutTable = workoutTablesDict[userInputInt];
            Console.WriteLine("-----------------------------------------");
            FitnessApp.Database.Read(workoutTable);
        }
    }

    return workoutTable;
}

void EditWorkoutTable(string workoutTable)
{
    Console.WriteLine("What would you like to do? \n\nInsert new workout (1) \nRename existing workout (2) \n" +
            "Delete existing workout (3) \nGo back (4) \n");

    string? tableCommand = null;
    while (tableCommand == null)
    {
        tableCommand = Console.ReadLine();
        Console.WriteLine();
        if (!int.TryParse(tableCommand, out int userInputInt) || userInputInt < 1 || userInputInt > 4)
        {
            Console.WriteLine("Not an accepted number!");
            tableCommand = null;
        }
        else if (userInputInt == 1)
        {
            WorkoutInsertion(workoutTable);
        }
        else if (userInputInt == 2)
        {
            bool wasSuccessful = false;
            string? workoutToBeUpdated = null;
            string? workoutNewName = null;

            while (workoutToBeUpdated == null)
            {
                Console.WriteLine("Enter workout name you'd like to update as appears in list.");
                workoutToBeUpdated = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(workoutToBeUpdated))
                {
                    Console.WriteLine("Not a valid name!");
                    workoutToBeUpdated = null;
                }
            }

            while (workoutNewName == null)
            {
                Console.WriteLine("Enter new name of workout.");
                workoutNewName = Console.ReadLine();
                Console.WriteLine();

                if (String.IsNullOrWhiteSpace(workoutNewName))
                {
                    Console.WriteLine("Not a valid name!");
                    workoutNewName = null;
                }
            }



        }
        else if (userInputInt == 3)
        {
            FitnessApp.Database.Delete();
        }
        else
        {
            return;
        }
    }
}

void WorkoutInsertion(string workoutTable)
{
    bool wasSuccessful = false;
    string? newWorkout = null;

    while (newWorkout == null || wasSuccessful == false)
    {
        Console.WriteLine("Enter name of new workout to add");
        newWorkout = Console.ReadLine();
        Console.WriteLine();

        if (string.IsNullOrWhiteSpace(newWorkout))
        {
            Console.WriteLine("Not a valid name!");
            newWorkout = null;
        }
        else
        {
            wasSuccessful = FitnessApp.Database.Insert(workoutTable, newWorkout);
        }
    }
}