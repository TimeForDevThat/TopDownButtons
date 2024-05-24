using UnityEngine;
using UnityEngine.AI;

public class EnemyAi2 : Sounds
{
    private NavMeshAgent _navMeshAgent;

    public PlayerController player;
    private PlayerHelth _player;
    private Health _health;

    public int damage_restart_time = 1;
    public int damage = 30;

    private bool damage_time = true;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && damage_time == true) {
            _player.DealDamage(damage);
            PlaySounds(0, destroy: true);
            damage_time = false;
            Invoke("Restart", damage_restart_time);
        }
    }

    void Restart() {
        damage_time = true;
    }
}
