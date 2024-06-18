using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy; 
    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
        
    }

    // Update is called once per frame
    void Update()
    {
        //thay doi position trong thanh phan transform 
        //dung phuong thuc AddForce cua thanh phan rigidbody2d
        //vector2.up = (0.1) 
        m_rb.velocity = Vector2.up * speed; 
        
    }
}
