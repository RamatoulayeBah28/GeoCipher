using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float totalTime = 600f;
    private float remainingTime;
    public TextMeshProUGUI timerText;

    public GameObject gameOverBG;

    public GameObject room;
    private bool isGameOver = false;

    public GameObject playButton;

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

    void Start()
    {
        remainingTime = totalTime;
        gameOverBG.SetActive(false);
    }

    void Update()
    {
        if (isGameOver || timerText == null)
        {
            return;
        }

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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        timerText = GameObject.Find("Timer")?.GetComponent<TextMeshProUGUI>();
        UpdateTimerText();
    }

    public float GetRemainingTime()
    {
        return remainingTime;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    void EndGame()
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
