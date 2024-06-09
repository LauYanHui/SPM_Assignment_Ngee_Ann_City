// See https://aka.ms/new-console-template for more information


//Leaderboard

using SPM_Assignment_Ngee_Ann_City;
using System.Collections.Immutable;

void DisplayLeaderboard()
{
    Console.WriteLine("Leaderboard" + "\n");

    SortedDictionary<User, int> userDict = new SortedDictionary<User, int>();
    User user0 = new User("test12120","password0",false,0);
    User user1 = new User("test1", "password1", false, 20);
    User user2 = new User("test2", "password2", false, 90);
    User user3 = new User("test3", "password3", false, 100);
    User user4 = new User("test4", "password4", false, 50);
    User user5= new User("test5", "password5", false, 60);
    User user6 = new User("test6", "password6", false, 70);
    User user7 = new User("test7", "password7", false, 75);
    User user8 = new User("test8", "password8", false, 10);
    User user9 = new User("test9", "password9", false, 30);



    userDict.Add(user0,user0.Points);
    userDict.Add(user1, user1.Points);
    userDict.Add(user2, user2.Points);
    userDict.Add(user3, user3.Points);
    userDict.Add(user4, user4.Points);
    userDict.Add(user5, user5.Points);
    userDict.Add(user6, user6.Points);
    userDict.Add(user7, user7.Points);
    userDict.Add(user8, user8.Points);
    userDict.Add(user9, user9.Points);

    Console.WriteLine("--------------------------------");
    Console.WriteLine("\tName"+"           Points");
    Console.WriteLine("--------------------------------");
    int count = 1;
    foreach(KeyValuePair<User,int> kvp in userDict)
    {
        Console.WriteLine(String.Format("{0}:\t{1,-15}{2}",count,kvp.Key.Name,kvp.Value));
        count++;
    }
    Console.WriteLine("--------------------------------");
}

DisplayLeaderboard();