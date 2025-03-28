using UnityEngine;
using UnityEngine.InputSystem;

public class TVButton : MonoBehaviour
{
    private Camera _mainCamera;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    
    public void OnCLick(InputAction.CallbackContext context)
    {
         if (!context.started) return;

          var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

           if (!rayHit.collider)
        {
            Debug.Log("No valid object clicked");
            return;
        }
        if(rayHit.collider.CompareTag("RemoteButton")){
            string buttonName = rayHit.collider.gameObject.name;
            Debug.Log($"Code: {buttonName}");
        }

    }
}
