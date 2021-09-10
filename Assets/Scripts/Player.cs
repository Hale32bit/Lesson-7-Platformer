using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PersonageBehavior
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _personage.Jump();
        if (Input.GetKey(KeyCode.A))
            _personage.Left();
        if (Input.GetKey(KeyCode.D))
            _personage.Right();
    }
}
