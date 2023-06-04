using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_anim_spaceman : MonoBehaviour
{
    //private List<KeyCode> PushedkeyCodes = new List<KeyCode>();
    [SerializeField] LayerMask _groundlayer = 0;
    [SerializeField] float _powerR = 1f;
    [SerializeField] float _powerL = 1f;
    Rigidbody2D _rb;
    Animator _anim;
    int _nowAnimation = 0;
    [SerializeField]Vector2 _groundline = Vector2.down;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 start = this.transform.position;   // start は「LineCast の始点」である
        Debug.DrawLine(start,start + _groundline);
        RaycastHit2D groundhit = Physics2D.Linecast(start, start + _groundline,_groundlayer);
        if (Input.GetKey(KeyCode.D) && groundhit.collider)
        {
            //Debug.Log("pushed D");
            Statuschange("walkR");
            _rb.AddForce(Vector2.right * _powerR);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Statuschange("dashR");
                _rb.AddForce(Vector2.right * 2 * _powerR);
            }
        }
        else if (Input.GetKey(KeyCode.A)&& groundhit.collider)
        {
            //Debug.Log("pushed A or <-");
            Statuschange("walkL");
            _rb.AddForce(Vector2.left * _powerL);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Statuschange("dashL");
                _rb.AddForce(Vector2.left * 2 * _powerR);
            }
        }
        else
        {
            Statuschange("standR");
        }
    }
    private void Statuschange(string str)
    {
        switch(str)
        {
            case "dashL":_nowAnimation = 5;
                break;
            case "dashR":_nowAnimation = 4;
                break;
            case "walkL":_nowAnimation = 3;
                break;
            case "walkR": _nowAnimation = 2;
                break;
            case "standL":_nowAnimation = 1;
                break;
            case "standR": _nowAnimation = 0;
                break;
            default: _nowAnimation = 0;
                break;
        }
        _anim.SetInteger("NowStatus",_nowAnimation);
    }
}
