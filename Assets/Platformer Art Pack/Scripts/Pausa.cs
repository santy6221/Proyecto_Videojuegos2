using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Coge el escape");
            if (!pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                Time.timeScale=0;

            }else if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Time.timeScale=1;
            }
        }
    }

    public void hideUI(){
        pauseMenu.SetActive(false);
        Time.timeScale=1;
    }

    public void exitGame(){
        Debug.Log("Exit");
        Application.Quit();

    }


}
