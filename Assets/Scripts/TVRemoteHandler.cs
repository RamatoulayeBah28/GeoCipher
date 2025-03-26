using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TVRemoteHandler : MonoBehaviour
{
     private Camera _mainCamera;
    
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    [SerializeField]
    public string codeText = "";
    private void Awake()
    {
        _mainCamera = Camera.main;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        
        if (!context.started) 
        return;
    var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        // checking that what the ray hits is not null and it's the object with the tag "Book"
        if (!rayHit.collider)
        {

            Debug.Log("No valid object clicked");
            return;
        }

        if(codeText.Length >= 2){
            codeText = "";
        }


        if (rayHit.collider.CompareTag("RemoteButton1"))
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {rayHit.collider.tag}");
            codeText = "1";
            Debug.Log($"Code: {codeText}");
            

           
            

        }
        else if (rayHit.collider.CompareTag("RemoteButton2"))
        {
            Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {rayHit.collider.tag}");


           
           
        }

        else if (rayHit.collider.CompareTag("RemoteButton3"))
        {
            Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {rayHit.collider.tag}");


            
           
        }
        else if (rayHit.collider.CompareTag("RemoteButton4"))
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
           
            Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {rayHit.collider.tag}");

            
           
        }

        else if (rayHit.collider.CompareTag("RemoteButton5"))
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            
            Debug.Log($"Object Name: {rayHit.collider.gameObject.name}, Tag: {rayHit.collider.tag}");

        }

      
    }
}
