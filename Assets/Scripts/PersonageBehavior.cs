using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(IPersonageControl))]
public abstract class PersonageBehavior : MonoBehaviour
{
    protected IPersonageControl Personage;

    private void Awake()
    {
        Personage = GetComponent<IPersonageControl>();
    }
}
