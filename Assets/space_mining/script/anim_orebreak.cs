using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_orebreak : MonoBehaviour
{
    Animator _animator;
    oreStatus _oreStatus;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _oreStatus = this.GetComponent<oreStatus>();
    }
    private void FixedUpdate()
    {
        if (_oreStatus._NoworeHP == 0)
        {
            if (this.gameObject.CompareTag("greenore"))
            {
                _animator.SetBool("_breakGre",true);
            }
            else if (this.gameObject.CompareTag("redore"))
            {
                _animator.SetBool("_breakRed", true);
            }
            else if (this.gameObject.CompareTag("blueore"))
            {
                _animator.SetBool("_breakBlu", true);
            }
            else if (this.gameObject.CompareTag("randomore"))
            {
                _animator.SetBool("_breakRan", true);
            }
        }
    }
}
