using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    
   [SerializeField] private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _lastDirection;
    
    void Start()
    {
        _rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    public void move()
    {
        Vector2 dir = _rb.transform.position - transform.position;
        dir = dir.normalized;
        _lastDirection = dir;
        
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        _rb.velocity = new Vector2((_movement.x * speed) * Time.deltaTime,(_movement.y * speed) * Time.deltaTime);
    }
}
