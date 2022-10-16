using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fusion;

public class ExitMenu : NetworkBehaviour
{
    public string scene;
    public void ExitGame()
    {
        Runner.Shutdown();
        SceneManager.LoadScene(scene);
    }

    public void ResumeGame()
    {
        Destroy(this);
    }
}
