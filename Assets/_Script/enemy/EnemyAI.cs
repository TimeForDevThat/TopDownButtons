using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> targetPoint;
    private NavMeshAgent _navMeshAgent;

    public PlayerController player;
    bool _isPlayerNoticed = false;
    private PlayerHelth _player;
    private Health _health;

    public float distant;
    public float viewAngle;
    public float damage = 30;

    public bool IsAlive() {
        return _health.isAlive();
    }

    void Start() { InitComponentLinks(); }

    void Update() { PatrolUpdate(); ChaseUpdate(); AttackUpdate(); }

    private void LateUpdate() => NoticePlayerLiteUpdate();

    void NoticePlayerLiteUpdate() {
        var direction = player.transform.position - transform.position;

        _isPlayerNoticed = false;
        RaycastHit hit;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit, distant))
            {
                Debug.Log(name);
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
    }

    void InitComponentLinks() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = player.GetComponent<PlayerHelth>();
        NewTargetPoint();
        _health = GetComponent<Health>();
    }

    void PatrolUpdate()
    {
        if (!_isPlayerNoticed) 
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                NewTargetPoint();
    }

    void ChaseUpdate() {
        if (_isPlayerNoticed)
            _navMeshAgent.destination = player.transform.position;
    }

    void AttackUpdate() {
        if (_isPlayerNoticed)
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                _player.DealDamage(damage * Time.deltaTime);
    }

    void NewTargetPoint() => _navMeshAgent.destination = targetPoint[Random.Range(0, targetPoint.Count)].position;
}
