using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : Sounds
{
    [Space(5)]
    [Header("Speed, MoveSpeed, DashForce, DashForceTime")]
    public float _movementSpeed = 5f;
    [SerializeField] private float _dashSpeed = 5000f, _dashTime = 2f;

    private Animator _animator;

    private Vector2 direction;
    private Rigidbody2D rb;

    private bool _isDashing = true;

    public ParticleSystem effect;

    [Space(5)]
    [Header("GameObject Gun")]
    public GameObject GunRight, GunLeft;

    [Space(5)]
    [Header("KeyBoard")]
    public KeyCode LeftShift = KeyCode.LeftShift;
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Right = KeyCode.A;
    public KeyCode Left = KeyCode.D;
    bool dashKeyBoardUp, dashKeyBoardDown, dashKeyBoardRight, dashKeyBoardLeft;

    private void Start()
        => InitComponentLinks();

    void InitComponentLinks() {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Dash();
        Flip();
        CombiningKeyUpdate();
        GetComponent<Rigidbody2D>();
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    void CombiningKeyUpdate() {
        dashKeyBoardUp = (Input.GetKey(LeftShift) && Input.GetKey(Up));
        dashKeyBoardDown = (Input.GetKey(LeftShift) && Input.GetKey(Down));
        dashKeyBoardRight = (Input.GetKey(LeftShift) && Input.GetKey(Right));
        dashKeyBoardLeft = (Input.GetKey(LeftShift) && Input.GetKey(Left));
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + direction* _movementSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            effect.Play();
            PlaySounds(0, random: true);
        }
    }

    private void Flip()
    {
        if (GunRight.GetComponent<Weapon>().rotateZ >= 100 || GunRight.GetComponent<Weapon>().rotateZ <= -100 || GunLeft.GetComponent<Weapon>().rotateZ >= 100 || GunLeft.GetComponent<Weapon>().rotateZ <= -100)
          GetComponent<SpriteRenderer>().flipX = true;
       else
       {
           GetComponent<SpriteRenderer>().flipX = false;
           GunLeft.GetComponent<SpriteRenderer>().flipY = false;
           GunRight.GetComponent<SpriteRenderer>().flipY = false;
       }
    }

    public void Dash() {
        if (dashKeyBoardLeft == true && _isDashing) {
            BaseDash();

            if (rb.transform.localScale.x < 0)
                rb.AddForce(Vector2.left * _dashSpeed);
            else rb.AddForce(Vector2.right * _dashSpeed);
        }
        if (dashKeyBoardRight == true && _isDashing){
            BaseDash();

            if (rb.transform.localScale.x < 0)
                rb.AddForce(Vector2.right * _dashSpeed);
            else rb.AddForce(Vector2.left * _dashSpeed);
        }
        if (dashKeyBoardUp == true && _isDashing) {
            BaseDash();

            if (rb.transform.localScale.y < 0)
                rb.AddForce(Vector2.down * _dashSpeed);
            else rb.AddForce(Vector2.up * _dashSpeed);
        }
        if (dashKeyBoardDown == true && _isDashing){
            BaseDash();

            if (rb.transform.localScale.y < 0)
                rb.AddForce(Vector2.up * _dashSpeed);
            else rb.AddForce(Vector2.down * _dashSpeed);
        }
    }

    void BaseDash() {
        _isDashing = false;
        _animator.SetTrigger("dash");
        rb.velocity = new Vector2(0, 0);
        Invoke("DashLock", _dashTime);
    }

    void DashLock()=> _isDashing = true;
}
