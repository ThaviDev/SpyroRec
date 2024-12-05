using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAutoDestroy : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 1f);
    }
}
