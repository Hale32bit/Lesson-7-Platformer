using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatroolingAI : PersonageBehavior
{
    [SerializeField] Transform[] _waypoints;

    private Action _currentAction;

    private int _currentWaypointIndex = 0;
    private float _distanceToWaypoint;

    private Transform CurrentWaypoint => _waypoints[_currentWaypointIndex];

    private void Start()
    {
        _currentAction = Personage.Right;
    }

    private void Update()
    {
        UpdateDistance();
        _currentAction?.Invoke();
    }

    private void UpdateDistance()
    {
        float newDistance = CalculateDistance();
        if (newDistance > _distanceToWaypoint)
        {
            NextWaypoint();
            newDistance = CalculateDistance();
        }
        _distanceToWaypoint = newDistance;
    }

    private float CalculateDistance()
    {
        return Mathf.Abs(this.transform.position.x - CurrentWaypoint.position.x);
    }

    private void NextWaypoint()
    {
        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        if (this.transform.position.x > CurrentWaypoint.position.x)
            _currentAction = Personage.Left;
        else
            _currentAction = Personage.Right;
    }
}
