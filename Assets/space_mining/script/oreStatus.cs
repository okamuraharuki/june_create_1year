using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oreStatus : MonoBehaviour
{
    [SerializeField]public int _oreHP = 6;
    public bool _oreDamage = false;
    GameObject scoreObject;
    void Start()
    {
        scoreObject = GameObject.Find("scoremanager");
    }
    void Update()
    {
        if(_oreDamage && _oreHP > 0)
        {
            _oreHP -= 1;
            if (_oreHP % 2 == 0)
            {
                if(this.gameObject.CompareTag("greenore"))
                {
                    score_manager score_Manager = scoreObject.GetComponent<score_manager>();
                    score_Manager.Gscore();
                }
                else if (this.gameObject.CompareTag("redore"))
                {
                    score_manager score_Manager = scoreObject.GetComponent<score_manager>();
                    score_Manager.Rscore();
                }
                else
                {
                    score_manager score_Manager = scoreObject.GetComponent<score_manager>();
                    score_Manager.Bscore();
                }
            }
            
            _oreDamage = false;
        }
    }

    
}