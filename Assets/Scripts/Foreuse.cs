using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foreuse : MonoBehaviour
{

    private GameObject _currentCollisionItem; 
    public float collisionDuration = 2; // durée de la collision
    private float _startTime; 
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _startTime > collisionDuration && _currentCollisionItem != null)
        {
            Destroy(_currentCollisionItem);
            _currentCollisionItem = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rock")
        {
            _currentCollisionItem = other.gameObject;
            _startTime = Time.time;
        } else if (other.gameObject.tag == "Ground")
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
