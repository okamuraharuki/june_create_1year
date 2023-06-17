using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakstorn : MonoBehaviour
{
    oreStatus _oreStatus;
    void Start()
    {
        _oreStatus = this.GetComponent<oreStatus>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_oreStatus._NoworeHP == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
