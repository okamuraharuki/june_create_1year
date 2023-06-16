using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_spawner : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] int _spawntime = 5;
    [SerializeField] int _delaytime = 2;
    float _nowdelaytime = 0;
    time_manager _time;
    void FixedUpdate()
    {
        _nowdelaytime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.P) && _nowdelaytime > _delaytime)
        {
            Spawnplayer();
            _nowdelaytime = 0;
        }
    }
    public void Spawnplayer()
    {
        _time = GameObject.Find("Timetext").GetComponent<time_manager>();
        time_manager._NowTime -= _spawntime;
        Destroy(GameObject.FindWithTag("Player"));
        Instantiate(_player, this.transform);
    }
}
