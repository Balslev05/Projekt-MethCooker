using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public int speed;
    public int sprintSpeed;
    public int sprintCooldown;
    public float maxStamina;
    public float currentStamina;
    
    
    [Header("Inputs")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    
    [Header("Assignebels")]
   [SerializeField] private Rigidbody2D _rb;
   
    private Vector2 _movement;
    private bool Sprinting = false;
    private Vector2 _lastDirection;
    private int StartSpeed;
    
    void Start()
    {
        currentStamina = maxStamina;
        StartSpeed = speed;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
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
    
    public void Sprint()
    {
        if(Input.GetKeyDown(sprintKey) && currentStamina > 0)
        {
            speed = sprintSpeed;
            Sprinting = true;
            currentStamina--;
        }
        if (Input.GetKeyUp(sprintKey))
        {
            speed = StartSpeed;
            Sprinting = false;
        }
        
        if (Sprinting)
        {
            currentStamina -= Time.deltaTime;
        }
        else {currentStamina += Time.deltaTime;}
        
        currentStamina = math.clamp(currentStamina,0,maxStamina);   
    }
}
