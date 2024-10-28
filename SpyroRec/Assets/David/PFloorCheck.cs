using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFloorCheck : MonoBehaviour
{
    [SerializeField] PlayerManager _pMan;
    private void OnTriggerEnter(Collider col)
    {
        _pMan.SetGrounded(true);
    }
    private void OnTriggerExit(Collider col)
    {
        _pMan.SetGrounded(false);
    }
}
