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
