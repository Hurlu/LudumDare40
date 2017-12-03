using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour {

    public void replay()
    {
        SceneManager.LoadScene(1/*or whatever*/);
    }
}
