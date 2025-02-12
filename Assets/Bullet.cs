﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private GameObject parent;
    public GameObject Parent { set { parent = value; } }


    private float speed = 10.0F;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
       
    }

    public void Destroy()
    {
        Destroy(gameObject, 0.8F);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        
        if(unit && unit.gameObject != parent)
        {            
             Destroy(gameObject);
        }
    }
}
