using System.Collections;
using System.Collections.Generic;
using LibraryPro;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    static GameObject Instance;
    void Start()
    {

        if (MemoryManagement.ReadDataInt("GameSound") == 0)
        {
            GetComponent<AudioSource>().mute = true;
        }

        DontDestroyOnLoad(gameObject);

        if (Instance == null)
            Instance = gameObject;
        else
            Destroy(gameObject);
    }
}
