using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject rockPrefab;
    public GameObject foreusePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        for (float x = -10.5f; x <= 10.5; x++)
        {
            for (float y = -3.5f; y <= 2.5; y++)
            {
                var rock = Instantiate(rockPrefab, new Vector3(x, y, 0), Quaternion.identity);
                var rr = Physics2D.OverlapPoint(rock.transform.position);
                if (rr.gameObject.tag == "Ground")
                {
                    Destroy(rock);   
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp((int)MouseButton.LeftMouse))
        {
            Vector3 mousePos = Input.mousePosition;
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 2;
            worldPos.x = (float)(Math.Round(worldPos.x +0.5) -0.5);
            if (Physics2D.OverlapPoint(worldPos) == null)
            {
                Instantiate(foreusePrefab, worldPos, Quaternion.identity);
            }
        }
    }
}
