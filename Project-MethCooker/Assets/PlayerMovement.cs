using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.Mathematics;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [Header("WalkStats")] 
    public float speed;
    public float currentSpeed;
    public float acceleration;
    
    [Header("SprintStats")]
    public float sprintSpeed;
    public float maxStamina;
    public float currentStamina;
    
    [Header("JumpStats")]
    public bool jumping;
    public float jumpForce;
    public float jumpDamping;
    
    [Header("Inputs")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode jump = KeyCode.Space;
    
    [Header("Assignebels")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject dust;
    [SerializeField] private GameObject belly;
    [SerializeField] private GameObject dust2;
    [SerializeField] private GameObject feet;



    [Header("Outfit")] 
    public bool Kidle;
    
    
    
    private float startSpeed;
    private bool _isFacingRight;
    private bool sprinting = false;
    private bool CanStand = false;
    
    
    private Vector2 _movement;
    private Vector2 _lastDirection;
    private Vector2 normalSize;
    
    void Start()
    {
        normalSize = transform.localScale;
        currentStamina = maxStamina;
        startSpeed = currentSpeed;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.velocity.magnitude > currentSpeed)
        {
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity,currentSpeed);
        }
        JumpFall();
        if (jumping)
        {
            return;
        }
        Flip();
        Sprint();
        Move();
    }
    
    private void Flip()
    {
        if (_isFacingRight && _movement.x < 0f || !_isFacingRight && _movement.x > 0f && !jumping)
        {
            Vector2 localScale = transform.localScale;
            _isFacingRight = !_isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    
    public void Move()
    {
        Vector2 dir = _rb.transform.position - transform.position;
        dir = dir.normalized;
        _lastDirection = dir;
        
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        if (_rb.velocity != new Vector2(0,0) && !Kidle)
        {
            animator.Play("Walk");

        }
        else if (_rb.velocity == new Vector2(0,0) && !Kidle)
        {
            animator.Play("Idle");
        }
        
        if (_rb.velocity != new Vector2(0,0) && Kidle)
        {
            animator.Play("KidleWalk");
        }
        else if (_rb.velocity == new Vector2(0,0) && Kidle)
        {
            animator.Play("KidleIdle");
        }
        
        DOTween.To(() => currentSpeed, x => currentSpeed = x, speed,acceleration);
        
        _rb.velocity = new Vector2((_movement.x * currentSpeed),(_movement.y * currentSpeed));
    }
    public void Sprint()
    {
        if(Input.GetKeyDown(sprintKey) && currentStamina > 0)
        {
            currentSpeed = sprintSpeed;
            sprinting = true;
            currentStamina--;
        }
        if (Input.GetKeyUp(sprintKey))
        {
            currentSpeed = startSpeed;
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
        if (Input.GetKeyDown(jump) && !jumping && !Kidle)
        {
            GameObject Insdust2 = Instantiate(dust2, feet.transform.position, quaternion.identity);
            Destroy(Insdust2,2);

            CanStand = false;
            jumping = true;
            _rb.velocity *= jumpForce;
            animator.Play("Jump");
            
            Invoke(nameof(CanStandUp),1);
        }

        if (!Input.GetKey(jump) && CanStand && jumping && !Kidle)
        {
            animator.Play("StandUp");
            
            Invoke(nameof(StandingUp),0.5f);
        }
        
        
        if (Input.GetKeyDown(jump) && !jumping && Kidle)
        {
            GameObject Insdust2 = Instantiate(dust2,feet.transform.position,quaternion.identity);
            Destroy(Insdust2,2);

            CanStand = false;
            jumping = true;
            _rb.velocity *= jumpForce;
            animator.Play("KildleJump");
            
            Invoke(nameof(CanStandUp),1);
        }

        if (!Input.GetKey(jump) && CanStand && jumping && Kidle)
        {
            animator.Play("StandUpKilde");
            
            Invoke(nameof(StandingUp),1f);
        }
    }
    public void StandingUp()
    {
        jumping = false;
    }
    public void CanStandUp()
    {
        CanStand = true;
    }
    
    public void SpawnDust()
    {
        GameObject Insdust = Instantiate(dust,belly.transform.position,quaternion.identity);
        Destroy(Insdust,2);

    }
    private void FixedUpdate()
    {
        if (jumping)
        {
            _rb.velocity *= jumpDamping;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kidle"))
        {
            if (Kidle)
            {
                Kidle = false;
                return;
            }
            if(!Kidle)
            {
                Kidle = true;
            }
        }
    }
}
