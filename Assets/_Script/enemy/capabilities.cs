using UnityEngine;

namespace capabilities{
    public class capabilities : MonoBehaviour
    {
        [SerializeField]
        private float[] speed;
        [SerializeField]
        private float minDistance = 15;

        //public Animation animation;
        public GameObject[] obj;

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

            if (heading.sqrMagnitude < minDistance)
            {
                Debug.Log("Я догнал");
                for (int i = 0; i < 10; i++)
                {
                    obj[i].SetActive(false);
                }
            }
            else { 
                //animation.Play();
                for (int i = 0; i < 10; i++) {
                    obj[i].SetActive(true);
                }
            }
        }
    }
}