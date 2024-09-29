using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : Sounds
{
    [Space(5)]
    [Header("Speed, MoveSpeed, DashForce, DashForceTime")]
    public float _movementSpeed = 5f;
    [SerializeField] private float _dashSpeed = 5000f, _dashTime = 1.5f;

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

        Flip();
        HandleDash();
        CombiningKeyUpdate();
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    void CombiningKeyUpdate()
    {
        dashKeyBoardUp = Input.GetKey(LeftShift) && Input.GetKey(Up);
        dashKeyBoardDown = Input.GetKey(LeftShift) && Input.GetKey(Down);
        dashKeyBoardRight = Input.GetKey(LeftShift) && Input.GetKey(Right);
        dashKeyBoardLeft = Input.GetKey(LeftShift) && Input.GetKey(Left);
    }

    private void Flip()
    {
        if (GunRight.GetComponent<Weapon>().rotateZ >= 100 || GunRight.GetComponent<Weapon>().rotateZ <= -100 || 
            GunLeft.GetComponent<Weapon>().rotateZ >= 100 || GunLeft.GetComponent<Weapon>().rotateZ <= -100)
            GetComponent<SpriteRenderer>().flipX = true;
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GunLeft.GetComponent<SpriteRenderer>().flipY = false;
            GunRight.GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + direction * _movementSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(Up) || Input.GetKey(Down) || Input.GetKey(Right) || Input.GetKey(Left))
        {
            effect.Play();
            PlaySounds(0, random: true);
        }
    }

    public void HandleDash() {
        if (_isDashing)
        {
            if (dashKeyBoardLeft)
            {
                ApplyDashForce(Vector2.right, Vector2.left);
                StartCoroutine("StopDashingTemporarily");
            }
            else if (dashKeyBoardRight)
            {
                ApplyDashForce(Vector2.left, Vector2.right);
                StartCoroutine("StopDashingTemporarily");
            }
            else if (dashKeyBoardUp)
            {
                ApplyDashForce(Vector2.up, Vector2.down);
                StartCoroutine("StopDashingTemporarily");
            }
            else if (dashKeyBoardDown) {
                ApplyDashForce(Vector2.down, Vector2.up);
                StartCoroutine("StopDashingTemporarily");
            }
        }
    }

    private void ApplyDashForce(Vector2 mainDirection, Vector2 oppositeDirection)
    {
        if (rb.transform.localScale.x < 0 && (mainDirection == Vector2.left || mainDirection == Vector2.right))
            rb.AddForce(oppositeDirection * _dashSpeed);
        else if (rb.transform.localScale.y < 0 && (mainDirection == Vector2.up || mainDirection == Vector2.down))
            rb.AddForce(oppositeDirection * _dashSpeed);
        else
            rb.AddForce(mainDirection * _dashSpeed);
    }

    private IEnumerator StopDashingTemporarily()
    {
        _animator.SetTrigger("dash");
        _isDashing = false;
        yield return new WaitForSeconds(_dashTime);
        _isDashing = true;
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Iteam"))
        {
            _isDashing = false;
            rb.velocity = Vector2.zero;
        }
    }
*/
}
