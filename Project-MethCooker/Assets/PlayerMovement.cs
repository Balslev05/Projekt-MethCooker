using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.Mathematics;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float sprintSpeed;
    public float sprintCooldown;
    public float maxStamina;
    public float currentStamina;
    
    public bool jumping;
    public float jumpForce;
    public float jumpDamping;
    public Vector2 jumpScale;
    
    
    [Header("Inputs")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode jump = KeyCode.Space;
    
    [Header("Assignebels")]
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Animator animator;
   
    private float startSpeed;
    private bool sprinting = false;
    private Vector2 _movement;
    private Vector2 _lastDirection;
    private Vector2 normalSize;

    
    void Start()
    {
        normalSize = transform.localScale;
        currentStamina = maxStamina;
        startSpeed = speed;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpFall();
        Sprint();
        Move();
    }
    public void Move()
    {
        Vector2 dir = _rb.transform.position - transform.position;
        dir = dir.normalized;
        _lastDirection = dir;
        
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (jumping)
        {
            return;
        }
        _rb.velocity = new Vector2((_movement.x * speed),(_movement.y * speed));
        animator.SetBool("Walking",true);
    }
    public void Sprint()
    {
        if(Input.GetKeyDown(sprintKey) && currentStamina > 0)
        {
            speed = sprintSpeed;
            sprinting = true;
            currentStamina--;
        }
        if (Input.GetKeyUp(sprintKey))
        {
            speed = startSpeed;
            sprinting = false;
        }
        
        if (sprinting)
        {currentStamina -= Time.deltaTime;}
        else 
        {currentStamina += Time.deltaTime;}
        
        currentStamina = math.clamp(currentStamina,0,maxStamina);   
    }
    public void JumpFall()
    {
        if (Input.GetKeyDown(jump))
        {
            jumping = true;
            animator.SetBool("Walking",false);
            animator.SetBool("Jumping",true);
            
            _rb.velocity *= jumpForce;
        }
    }

    public void StandUp()
    {
        
    }

    private void FixedUpdate()
    {
        if (jumping)
        {
            _rb.velocity *= jumpDamping;
        }
    }
}
