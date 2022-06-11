using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameManager gameManager;
    [Space]
    public GameObject Deatheffect;
    public bool noDeath;
    
    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo) {
        if (collisionInfo.collider.tag == "Enemy" && !noDeath)
        {
            Instantiate(Deatheffect, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Player_Death");
            Destroy(gameObject);
            gameManager.EndGame();
        }
    }
}
