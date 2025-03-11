using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    // public Texture2D defaultTexture;
    // public Texture2D examineTexture;
    // public CursorMode curMode = CursorMode.Auto;
    // public Vector2 hotSpot = Vector2.zero;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        _mainCamera = Camera.main;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public void OnClick(InputAction.CallbackContext context) {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        // checking that what the ray hits is not null and it's the object with the tag "Book"
        if (!rayHit.collider) {

            Debug.Log("No valid object clicked");
            return;        
        }

        if (rayHit.collider.CompareTag("Book")) {
             Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            // Successfully hit the game object
            Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {rayHit.collider.tag}");

            // when clicked, go to openBook scene
            SceneController.instance.ChangeScene("BookScene");
        }else if(rayHit.collider.CompareTag("TV")){
             Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {rayHit.collider.tag}");
            

            // when clicked, go to TV scene
            SceneController.instance.ChangeScene("TVScene");
        }
        
    }

}
