using UnityEngine;
using UnityEngine.InputSystem;

public class TVScene : MonoBehaviour
{
     private Camera _mainCamera;
    
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    [SerializeField]
    GameObject codePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       _mainCamera = Camera.main;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);  
    }

    // Update is called once per frame
    void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider)
        {
            Debug.Log("No valid object clicked");
            return;
        }
        if (rayHit.collider.CompareTag("TV"))
        {
            Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {rayHit.collider.tag}");


            // when clicked, go to TV scene
            SceneController.instance.ChangeScene("TVScene");
        }
         else if (rayHit.collider.CompareTag("ExitTV"))
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            // Successfully hit the game object
            Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {rayHit.collider.tag}");

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
    }
}
