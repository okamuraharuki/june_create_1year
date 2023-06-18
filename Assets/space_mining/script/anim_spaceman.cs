using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class anim_spaceman : MonoBehaviour
{
    [SerializeField] LayerMask _groundlayer = 0;
    [SerializeField] Vector2 _groundline = Vector2.down;
    [SerializeField] LayerMask _orelayer;
    [SerializeField] Vector2 _Mline = Vector2.right;
    [SerializeField] float _boxhalflength = 0.4f;
    [SerializeField] float _boxunderdistance = 0.78f;
    Animator _anim;
    Rigidbody2D _rb;
    public int _nowAnimation = 0;
    bool _Lcheck = false;
    bool _Mstart = false;
    GameObject gameobject_ore;
    move_spaceman move_Spaceman;
    oreStatus _orestatus;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        move_Spaceman = this.gameObject.GetComponent<move_spaceman>();
    }
    private void Update()
    {
        if (time_manager._NowTime > 0 && canvas_manager._gamestart == true)
        {
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
        if (_nowAnimation % 2 != 0)
        {
            _Mline = Vector2.left;
            _Lcheck = true;
        }
        else
        {
            _Mline = Vector2.right;
            _Lcheck = false;
        }
        Vector2 position = this.transform.position;
        Vector2 start = new Vector2(position.x - _boxhalflength, position.y - _boxunderdistance);
        Vector2 end = new Vector2(position.x + _boxhalflength, position.y - _boxunderdistance);
        RaycastHit2D Ghit = Physics2D.Linecast(start, end, _groundlayer);
        RaycastHit2D GOREhit = Physics2D.Linecast(start, end, _orelayer);
        RaycastHit2D Mhit = Physics2D.Linecast(position, position + _Mline, _orelayer);
        if (Mhit && Ghit || Mhit && GOREhit)
        {
            gameobject_ore = Mhit.transform.gameObject;
            _orestatus = gameobject_ore.GetComponent<oreStatus>();
            
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (_Lcheck == true)
                {
                    Statuschange("Mine1L");
                    StartCoroutine(WaitMineS(1));
                }
                else
                {
                Statuschange("Mine1R");
                StartCoroutine(WaitMineS(1));
                }
            }
            else if (Input.GetKeyUp(KeyCode.M))
            {
                if (_Lcheck == true)
                {
                    Statuschange("Mine3L");
                    StartCoroutine(WaitMineF(1));
                }
                else
                {
                    Statuschange("Mine3R");
                    StartCoroutine(WaitMineF(1));
                }
            }
            else if (Input.GetKey(KeyCode.M) && _Mstart == true)
            {
                if (_Lcheck == true)
                {
                    Statuschange("Mine2L");
                }
                else
                {
                    Statuschange("Mine2R");
                }
            }
        }
    }
    void Move()
    {
        Vector2 position = this.transform.position;
        Vector2 start = new Vector2(position.x - _boxhalflength, position.y - _boxunderdistance);
        Vector2 end = new Vector2(position.x + _boxhalflength, position.y - _boxunderdistance);
        //Debug.DrawLine(start, end);
        RaycastHit2D Ghit = Physics2D.Linecast(start, end, _groundlayer);
        RaycastHit2D GOREhit = Physics2D.Linecast(start, end, _orelayer);
        if (Ghit.collider || GOREhit.collider)//rightmove
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Statuschange("dashR");
                }
                else
                {
                    Statuschange("walkR");
                }
            }
        }
        if (Ghit.collider || GOREhit.collider)//rightmove
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Statuschange("dashL");
                }
                else
                {
                    Statuschange("walkL");
                }
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
            case "Mine3L":_nowAnimation = 13;
                break;
            case "Mine3R":_nowAnimation = 12;
                break;
            case "Mine2L":_nowAnimation = 11;
                break;
            case "Mine2R":_nowAnimation = 10;
                break;
            case "Mine1L": _nowAnimation = 9;
                break;
            case "Mine1R":_nowAnimation = 8;
                break;
            case "jumpL": _nowAnimation = 7;
                break;
            case "jumpR": _nowAnimation = 6;
                break;
            case "dashL": _nowAnimation = 5;
                break;
            case "dashR": _nowAnimation = 4;
                break;
            case "walkL": _nowAnimation = 3;
                break;
            case "walkR": _nowAnimation = 2;
                break;
            case "standL": _nowAnimation = 1;
                break;
            case "standR": _nowAnimation = 0;
                break;
            default: _nowAnimation = 0;
                break;
        }
        _anim.SetInteger("NowStatus", _nowAnimation);
    }
    IEnumerator WaitMineS(float flo)
    {
        yield return new WaitForSeconds(flo); 
        _Mstart = true;
    }
    IEnumerator WaitMineF(float flo)
    {
        yield return new WaitForSeconds(flo);
        _Mstart = false;
    }
}