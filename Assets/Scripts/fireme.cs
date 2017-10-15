using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireme : MonoBehaviour
{
    public float power = 100;
    public float timer = 5f;
    
    private Rigidbody2D rb;
    // Use this for initialization
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(0, 1) * power, ForceMode2D.Force);

    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        

    }
   

}
