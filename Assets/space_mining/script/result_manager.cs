using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class result_manager : MonoBehaviour
{
    bool _rbool = false;
    bool _bbool = false;
    bool _resultbool = false;
    bool _titlebackbool = false;
    Text _gtext;
    Text _rtext;
    Text _btext;
    Text _resulttext;
    GameObject _titleback;
    int _gscore;
    int _rscore;
    int _bscore;
    int _resultscore;
    [SerializeField] int _gpoint = 100;
    [SerializeField] int _rpoint = 300;
    [SerializeField] int _bpoint = 1100;
    [SerializeField] float _waittime = 1;
    void Start()
    {
        _gscore = score_manager.ScoreReturnG();
        _rscore = score_manager.ScoreReturnR();
        _bscore = score_manager.ScoreReturnB();
        _gtext = GameObject.FindWithTag("gscore").GetComponent<Text>();
        _rtext = GameObject.FindWithTag("rscore").GetComponent<Text>();
        _btext = GameObject.FindWithTag("bscore").GetComponent<Text>();
        _resulttext = GameObject.FindWithTag("score").GetComponent<Text>();
        _titleback = GameObject.FindWithTag("Finish");
        _titleback.SetActive(false);
        StartCoroutine(GscoreUI());
    }
    private void Update()
    {
        if(_titlebackbool == true)
        {
            _titleback.SetActive(true);
            if (Input.anyKey)
            {
                SceneManager.LoadScene(0);
            }
        }
        else if(_resultbool == true)
        {
            _resultscore = _gscore * _gpoint + _rscore * _rpoint + _bscore * _bpoint;
            if (_resultscore == 0)
            {
                _resulttext.text = "SCORE 000000";
                StartCoroutine(ResultscoreUI());
            }
            else if (_resultscore < 1000)
            {
                _resulttext.text = "SCORE 000" + _resultscore;
                StartCoroutine(ResultscoreUI());
            }
            else if (_resultscore < 10000)
            {
                _resulttext.text = "SCORE 00" + _resultscore;
                StartCoroutine(ResultscoreUI());
            }
            else if (_resultscore < 100000)
            {
                _resulttext.text = "SCORE 0" + _resultscore;
                StartCoroutine(ResultscoreUI());
            }
        }
        else if (_bbool == true)
        {
            StartCoroutine(BscoreUI());
        }
        else if (_rbool == true)
        {
            StartCoroutine(RscoreUI());
        }
    }
    IEnumerator GscoreUI()
    {
        _gtext.text = "" + _gscore;
        yield return new WaitForSeconds(1);
        _rbool = true;
    }
    IEnumerator RscoreUI()
    {
        _rtext.text = "" + _rscore;
        yield return new WaitForSeconds(1);
        _bbool = true;
    }
    IEnumerator BscoreUI()
    {
        _btext.text = "" + _bscore;
        yield return new WaitForSeconds(1);
        _resultbool = true;
    }
    IEnumerator ResultscoreUI()
    {
        yield return new WaitForSeconds(1);
        _titlebackbool = true;
    }
}
