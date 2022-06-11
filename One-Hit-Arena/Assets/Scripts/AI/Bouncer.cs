using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 movement;
    Rigidbody2D rb;
    [Space]
    public GameObject Deatheffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        movement = new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f)); 
        rb.velocity = movement * moveSpeed;
    }

    public void Die()
    {
        FindObjectOfType<AudioManager>().Play("Enemy_Hurt");
        Instantiate(Deatheffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
