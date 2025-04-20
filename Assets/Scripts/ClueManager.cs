using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public static ClueManager instance;

    public bool isBookUnlocked = false;
    public bool isTVFound = false;
    public bool isPaintingUnlocked = false;
    public bool isDrawerUnlocked = false;

    public bool isPaintingAttemptWrong = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
