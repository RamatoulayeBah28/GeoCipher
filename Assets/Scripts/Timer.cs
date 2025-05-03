using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*
Handles the countdown timer and game win/lose conditions.

By Batsambuu Batbold, Ramatoulaye Bah
*/

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public float totalTime = 600f;
    public TextMeshProUGUI timerText;
    public GameObject gameOverBG;
    public GameObject room;
    public GameObject playButton;

    private float remainingTime;
    private bool isGameOver = false;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        remainingTime = totalTime;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        remainingTime = totalTime;
        if (gameOverBG != null)
        {
            gameOverBG.SetActive(false);
        }
    }

    private void Update()
    {
        if (isGameOver || timerText == null) return;

        if (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            EndGame();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        timerText = GameObject.Find("Timer")?.GetComponent<TextMeshProUGUI>();
        UpdateTimerText();
    }

    public float GetRemainingTime()
    {
        return remainingTime;
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    private void EndGame()
    {
        remainingTime = 0f;
        UpdateTimerText();
        isGameOver = true;

        if (room != null)
        {
            foreach (var col in room.GetComponentsInChildren<Collider2D>(true))
            {
                col.enabled = false;
            }
        }

        if (gameOverBG != null)
        {
            gameOverBG.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        isGameOver = false;
        ResetTimer();

        if (gameOverBG != null)
        {
            gameOverBG.SetActive(false);
        }

        if (room != null)
        {
            foreach (var col in room.GetComponentsInChildren<Collider2D>(true))
            {
                col.enabled = true;
            }
        }

        UpdateTimerText();
    }

    public void ResetTimer()
    {
        remainingTime = totalTime;
    }
}
