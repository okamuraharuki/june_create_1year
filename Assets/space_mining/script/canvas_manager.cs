using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class canvas_manager : MonoBehaviour
{
    static public bool _gamestart = false;
    GameObject _startcountback;
    GameObject _startcount;
    Text _startcounttext;
    float _eventtimer = 4;
    void Awake()
    {
        _startcountback = GameObject.Find("startback");
        _startcount = GameObject.FindWithTag("startcount");
        _startcounttext = GameObject.FindWithTag("startcount").GetComponent<Text>();
        _startcountback.SetActive(false);
        _startcount.SetActive(false);
    }
    private void Update()
    {
        if (time_manager._NowTime < 0)
        {
            _startcountback.SetActive(true);
            _startcount.SetActive(true);
            _startcounttext.text = "finish";
            _gamestart = false;
            StartCoroutine(Loadscorescene());
        }
    }
    private void FixedUpdate()
    {
        if (_eventtimer >= 0)
        {
            _eventtimer -= Time.deltaTime;
            _startcountback.SetActive(true);
            _startcount.SetActive(true);
            if (_eventtimer >= 1)
            {
                _startcounttext.text ="" + (int)_eventtimer;
            }
            else if(_eventtimer <= 1)
            {
                _startcounttext.text = "start";
            }
        }
        else
        {
            _gamestart = true;
            _startcountback.SetActive(false);
            _startcount.SetActive(false);
        }
    }
    IEnumerator Loadscorescene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
