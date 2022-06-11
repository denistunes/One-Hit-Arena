using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject boomerang;
    public bool hasBoomerang = true;

    [Header("Arrow")]
    public SpriteRenderer sprite;
    public Color noFColor;
    public Color BoomColor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && hasBoomerang)
        {
            FindObjectOfType<AudioManager>().Play("Throw");
            hasBoomerang = false;
            Shoot();
        }

        if (!hasBoomerang)
        {
            sprite.color = BoomColor;
        } else {
            sprite.color = noFColor;
        }
    }

    void Shoot()
    {
        Instantiate(boomerang, firepoint.position, firepoint.rotation);
    }
}
