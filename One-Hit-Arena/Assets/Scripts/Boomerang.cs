using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed;
    public float drag;
    float rotateSpeed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        rb.drag = drag;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {

        Shooting shoot = hitInfo.GetComponent<Shooting>();
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Bouncer bounce = hitInfo.GetComponent<Bouncer>();
        if (shoot != null)
        {
            FindObjectOfType<AudioManager>().Play("Pick");
            shoot.hasBoomerang = true;
            Destroy(gameObject);
        }

        if (enemy != null && rotateSpeed > 2f)
        {
            enemy.Die();
        }

        if (bounce != null && rotateSpeed > 2f)
        {
            bounce.Die();
        }
    }

    void FixedUpdate() {
        rotateSpeed = rb.velocity.magnitude;
        transform.Rotate(0f,0f,rotateSpeed);
    }
}
