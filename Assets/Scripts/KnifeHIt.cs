using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHIt : MonoBehaviour
{
    [SerializeField]
    private Vector2 force;
    public GameObject knife;
    private bool isActive = true;
    
    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

Vector3 pos;
    private void Awake()
    {
        pos=transform.position;
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            rb.AddForce(force , ForceMode2D.Impulse);
            rb.gravityScale = 1;
            //To do: Decrement number of available knives

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
            return;
        isActive = false;
        Instantiate(knife,pos,transform.rotation);
        if (collision.collider.tag == "Ball")
        {
            rb.velocity = new Vector2(0 , 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.2f);
           

            //To do spawn another knife.
        }
        else if (collision.collider.tag == "Knife")
        {
            rb.velocity = new Vector2 (rb.velocity.x , -2 );
        }            
    
    }
}
