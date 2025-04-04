using UnityEngine;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
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

        if (!rayHit.collider)
        {
            Debug.Log("No valid object clicked");
            AudioManager.instance.PlayNegative();
            return;
        }

        // Log the object info and change scene based on its name.
        if(rayHit.collider.CompareTag("Clue")){
            string objectName = rayHit.collider.gameObject.name;
            Debug.Log($"Object Name: {objectName}");
            
            // Scene names HAVE TO FOLLOW a naming convention like "ObjectNameScene"
            string sceneToLoad = objectName + "Scene";
            AudioManager.instance.PlayClue();

            if(string.Equals(objectName, "Painting")){
                if(ClueManager.instance.isPaintingUnlocked){
                    sceneToLoad = "OpenPaintingScene";
                }
            }

            if(string.Equals(objectName, "Drawer")){
                if(ClueManager.instance.isDrawerUnlocked){
                    sceneToLoad = "OpenDrawerScene";
                }
            }

            
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
