using UnityEngine;
using UnityEngine.SceneManagement;

/*
Handles cursor changes when hovering over clickable objects.
The cursor image should be assigned in the Unity editor.

By Batsambuu Batbold
*/

public class CursorChanger : MonoBehaviour
{
    public Texture2D hoverCursor;

    private Vector2 hotspot;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;

        if (hoverCursor != null)
        {
            hotspot = new Vector2(hoverCursor.width * 5 / 12, 0);
        }
    }

    private void Update()
    {
        var hit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));

        if (hit.collider != null)
        {
            Cursor.SetCursor(hoverCursor, hotspot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
