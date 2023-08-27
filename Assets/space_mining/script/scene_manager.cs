using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
class scene_manager : MonoBehaviour
{
    void Start()
    {
        
    }
    public void LoadsceneGamescene()
    {
        score_manager._gscore = 0;
        score_manager._rscore = 0;
        score_manager._bscore = 0;
        SceneManager.LoadScene(1);
    }
    public void LoadsceneScorescene()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
