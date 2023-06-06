using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] DrawLine[] _Lines;
    [SerializeField] private int LineRight;
    private int ActiveLineIndex;


    private GeneralManagement _GeneralManagement;

    void Awake()
    {
        _GeneralManagement = new(this);
    }

    void Start()
    {
        /* for (int i = 0; i <_Lines.Length; i++) //Optional
        {
            if (ActiveLineIndex!=i)
            {
                _Lines[i].enabled = false;
            }
        }*/
    }

    public void Win()
    {
        Debug.Log("win");
    }

    public void Lost()
    {
        Debug.Log("lost");
    }

    void GoToCar()
    {
        Debug.Log("let the car move");
    }
    public void LineisOver()
    {
        LineRight--;

        _Lines[ActiveLineIndex].enabled = false;

        if (ActiveLineIndex!=_Lines.Length-1)
        {
            ActiveLineIndex++; 
            _Lines[ActiveLineIndex].enabled = true;

        }

        if (LineRight==0)
        {
            GoToCar();
        }
    }


}
