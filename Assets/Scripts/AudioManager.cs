using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource clue; 
    public AudioSource negative;
    public AudioSource unlocked;
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

    public void PlayClue()
    {
        if (clue != null)
        {
            clue.Play();
        }
        else
        {
            Debug.LogError("Clue AudioSource is not assigned.");
        }
    }

    public void PlayNegative()
    {
        if (negative != null)
        {
            negative.Play();
        }
        else
        {
            Debug.LogError("Negative AudioSource is not assigned.");
        }
    }

    public void PlayUnlocked()
    {
        if (unlocked != null)
        {
            unlocked.Play();
        }
        else
        {
            Debug.LogError("Unlocked AudioSource is not assigned.");
        }
    }
}
