using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Vector2 vector2;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void Update()
    {
        MoveAnim (vector2);
        MoveDirection (vector2);
    }
    
    private void OnMove(InputValue inputValue)
    {
        vector2 = inputValue.Get<Vector2>();
    }

    private void MoveCharacter()
    {
        rb.velocity = vector2 * speed;
    }

    private void MoveAnim(Vector2 vector2)
    {
        bool move = false;
        move = vector2 != Vector2.zero ? true : false;

        animator.SetBool("move", move);
    }

    private void MoveDirection(Vector2 vector2)
    {
        if (vector2.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (vector2.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
