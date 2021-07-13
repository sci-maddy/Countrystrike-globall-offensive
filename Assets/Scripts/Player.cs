﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Player : MonoBehaviour
{
    public int Lives = 5;
    public int SpawnDelay = 2;
    Renderer rend;
    Rigidbody2D rb;
    BoxCollider2D bc;
    Transform trans;
    public void GetHit()
    {
        Lives--;
        if(Lives <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Respawn());
        }
    }
    public IEnumerator Respawn()
    {
        //gameObject.SetActive(false);
        rend.enabled = false;
        rb.simulated = false;
        bc.enabled = false;
        yield return new WaitForSeconds(SpawnDelay);//makes player disappear for a bit before respawning him
        transform.position = new Vector2(Random.Range(-15f, 15f), Random.Range(-8f, 8f));
        bc.enabled = true;
        rb.simulated = true;
        rend.enabled = true;


        //gameObject.SetActive(true);

    }
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

}
