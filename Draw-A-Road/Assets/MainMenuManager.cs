using System.Collections;
using System.Collections.Generic;
using LibraryPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Slider _Slider;
    [SerializeField] GameObject _LoadingPanel;

    void Awake()
    {
        if (!MemoryManagement.IsThereKey("Level"))
        {
            MemoryManagement.SaveDataInt("Level", 1);
            MemoryManagement.SaveDataInt("Point", 50);
            MemoryManagement.SaveDataInt("GameSound", 1);
            MemoryManagement.SaveDataInt("EffectSound", 1);

        }
    }

    public void GameStart()
    {
        StartCoroutine(LoadScene(MemoryManagement.ReadDataInt("Level")));

    }
    IEnumerator LoadScene(int SceneIndex)
    {
        AsyncOperation Op = SceneManager.LoadSceneAsync(SceneIndex);
        _LoadingPanel.SetActive(true);
        while (!Op.isDone)
        {
            float prog = Mathf.Clamp01(Op.progress / .9f);
            _Slider.value = prog;
            yield return null;
        }
    }
}
