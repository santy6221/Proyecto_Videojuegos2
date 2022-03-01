using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{

    public void change(string sceneName){
        SceneManager.LoadScene (sceneName);
    }

    public void exitGame(){
        Application.Quit();
    }
    // Start is called before the first frame update
}
