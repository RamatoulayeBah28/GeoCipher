using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("Scenes/RoomScene");
        // SceneController.instance.ChangeScene("Scenes/RoomScene");
    }

    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
