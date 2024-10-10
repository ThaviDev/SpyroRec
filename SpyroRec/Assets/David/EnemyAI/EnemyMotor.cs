using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMotor : MonoBehaviour
{
    [SerializeField] Transform _dest;
    [SerializeField] GameObject _prefabTarget;
    [SerializeField] float visonRadious;
    [SerializeField] GameObject _player;
    NavMeshAgent _myAIPath;
    void Awake()
    {
        _myAIPath = GetComponent<NavMeshAgent>();
        _dest = Instantiate(_prefabTarget).transform;
    }

    // Update is called once per frame
    void Update()
    {
        _myAIPath.destination = _dest.position;
        CheckVisionRadious();
    }

    void CheckVisionRadious()
    {
        var dist = Vector3.Distance(_player.transform.position, this.transform.position);
        if (dist <= visonRadious)
        {
            _dest.position = new Vector3 (_player.transform.position.x,0, _player.transform.position.z);
        } else
        {
            _dest.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, visonRadious);
    }
}
