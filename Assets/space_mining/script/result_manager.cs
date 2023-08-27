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
    int _gscoreResult;
    int _rscoreResult;
    int _bscoreResult;
    int _resultscore;
    [SerializeField] int _gpoint = 100;
    [SerializeField] int _rpoint = 300;
    [SerializeField] int _bpoint = 1100;
    void Start()
    {
        _gscoreResult = score_manager._gscore;
        _rscoreResult = score_manager._rscore;
        _bscoreResult = score_manager._bscore;
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
            _resultscore = _gscoreResult * _gpoint + _rscoreResult * _rpoint + _bscoreResult * _bpoint;
            _resulttext.text = "SCORE " + _resultscore.ToString("d6");
            StartCoroutine(ResultscoreUI());
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
        _gtext.text = "" + _gscoreResult;
        yield return new WaitForSeconds(1);
        _rbool = true;
    }
    IEnumerator RscoreUI()
    {
        _rtext.text = "" + _rscoreResult;
        yield return new WaitForSeconds(1);
        _bbool = true;
    }
    IEnumerator BscoreUI()
    {
        _btext.text = "" + _bscoreResult;
        yield return new WaitForSeconds(1);
        _resultbool = true;
    }
    IEnumerator ResultscoreUI()
    {
        yield return new WaitForSeconds(1);
        _titlebackbool = true;
    }
}
