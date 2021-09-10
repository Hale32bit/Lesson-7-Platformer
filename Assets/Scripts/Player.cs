using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PersonageBehavior
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Personage.Jump();
        if (Input.GetKey(KeyCode.A))
            Personage.Left();
        if (Input.GetKey(KeyCode.D))
            Personage.Right();
    }
}
