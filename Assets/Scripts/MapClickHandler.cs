using UnityEngine;

public class MapClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject userGuessCanvas;

    private void Awake()
    {
        userGuessCanvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (userGuessCanvas != null) {
            userGuessCanvas.SetActive(true);
        }
        else {
            Debug.Log("Error setting the canvas active");
        }
    }
}
