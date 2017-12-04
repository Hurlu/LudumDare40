using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	public void  Load(string name) {
        Debug.Log(name);
        SceneManager.LoadScene(name);
        // Give full path
    }

    public void QuitGame()
    {
        Debug.Log("I WANT TO QUIT !!!");
        Application.Quit();
    }
}
