using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float _timeToLoad = 2f;

    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    public void LoadGame()
    {
        _scoreKeeper.ResetScore();
        SceneManager.LoadScene("GameScene");

    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadScene(string SceneName)
    {
        //SceneManager.LoadScene(SceneName);
        StartCoroutine(LoadingScene(_timeToLoad, SceneName));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadingScene(float Delay, string Name)
    {
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene(Name);
    }
}
