using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager 
{
    public static void SaveData(string dataName,int value)
    {
        PlayerPrefs.SetInt(dataName, value);
    }
    public static void SaveData(string dataName, float value)
    {
        PlayerPrefs.SetFloat(dataName, value);
    }
    public static int GetData(string dataName)
    {
        return PlayerPrefs.GetInt(dataName);
    }
    public static float GetFloatData(string dataName)
    {
        return PlayerPrefs.GetFloat(dataName);
    }

}
