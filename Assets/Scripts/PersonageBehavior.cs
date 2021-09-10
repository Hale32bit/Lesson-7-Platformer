using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(IPersonageControl))]
public abstract class PersonageBehavior : MonoBehaviour
{
    protected IPersonageControl _personage;

    private void Awake()
    {
        _personage = GetComponent<IPersonageControl>();
    }
}
