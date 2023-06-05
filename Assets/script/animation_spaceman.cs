using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_spaceman : MonoBehaviour
{
    [SerializeField] LayerMask _groundlayer = 0;
    [SerializeField] Vector2 _groundline = Vector2.down;
    Animator _anim;
    Rigidbody2D _rb;
    int _nowAnimation = 0;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector2 start = this.transform.position;
        RaycastHit2D groundhit = Physics2D.Linecast(start, start + _groundline, _groundlayer);
        if (Input.GetKeyDown(KeyCode.J) && groundhit.collider)//jump
        {

        }
        if (Input.GetKey(KeyCode.D) && groundhit.collider)//rightmove
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Statuschange("dashR");
            }
            else
            {
                Statuschange("walkR");
            }
        }
        if (Input.GetKey(KeyCode.A) && groundhit.collider)//leftmove
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Statuschange("dashL");
            }
            else
            {
                Statuschange("walkL");
            }
        }
        if (_rb.velocity.x <= 0.5f && _rb.velocity.x >= -0.5f)//anim_static
        {
            if (_nowAnimation == 2 || _nowAnimation == 4)
            {
                Statuschange("standR");
            }
            else if (_nowAnimation == 3 || _nowAnimation == 5)
            {
                Statuschange("standL");
            }
        }
    }
    private void Statuschange(string str)
    {
        switch (str)
        {
            case "dashL":
                _nowAnimation = 5;
                break;
            case "dashR":
                _nowAnimation = 4;
                break;
            case "walkL":
                _nowAnimation = 3;
                break;
            case "walkR":
                _nowAnimation = 2;
                break;
            case "standL":
                _nowAnimation = 1;
                break;
            case "standR":
                _nowAnimation = 0;
                break;
            default:
                _nowAnimation = 0;
                break;
        }
        _anim.SetInteger("NowStatus", _nowAnimation);
    }
}