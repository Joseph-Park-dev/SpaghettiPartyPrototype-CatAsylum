using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    private Vector2 cursorPos;
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
