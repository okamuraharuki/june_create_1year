using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_spaceman : MonoBehaviour
{
    //private List<KeyCode> PushedkeyCodes = new List<KeyCode>();
    [SerializeField] LayerMask _groundlayer = 0;
    float _xscale = 0;
    [SerializeField] float _walkpower = 1;
    [SerializeField] float _dashpower = 2;
    [SerializeField] float _jumppower = 5;
    Rigidbody2D _rb;
    [SerializeField] Vector2 _groundline = Vector2.down;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        Jump();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Jump()
    {
        _xscale = Input.GetAxisRaw("Horizontal");
        Vector2 start = this.transform.position;
        //Debug.DrawLine(start, start + _groundline);
        RaycastHit2D groundhit = Physics2D.Linecast(start, start + _groundline, _groundlayer);
        if (Input.GetKeyDown(KeyCode.J) && groundhit.collider)//jump
        {
            Debug.Log("jump");
            _rb.AddForce(Vector2.up * _jumppower, ForceMode2D.Impulse);
        }
    }
    void Move()
    {
        Vector2 start = this.transform.position;
        //Debug.DrawLine(start, start + _groundline);
        RaycastHit2D groundhit = Physics2D.Linecast(start, start + _groundline, _groundlayer);
        if (groundhit.collider)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            { 
                _rb.AddForce(Vector2.right * _xscale * _walkpower * _dashpower, ForceMode2D.Force);
            }
            else
            {
                _rb.AddForce(Vector2.right * _xscale * _walkpower, ForceMode2D.Force);
            }
        }
    }
}