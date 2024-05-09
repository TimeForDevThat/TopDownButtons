using System.Collections;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _dashSpeed = 5000f;
    [SerializeField] private float _dashTime = 2f;

    private Vector2 direction;
    private Rigidbody2D rb;

    private bool isf;
    private bool _isDashing = true;
    private Type type;

    public enum Type {PC, Joystick}
    public Joystick joystick;

    private void Start() => rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        Dash();
        InputDevice();
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
        => rb.MovePosition(rb.position + direction * _movementSpeed * Time.fixedDeltaTime);

    private void Flip()
    {
        isf = !isf;
        transform.Rotate(0f, 180, 0f);
    }

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
        if (Input.GetKeyDown(KeyCode.LeftShift) && _isDashing == true) {
            _isDashing = false;
            Invoke("DashLock", _dashTime);
            rb.velocity = new Vector2(0, 0);

            if (rb.transform.localScale.x < 0)
                rb.AddForce(Vector2.left * _dashSpeed);
            else rb.AddForce(Vector2.right * _dashSpeed);
        }
    }

    void DashLock() { 
        _isDashing = true;
    }
}
