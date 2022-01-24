using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
   [SerializeField]float steerSpeed = 1f;
   [SerializeField]float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 0.00001f;
    [SerializeField] float boostSpeed = 500f; 

    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
      
    }

    public void Move ()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed*Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed*Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpeedUp")
        {
            moveSpeed = boostSpeed;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            moveSpeed = slowSpeed;
        
    }
}
