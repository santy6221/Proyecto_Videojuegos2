using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameObject sinVida;
    public GameObject mediaVida;
    public GameObject fullVida;
    
    public void changeUI(int hp){
        // Debug.Log(fullVida);
        fullVida.SetActive(false);
        mediaVida.SetActive(false);
        sinVida.SetActive(false);

        switch (hp)
        {
            case 3:
                fullVida.SetActive(true);
            break;

            case 2:
                mediaVida.SetActive(true);
            break;

            case 1:
                sinVida.SetActive(true);
            break;
        }
    }
}
