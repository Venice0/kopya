using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using WindowsFormsApp7;

public static class UserDataManager
{
    private const string filePath = "userData.dat";

    public static void SaveUserData(List<UserData> userDataList)
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, userDataList);
            stream.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving user data: {ex.Message}");
        }
    }

    public static List<UserData> LoadUserData()
    {
        List<UserData> userDataList = new List<UserData>();

        try
        {
            if (File.Exists(filePath))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                userDataList = (List<UserData>)formatter.Deserialize(stream);
                stream.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading user data: {ex.Message}");
        }

        return userDataList;
    }
}

