using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Transform GetWaypoint(int _waypointIndex)
    {
        return transform.GetChild(_waypointIndex);
    }

    public int GetNextWaypointIndex(int _currentWaypointIndex)
    {
        int _nextWaypointIndex = _currentWaypointIndex + 1;

        if (_nextWaypointIndex == transform.childCount) 
        { 
            _nextWaypointIndex = 0;
        }

        return _nextWaypointIndex;
    }
}
