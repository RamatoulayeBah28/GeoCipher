using UnityEngine;

/*
Handles main audio feedback for the player,
such as playing sounds for clues, errors, or successful interactions.
Assign all AudioSource fields in the Unity editor.

By Batsambuu Batbold
*/

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

    public void PlayClue() => PlayAudio(clue, "Clue");
    public void PlayNegative() => PlayAudio(negative, "Negative");
    public void PlayUnlocked() => PlayAudio(unlocked, "Unlocked");

    private void PlayAudio(AudioSource source, string label)
    {
        if (source != null)
        {
            source.Play();
        }
        else
        {
            Debug.LogError($"{label} AudioSource is not assigned.");
        }
    }
}
