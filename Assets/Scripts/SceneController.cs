using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private SceneFade _sceneFade;
    // public void InteractiveClues() {
    //     SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    // }
    private void Awake()
    {
        
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            _sceneFade = GetComponentInChildren<SceneFade>();
        }
        else {
            Destroy(gameObject);
        }
    }
    private IEnumerator Start()
    {
        yield return _sceneFade.FadeInCoroutine();
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return _sceneFade.FadeOutCoroutine();
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return _sceneFade.FadeInCoroutine();
    }
}
