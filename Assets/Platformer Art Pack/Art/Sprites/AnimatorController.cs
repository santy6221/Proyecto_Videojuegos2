using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimatorController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject bala;

    public float forceJump = 0.01f;
    private bool isWalking;
    private float radio = 0.07f;
    private bool isFloor = true;
    private bool jump2 = false;
    private float speed = 0.01f;
    public float factor = 1f;
    private float time = 0.0f;
    private bool onLadder = false;
    private bool onLadderUp = false;
    private int maxHp = 3;
    private int currentHp = 3;

    private Interface UIManager = new Interface();

    public GameObject nohp;
    public GameObject halfhp;
    public GameObject fullhp;
    

  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Time.timeScale=1;
    }

    // Update is called once per frame
    void Update()
    {

        if (isFloor)
        {

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isFloor || !jump2)
            {
                rb.velocity = new Vector2(rb.velocity.x, forceJump);
                rb.AddForce(new Vector2(0, forceJump));
                isFloor = false;


            }
            if (!jump2 && !isFloor)
            {
                jump2 = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("Walk", true);
            isWalking = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            speed = 3;
            factor = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("Walk", true);
            isWalking = true;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            speed = -3;
            factor = 1;

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Walk", false);
            isWalking = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && isWalking)
        {
            factor = 3;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && isWalking)
        {
            factor = 1;
        }
        if (isWalking)
        {
            rb.velocity = new Vector2(speed * factor, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparo();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && onLadder){

            transform.Translate(Vector3.down*2, Space.Self);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && onLadderUp){

            transform.Translate(Vector3.up*2, Space.Self);

        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Colision");

        if(other.gameObject.tag == "Mequieromatar"){
            Debug.Log("Tocando la escalera");
            onLadder = true;
            
        }else if(other.gameObject.tag == "EscaleraUp"){
            onLadderUp = true;
        }

        if (other.gameObject.tag == "Terreno" )
        {
            //groundedOn = null;
            isFloor = true;
            // Debug.Log(other.gameObject.tag);
        }

        if (other.gameObject.tag == "Enemy"){
            Debug.Log("Dano");
            takeDamage();
        }

        if(other.gameObject.tag == "Salida"){
            SceneManager.LoadScene ("Win");
        }

    }

    private void takeDamage(){

        currentHp--;
        // private Interface ui = new Interface();
        UIManager.fullVida = fullhp;
        UIManager.mediaVida = halfhp;
        UIManager.sinVida = nohp;
        UIManager.changeUI(currentHp);
        if(currentHp <= 0){
            SceneManager.LoadScene ("Lose");
        }
        Debug.Log("vida "+currentHp);
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Mequieromatar" || other.gameObject.tag == "EscaleraUp"){
            Debug.Log("saliendo la escalera");
            onLadder = false;
            onLadderUp = false;
            
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.CompareTag("Escalera")){
            
            Debug.Log("pego con escalera");
        }

    }

    

    private void Disparo()
    {

        time += Time.deltaTime;
        Vector3 direction;

        if (speed == 3 || speed == 0.01f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject balauno = Instantiate(bala, transform.position + direction * 0.7f, Quaternion.identity);
        balauno.GetComponent<Disparo>().DarDireccion(direction);
        Destroy(balauno, 0.8f);
    }
    

}
