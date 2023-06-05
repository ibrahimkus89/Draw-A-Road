using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LibraryPro
{
    
    public class GeneralManagement
    {
        public static GameManager _GameManager;

        public GeneralManagement(GameManager _gameManager)
        {

            _GameManager = _gameManager;
        }
    }

   
    
    public static class MemoryManagement
    {

        public static void SaveDataInt(string Key,int Value)
        {
            PlayerPrefs.SetInt(Key, Value);
        }

        public static int ReadDataInt(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }


        public static void SaveDataString(string Key, string Value)
        {
            PlayerPrefs.SetString(Key, Value);
        }

        public static string ReadDataString(string Key)
        {
            return PlayerPrefs.GetString(Key);
        }

        public static bool IsThereKey(string Key)
        {
            return PlayerPrefs.HasKey(Key);

        }


    }

    
}
