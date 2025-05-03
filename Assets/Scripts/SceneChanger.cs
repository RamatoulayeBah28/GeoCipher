using UnityEngine;
using UnityEngine.InputSystem;

/*
Handles the transition between clue items and their respective scenes.

By Ramatoulaye Bah, edited by Batsambuu Batbold and Ahmed Abdelhai
*/

public class SceneChanger : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider)
        {
            Debug.Log("No valid object clicked");
            AudioManager.instance.PlayNegative();
            return;
        }

        if (rayHit.collider.CompareTag("Clue"))
        {
            string objectName = rayHit.collider.gameObject.name;
            Debug.Log($"Object Name: {objectName}");

            // Scene name format: "ObjectNameScene"
            string sceneToLoad = objectName + "Scene";

            // If object is unlocked: "ObjectNameOpenScene"
            if (ClueManager.instance.IsUnlocked(objectName))
            {
                sceneToLoad = objectName + "OpenScene";
            }

            AudioManager.instance.PlayClue();

            if (SceneController.instance != null)
            {
                SceneController.instance.ChangeScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("SceneController instance is null. Make sure it's added to the scene.");
            }
        }
    }
}
