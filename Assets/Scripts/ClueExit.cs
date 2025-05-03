using UnityEngine;

public class ClueExit : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Exit button clicked");
        if (SceneController.instance != null)
        {
            SceneController.instance.ChangeScene("Scenes/RoomScene");
        }
        else
        {
            Debug.LogError("SceneController instance is null. Make sure it's added to the scene.");
        }
        AudioManager.instance.PlayClue();
    }
}
