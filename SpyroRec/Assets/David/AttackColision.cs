using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var isEnemy = other.GetComponent<EnemyMotor>();
        if (isEnemy != null)
        {
            Destroy(other.gameObject);
        }
    }
}
