using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_cursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTex;

    private Vector2 cursorHost;

    void Start()
    {
        cursorHost = new Vector2(cursorTex.width / 2, cursorTex.height / 2);
        Cursor.SetCursor(cursorTex, cursorHost, CursorMode.Auto);
    }
}
