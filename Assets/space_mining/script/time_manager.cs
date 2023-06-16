using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class time_manager : MonoBehaviour
{
    [SerializeField]float _LimitTime = 180;
    static public float _NowTime = 0;
    int _minuteTime;
    int _secondTime;
    Text _TimeText;
    // Start is called before the first frame update
    void Start()
    {
        _NowTime = _LimitTime;
        _TimeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas_manager._gamestart == true)
        {
            _NowTime -= Time.deltaTime;
            _secondTime = (int)_NowTime % 60;
            _minuteTime = (int)_NowTime / 60;
            if (_NowTime <= 0)
            {
                return;
            }
            else if (_secondTime < 10)
            {
                _TimeText.text = "TIME 0" + _minuteTime + ":0" + _secondTime;
            }
            else
            {
                _TimeText.text = "TIME 0" + _minuteTime + ":" + _secondTime;
            }
        }
    }
}
