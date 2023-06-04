using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class animation_spaceman : MonoBehaviour
{
    //private List<KeyCode> PushedkeyCodes = new List<KeyCode>();

    Animator animator;
    int nowAnimation = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("pushed A");
        }
        if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("pushed D");
        }
    }
    private void Statuschange(string str)
    {
        switch(str)
        {
            case "DashL":nowAnimation = 5;
                break;
            case "DashR":nowAnimation = 4;
                break;
            case "WalkL":nowAnimation = 3;
                break;
            case "WalkR": nowAnimation = 2;
                break;
            case"StandL":nowAnimation = 1;
                break;
            case "StandR": nowAnimation = 0;
                break;
            default: nowAnimation = 0;
                break;
        }
        animator.SetInteger("NowStatus",nowAnimation);
    }

}
