using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace capabilities{
    public class capabilities : MonoBehaviour
    {
        [SerializeField]
        private float[] speed;
        [SerializeField]
        private float minDistance = 15;

        public UnityEvent deasactive;
        public UnityEvent acticve;

        private EnemyAi2 scr;

        private void Start()
        {
            scr = GetComponent<EnemyAi2>();
        }

        private void Update()
        {
            var heading = transform.position - scr.player.transform.position;
            heading.y = 0;

            var distance = heading.magnitude;
            var direction = heading / distance;

            var speedMove = scr._navMeshAgent.speed;

            if (heading.sqrMagnitude < minDistance)
            {
                speedMove = speed[0];
                deasactive.Invoke();
            }
            else {
                scr._navMeshAgent.speed = speed[1];
                acticve.Invoke();
            }
        }
    }
}