using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorChanger : MonoBehaviour
{
    public Texture2D hoverCursor;
    private Vector2 cursorHotspot;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        if (hoverCursor != null)
        {
            cursorHotspot = new Vector2(hoverCursor.width * 5/12, 0);
        }
    }


    void Update()
    {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Input.mousePosition));

        if (rayHit.collider != null)
        {
            Cursor.SetCursor(hoverCursor, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
