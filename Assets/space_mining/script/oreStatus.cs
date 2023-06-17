using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oreStatus : MonoBehaviour
{
    public int _NoworeHP = 0;
    [SerializeField] int _MaxoreHP = 6;
    public bool _oreDamage = false;
    GameObject scoreObject;
    void Start()
    {
        _NoworeHP = _MaxoreHP;
        scoreObject = GameObject.Find("scoremanager");
    }
    void Update()
    {
        if(_oreDamage && _NoworeHP > 0)
        {
            _NoworeHP -= 1;
            if (_NoworeHP % 2 == 0)
            {
                score_manager score_Manager = scoreObject.GetComponent<score_manager>();
                if (this.gameObject.CompareTag("greenore"))
                {
                    score_Manager.Gscore();
                }
                else if (this.gameObject.CompareTag("redore"))
                {
                    score_Manager.Rscore();
                }
                else if(this.gameObject.CompareTag("blueore"))
                {
                    score_Manager.Bscore();
                }
                else if (this.gameObject.CompareTag("randomore"))
                {
                    int _random = Random.Range(1, 10);
                    if(_random < 6)
                    {
                        score_Manager.Gscore();
                    }
                    else if(_random < 10)
                    {
                        score_Manager.Rscore();
                    }
                    else
                    {
                        score_Manager.Bscore();
                    }
                }
                else
                {
                    int _random = Random.Range(1, 10);
                    if (_random == 6)
                    {
                        score_Manager.Gscore();
                    }
                    else if (_random == 10)
                    {
                        score_Manager.Rscore();
                    }
                    else if(_random == 3)
                    {
                        score_Manager.Bscore();
                    }
                }
            }
            
            _oreDamage = false;
        }
    }
}