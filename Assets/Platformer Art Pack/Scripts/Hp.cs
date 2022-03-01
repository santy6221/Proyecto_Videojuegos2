using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public GameObject bar;
    public Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = BarraHp.hp;
        Debug.Log("Posicion vida ->"+bar.transform.position);
        transform.localScale = localScale;
    }

    // public void takeDamage(){
    //     hp-= 0.3f;
    //     // barra.gameObject.transform.localScale=new Vector3(hp/maxhp, 1, 1);

    //     if(hp <= 0){
    //             Destroy(gameObject);
    //             // Destroy(barra);
    //         }
    // }
}
