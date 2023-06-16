using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class move_spaceman : MonoBehaviour
{
    [SerializeField] LayerMask _orelayer;
    [SerializeField] LayerMask _groundlayer;
    float _xscale = 0;
    [SerializeField] float _walkpower = 1;
    [SerializeField] float _dashpower = 2;
    [SerializeField] float _jumppower = 5;
    Rigidbody2D _rb;
    [SerializeField] Vector2 _groundline = Vector2.down;
    [SerializeField] Vector2 _Mline = Vector2.right;
    [SerializeField] float _boxhalflength = 0.4f;
    [SerializeField] float _boxunderdistance = 0.78f;
    oreStatus _orestatus;
    float _time = -1;
    [SerializeField] float _interval = 3;
    animation_spaceman _noAnim;
    public bool _minestatus = false;
    player_spawner _spawner;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _noAnim = this.gameObject.GetComponent<animation_spaceman>();
    }
    public void Update()
    {
        if(time_manager._NowTime > 0 && canvas_manager._gamestart == true)
        {
            if (_noAnim._nowAnimation % 2 != 0)
            {
                _Mline = Vector2.left;
            }
            else
            {
                _Mline = Vector2.right;
            }
            Jump();
            Mine();
        }
    }
    void FixedUpdate()
    {
        if (time_manager._NowTime > 0 && canvas_manager._gamestart == true)
        {
            Move();
        }
    }
    void Mine()
    {
        Vector2 position = this.transform.position;
        Vector2 start = new Vector2(position.x - _boxhalflength, position.y - _boxunderdistance);
        Vector2 end = new Vector2(position.x + _boxhalflength, position.y - _boxunderdistance);
        RaycastHit2D Ghit = Physics2D.Linecast(start, end, _groundlayer);
        Debug.DrawLine(position, position + _Mline); Debug.DrawLine(start, end);
        RaycastHit2D Mhit = Physics2D.Linecast(position, position + _Mline, _orelayer);
        if (Mhit && Ghit)
        {
            if (Input.GetKeyUp(KeyCode.M))
            {
                _time = -1;
                _minestatus = false;
            }
            else if (Input.GetKey(KeyCode.M))
            {
                _time += Time.deltaTime;
                if (_time > _interval)
                {
                    _minestatus =  true;
                    GameObject gameobject_ore = Mhit.transform.gameObject;
                    _orestatus = gameobject_ore.GetComponent<oreStatus>();
                    _orestatus._oreDamage = true;
                    _time = 0;
                    if (oreStatus._NoworeHP <= 0)
                    {
                        _minestatus = false;
                    }
                }
            }
        }
    }
    void Jump()
    {
        _xscale = Input.GetAxisRaw("Horizontal");
        Vector2 position = this.transform.position;
        Vector2 start = new Vector2(position.x - _boxhalflength, position.y - _boxunderdistance);
        Vector2 end = new Vector2(position.x + _boxhalflength, position.y - _boxunderdistance);
        RaycastHit2D Ghit = Physics2D.Linecast(start, end, _groundlayer);
        if (Input.GetKeyDown(KeyCode.Space) && Ghit.collider)//jump
        {
            _rb.AddForce(Vector2.up * _jumppower, ForceMode2D.Impulse);
        }
    }
    void Move()
    {
        Vector2 position = this.transform.position;
        Vector2 start = new Vector2(position.x - _boxhalflength, position.y - _boxunderdistance);
        Vector2 end = new Vector2(position.x + _boxhalflength, position.y - _boxunderdistance);
        RaycastHit2D Ghit = Physics2D.Linecast(start,end, _groundlayer);
        if (Ghit.collider)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
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