using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defuseTrapAreaScript : MonoBehaviour
{
    public bool yes;
    public Font font;

    private bool ColEnter;

    private GUIStyle guiStyle = new GUIStyle();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ColEnter = false;
    }

    void Start()
    {
        yes = false;
        ColEnter = false;

        r = new Rect(Screen.width / 2 - 100, Screen.height - 300, 500, 700);

        guiStyle.fontSize = 40;
        guiStyle.normal.textColor = Color.white;
        guiStyle.font = font;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) && ColEnter)
            yes = true;
    }

    private string message = "Нажмите 'E'";

    private Rect r;

    void OnGUI()
    {
        if (ColEnter)
        {
           // guiStyle.normal.textColor = Color.white;
            GUI.Label(r, message, guiStyle);
        } else
        {
           // guiStyle.normal.textColor = Color.black;
            //GUI.Label(r, message, guiStyle);
        }
    }

}
