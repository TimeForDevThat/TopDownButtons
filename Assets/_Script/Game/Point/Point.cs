using UnityEngine;

public class Point : MonoBehaviour
{
    public string tagObject;
    public int point = 5;

    public Transform _object;
    public float speed;

    private PlayerProgress PlayerProgress;

    private void Start() {
        PlayerProgress = FindObjectOfType<PlayerProgress>();

        _object = GameObject.FindWithTag(tagObject).transform;
    }
         
    private void Update()
        => transform.position = Vector2.MoveTowards(transform.position, _object.position, speed * Time.deltaTime);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagObject)) {
            PlayerProgress.AddExperience(point);
            Destroy(gameObject);
        }
    }
}
