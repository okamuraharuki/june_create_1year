using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_manager : MonoBehaviour
{
    public int _gscore = 0;
    public int _rscore = 0;
    public int _bscore = 0;
    Text _gtext;
    Text _rtext;
    Text _btext;
    // Start is called before the first frame update
    void Start()
    {
        _gtext = GameObject.FindWithTag("gscore").GetComponent<Text>();
        _rtext = GameObject.FindWithTag("rscore").GetComponent<Text>();
        _btext = GameObject.FindWithTag("bscore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gscore()
    {
        _gscore += 1;
        _gtext.text ="" + _gscore;
    }
    public void Rscore()
    {
        _rscore += 1;
        _rtext.text = "" + _rscore;
    }
    public void Bscore()
    {
        _bscore += 1;
        _btext.text = "" + _bscore;
    }
}
