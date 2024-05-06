using UnityEngine;

public class SelectButtonCursor : MonoBehaviour
{
    public Texture2D _cursorDef;
    public Vector2 cursorDef;

    public Texture2D _cursorButtonSelect;
    public Vector2 cursorOffset;
    public void OnButtonCursorEnter() => Cursor.SetCursor(_cursorButtonSelect, cursorOffset, CursorMode.Auto);

    public void OnButtonCursorExit() => Cursor.SetCursor(_cursorDef, cursorDef, CursorMode.Auto);
}
