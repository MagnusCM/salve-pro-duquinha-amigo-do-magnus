using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components:")]
    [SerializeField] private Rigidbody rb;
    
   
    [Header("Physics:")]
    public float speed;
    [SerializeField] private float jumpForce;
   
    private Vector2 moveInput;

    private Item[] item;
    private InventoryManager inventoryManager;

    public Animator animator;

    void Start()
    {

    }

    
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(speed * moveInput.x, rb.velocity.y, speed * moveInput.y);


    }
}
