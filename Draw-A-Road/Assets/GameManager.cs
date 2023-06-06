using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryPro;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("---GENERAL OBJECTS")]
    [SerializeField] DrawLine[] _Lines;
    [SerializeField] private int LineRight;
    private int ActiveLineIndex;
    private int _SceneIndex;
    GeneralManagement _GeneralManagement;
    private AudioSource _GameSound;
    [SerializeField] CarControl _CarControl;
    private bool _GameOver;


    [Header("---UI OBJECTS")]
    [SerializeField] GameObject[] _Panels;
    [SerializeField] AudioSource[] _Sounds;
    [SerializeField] Image[] _ButonImages;
    [SerializeField] Sprite[] _SpriteObjets;
    [SerializeField] TextMeshProUGUI[] _UITexts;
    void Awake()
    {
        _GeneralManagement = new(this);
        FirstScenePro();
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
        _GameOver = true;
        TurnOnPanel(1);
        PlaySound(2);
        MemoryManagement.SaveDataInt("Level", _SceneIndex + 1);
        MemoryManagement.SaveDataInt("Point", MemoryManagement.ReadDataInt("Point") + 50);
        _UITexts[0].text = MemoryManagement.ReadDataInt("Puan").ToString();
        Time.timeScale = 0;
    }
    public void Lost()
    {
        TurnOnPanel(2);
       PlaySound(1);
        _CarControl.Go = false;
        Time.timeScale = 0;
    }
    void GoToCar()
    {
        _CarControl.Go = true;
        _CarControl.CarSoundControl();
        Invoke("CheckTheCar",4f);
    }
    public void LineisOver()
    {
        LineRight--;
        PlaySound(3);
        _UITexts[1].text = LineRight.ToString();
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

    void TurnOnPanel(int Index)
    {
       _Panels[Index].SetActive(true);
    }
    void TurnOffPanel(int Index)
    {
        _Panels[Index].SetActive(false);
    }
    public void PlaySound(int Index)
    {
        _Sounds[Index].Play();
    }
    void FirstScenePro()
    {

        _UITexts[0].text = MemoryManagement.ReadDataInt("Point").ToString();
        _UITexts[1].text = LineRight.ToString();
        _GameSound = GameObject.FindWithTag("GameSound").GetComponent<AudioSource>();
        _SceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (MemoryManagement.ReadDataInt("GameSound") == 0)
        {

            _ButonImages[0].sprite = _SpriteObjets[1];
            _GameSound.mute = true;
        }
        else
        {
            _ButonImages[0].sprite = _SpriteObjets[0];
            _GameSound.mute = false;
        }


        if (MemoryManagement.ReadDataInt("EffectSound") == 0)
        {
            _ButonImages[1].sprite = _SpriteObjets[3];
            foreach (var item in _Sounds)
            {
                item.mute = true;
            }
        }
        else
        {
            _ButonImages[1].sprite = _SpriteObjets[2];
            foreach (var item in _Sounds)
            {
                item.mute = false;
            }
        }

    }

    public void ButtonTechProcess(string Process)
    {
        switch (Process)
        {

            case "Pause":
                PlaySound(0);
               TurnOnPanel(0);
                Time.timeScale = 0;
                break;

            case "Continue":
                PlaySound(0);
                TurnOffPanel(0);
                Time.timeScale = 1;
                break;

            case "Again":
                PlaySound(0);
                SceneManager.LoadScene(_SceneIndex);
                Time.timeScale = 1;
                break;

            case "NextLevel":
                PlaySound(0);
                SceneManager.LoadScene(_SceneIndex + 1);
                Time.timeScale = 1;
                break;

            case "Exit":
                PlaySound(0);
                TurnOnPanel(3);
                break;

            case "Yes":
                PlaySound(0);
                Application.Quit();
                break;

            case "No":
                PlaySound(0);
                TurnOffPanel(3);
                break;


            case "GameSoundSettings":
                PlaySound(0);

                if (MemoryManagement.ReadDataInt("GameSound") == 0)
                {
                    MemoryManagement.SaveDataInt("GameSound", 1);
                    _ButonImages[0].sprite = _SpriteObjets[0];
                    _GameSound.mute = false;
                }
                else
                {
                    MemoryManagement.SaveDataInt("GameSound", 0);
                    _ButonImages[0].sprite = _SpriteObjets[1];
                    _GameSound.mute = true;
                }

                break;

            case "EffectSoundSettings":
                PlaySound(0);

                if (MemoryManagement.ReadDataInt("EffectSound") == 0)
                {
                    MemoryManagement.SaveDataInt("EffectSound", 1);
                    _ButonImages[1].sprite = _SpriteObjets[2];

                    foreach (var item in _Sounds)
                    {
                        item.mute = false;
                    }

                   _CarControl.SoundManagement(false);
                }
                else
                {
                    MemoryManagement.SaveDataInt("EffectSound", 0);
                    _ButonImages[1].sprite = _SpriteObjets[3];
                    foreach (var item in _Sounds)
                    {
                        item.mute = true;
                    }
                    _CarControl.SoundManagement(true);
                }
                break;

        }

    }


}
