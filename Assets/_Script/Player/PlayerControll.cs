using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    //public float dirX, dirY;
    private bool isf;

    public Type type;
    public enum Type {PC, Joystick}
    public Joystick joystick;

    private void Start()
        => rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        GetComponent<Rigidbody2D>();
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        /*dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;*/

        if (type == Type.PC)
        {
            joystick.gameObject.SetActive(false);
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else if (type == Type.Joystick)
        {
            joystick.gameObject.SetActive(true);
            direction = new Vector2(joystick.Horizontal, joystick.Vertical);
            isf = true;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        //rb.velocity = new Vector2(dirX, dirY);
    }

    private void Flip()
    {
        isf = !isf;
        transform.Rotate(0f, 180, 0f);
    }
}
