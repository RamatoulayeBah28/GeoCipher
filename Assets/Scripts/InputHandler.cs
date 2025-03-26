using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        // checking that what the ray hits is not null
        if (!rayHit.collider)
        {
            Debug.Log("No valid object clicked");
            return;
        }

        // x symbol when clicking on it, goes back to sample scene
        else if (rayHit.collider.CompareTag("Exit"))
        {
            // Successfully hit the game object
            Debug.Log("Exiting");

            // when clicked, go to openBook scene
            if (SceneController.instance != null)
            {
                SceneController.instance.ChangeScene("Scenes/RoomScene");
            }
            else
            {
                Debug.LogError("SceneController instance is null. Make sure it's added to the scene.");
            }
        }
        else {
            string tag = rayHit.collider.tag.ToString();
            Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {tag}");

            string scene = tag + "Scene";
            SceneController.instance.ChangeScene(scene);
        }
    }
}
