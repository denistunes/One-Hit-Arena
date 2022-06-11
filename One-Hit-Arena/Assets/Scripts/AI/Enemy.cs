using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 movement;
    bool facingRight = true;
    [Space]
    public GameObject Deatheffect;
    
    public void Die()
    {
        FindObjectOfType<AudioManager>().Play("Enemy_Hurt");
        Instantiate(Deatheffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update(){
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            
            if (player.position.x < transform.position.x && facingRight)
            {
                Flip ();
            }
            else if (player.position.x > transform.position.x && !facingRight)
            {
                Flip ();
            }
        } else {
            player = null;
        }
    }

    void Flip(){

        facingRight = !facingRight;
        transform.Rotate (0f, 180f, 0f);
    }
}
