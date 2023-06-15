using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scene_manager : MonoBehaviour
{
    void Start()
    {
        
    }
    public void LoadsceneGamescene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadsceneScorescene()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
