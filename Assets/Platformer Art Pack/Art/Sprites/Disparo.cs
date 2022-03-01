using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float speed;
    private Vector2 Direccion;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rigid.velocity = Direccion * speed;
    }

    public void DarDireccion(Vector2 direction){
        Direccion = direction;
    }
}
