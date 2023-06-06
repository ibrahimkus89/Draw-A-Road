using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] DrawLine[] _Lines;
    [SerializeField] private int LineRight;
    private int ActiveLineIndex;

    GeneralManagement _GeneralManagement;
    [SerializeField] CarControl _CarControl;

    private bool _GameOver;
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
        _GameOver=true;
        Debug.Log("win");
    }
    public void Lost()
    {
        _CarControl.Go = false;
        Debug.Log("lost");
    }
    void GoToCar()
    {
        _CarControl.Go = true;
        Invoke("CheckTheCar",4f);
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
    void CheckTheCar()
    {
        if (!_GameOver)
        {
            Lost();
        }
    }


}
