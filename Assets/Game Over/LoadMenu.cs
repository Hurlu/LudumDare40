using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

	public void  Load(string name) {
        Debug.Log(name);
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        // Give full path
    }
}
