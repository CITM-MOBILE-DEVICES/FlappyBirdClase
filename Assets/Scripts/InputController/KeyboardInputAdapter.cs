using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputAdapter : IInputAdapter
{
    public bool IsPressingButtonA()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool IsPressingButtonB()
    {
        return Input.GetKeyDown(KeyCode.Return);
    }
}
