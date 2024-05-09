using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyAi2 : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public PlayerController player;
    private PlayerHelth _player;
    private Health _health;

    public bool IsAlive()
    {
        return _health.isAlive();
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;

        _player = player.GetComponent<PlayerHelth>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(player.transform.position);
    }
}
