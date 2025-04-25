using UnityEngine;
using UnityEngine.UI;
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
        if(isGameOver) {
            return;
        }
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = $"Time: {minutes:00}:{seconds:00}";
        } else {
            remainingTime = 0;
            timerText.text = "Time: 00:00";

            // TO FIX: set the clues inactive when the game over bg is active
            if (room != null)
            {
                Collider2D[] colliders = room.GetComponentsInChildren<Collider2D>(true);
                foreach (var col in colliders)
                {
                    col.enabled = false;
                }
            }
            isGameOver = true;

            if (gameOverBG != null) {
                gameOverBG.SetActive(true);
            }
        }



        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        timerText = GameObject.Find("Timer")?.GetComponent<TextMeshProUGUI>();
    }

    public float GetRemainingTime()
        {
            return remainingTime;
        }

    public void PlayAgain() {
        isGameOver = false;
        gameOverBG.SetActive(false);
        totalTime = 600f;
        remainingTime = totalTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";
        
    }
}
