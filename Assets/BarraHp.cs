using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraHp : MonoBehaviour
{

    // public GameObject hpBar;

    // private GameObject barra;
    [SerializeField]private GameObject padre;

    public static float maxhp = 1f;

    public static float hp;
    
    public float speed = 0;

    void Start(){
        hp=maxhp;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Golpe");

        if(other.gameObject.tag == "Bala"){

            // if(hp == maxhp){
            //     barra = Instantiate(hpBar) as GameObject;
            //     barra.transform.position = padre.transform.position;
            //     barra.transform.position = new Vector2(5.25f, -0.5f);
            //     // 1.05f, 0.15f
            // }

            takeDamage();
            Debug.Log("Impacto Bala");
            Destroy(other.gameObject);
            
        }

    }
    
    void Update() {

        // if(barra){
        //     // barra.transform.position = Vector3.MoveTowards(barra.transform.position, transform.position, speed*(Time.deltaTime));
        //     Debug.Log(barra.transform.position);
        //     barra.transform.parent = padre.transform;
        // }
        // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed*time);
        // Debug.Log(this.gameObject);
    }

    private void takeDamage(){
        hp-= 0.3f;
        // barra.gameObject.transform.localScale=new Vector3(hp/maxhp, 1, 1);

        if(hp <= 0){
                Destroy(gameObject);
                // Destroy(barra);
        }
    }

}
