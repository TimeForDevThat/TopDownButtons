using UnityEngine;

public class Particle_System : MonoBehaviour
{
    void Update()
        => Invoke("Del", 5);

    void Del() { 
        Destroy(gameObject);
    }
}
