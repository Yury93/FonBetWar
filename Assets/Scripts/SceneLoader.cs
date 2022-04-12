using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : SingletonBase<SceneLoader>
{
    [SerializeField] private string nameMenu, nameNextGame;
    [SerializeField] private GameObject resultGO;
    [SerializeField] private Text resultText;
    [SerializeField] private Text numberLevelTxt;


    private void Start()
    {
        Camp.OnDestroyCampEnemy += OnMenu;
        Camp.OnDestroyCampPlayer += NextGame;
        resultGO.SetActive(false);

        numberLevelTxt.gameObject.SetActive(false);

        StartCoroutine(CorTextNumberLvl());

        IEnumerator CorTextNumberLvl()
        {
            yield return new WaitForSeconds(0.3f);
            numberLevelTxt.gameObject.SetActive(true);
            numberLevelTxt.text = $"Level {SceneManager.GetActiveScene().buildIndex}";

            yield return new WaitForSeconds(1.5f);
            numberLevelTxt.gameObject.SetActive(false);

        }
    }

    private void NextGame()
    {
        StartCoroutine(CorNextScene());
        resultGO.SetActive(true);
        resultText.text = "YOU WON THE BATTLE, BUT YOU HAVEN'T WON THE WHOLE WAR YET! NEXT LEVEL!";
        IEnumerator CorNextScene()
        {
            yield return new WaitForSeconds(6f);
            SceneManager.LoadSceneAsync(nameNextGame);
            
        }
    }

    public void OnMenu()
    {
        resultGO.SetActive(true);
        StartCoroutine(CorNextScene());
        resultText.text = "YOU LOST THE BATTLE!";
        IEnumerator CorNextScene()
        {
            yield return new WaitForSeconds(6f);
            SceneManager.LoadSceneAsync(nameMenu);
        }
    }
}
