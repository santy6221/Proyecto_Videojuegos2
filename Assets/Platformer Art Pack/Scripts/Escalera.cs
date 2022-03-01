using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{

    private Rigidbody2D rbd;
    private AnimatorController controller;

    public BoxCollider2D PlatformGround;

    [HideInInspector]public bool Onladder = false;

    public float climbspeed;
    public float exithop = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        controller = GetComponent<AnimatorController>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.CompareTag("Escalera")){
            if(Input.GetAxisRaw("Vertical") != 0){
                Debug.Log("Colision con escalera");
                rbd.velocity = new Vector2(rbd.velocity.x, Input.GetAxisRaw("Vertical") * climbspeed);
                rbd.gravityScale = 0;
                Onladder = true;
                PlatformGround.enabled = false;
            }
            else if(Input.GetAxisRaw("Vertical") == 0 && Onladder){
                rbd.velocity = new Vector2(rbd.velocity.x,0);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if(other.CompareTag("Escalera") && Onladder){
            rbd.gravityScale = 1;
            Onladder = false;
            PlatformGround.enabled = true;
        }

    }
}
