using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_manager : MonoBehaviour
{
    public int _gscore = 0;
    public int _rscore = 0;
    public int _bscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gscore()
    {
        _gscore += 1;
    }
    public void Rscore()
    {
        _rscore += 1;
    }
    public void Bscore()
    {
        _bscore += 1;
    }
}
