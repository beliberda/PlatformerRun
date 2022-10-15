using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
// bhrngijerng
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private int jumpForce = 5;
    private bool isGrounded = false;


    private Rigidbody2D rb; //Сслыка на компонент RigidBody
    private SpriteRenderer sprite; 


    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

 


    private void FixedUpdate() //Инициализация наших методов движения
    {
        CheckGround();
    }


    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse); //Добавить силы, указываем направление вверх и указываем импульс
    }
    private void CheckGround() 
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }


       private void Update() //Инициализация наших методов движения
    {
        if (Input.GetButton("Horizontal"))
         Run();
        if (Input.GetButtonDown("Jump") && isGrounded)
         Jump();
    }
}
