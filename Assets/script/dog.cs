using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float upForce = 200f;
    

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))//impulso hacia arriba
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)//funcion para que al colicionar ya no impulse con el boton izquierdo
    {
        isDead = true;
        anim.SetTrigger("Dead");
        GameController.instance.DogDie();
        rb2d.velocity = Vector2.zero;
    }
    
}
