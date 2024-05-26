using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : Sounds
{
    public float _movementSpeed = 5f;
    [SerializeField] private float _dashSpeed = 5000f;
    [SerializeField] private float _dashTime = 2f;

    private Animator _animator;

    private Vector2 direction;
    private Rigidbody2D rb;

    public bool isf = false;
    private bool _isDashing = true;
    public bool theRoom = false;


    public Type type;
    public GameObject GunRight;
    public GameObject GunLeft;

    public enum Type { PC, Joystick }
    public Joystick joystick;

    private void Start()
        => InitComponentLinks();

    void InitComponentLinks() {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Dash();
        InputDevice();
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + direction* _movementSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            PlaySounds(0, random: true);
        //Flip();
    }

    //private void Flip()
    //{
       // if (GunRight.GetComponent<Weapon>().rotateZ >= 100 || GunRight.GetComponent<Weapon>().rotateZ <= -100 || GunLeft.GetComponent<Weapon>().rotateZ >= 100 || GunLeft.GetComponent<Weapon>().rotateZ <= -100)
       // {
         //   GetComponent<SpriteRenderer>().flipX = true;

        //}
       // else
       // {
        //    GetComponent<SpriteRenderer>().flipX = false;
        //    //Gun.GetComponent<SpriteRenderer>().flipY = false;
       // }

    //}

    void InputDevice() {
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

    void Dash() {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _isDashing) {
            _isDashing = false;
            _animator.SetTrigger("dash");
            Invoke("DashLock", _dashTime);
            rb.velocity = new Vector2(0, 0);

            if (rb.transform.localScale.x < 0)
                rb.AddForce(Vector2.left * _dashSpeed);
            else rb.AddForce(Vector2.right * _dashSpeed);
        }
    }

    void DashLock()=> _isDashing = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Room")
            theRoom = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Room")
            theRoom = false;
    }
}
