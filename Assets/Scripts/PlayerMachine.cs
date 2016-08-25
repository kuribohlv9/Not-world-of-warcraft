using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerInput))]

public class PlayerMachine : MonoBehaviour {

    private enum PlayerDirection
    {
        Up,
        Down,
        Left,
        Right
    };

    private Vector2 MoveDirection;
    private PlayerDirection Direction;
    private bool Attack = false;
    private float AttackTimer;

    private PlayerInput input;
    private Rigidbody2D rigidbody;
    private Animator anim;
    
    public float MoveSpeed = 1.0f;
    public float AttackSpeed = 1.0f;

	// Use this for initialization
	void Start ()
    {
        Direction = PlayerDirection.Up;
        input = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveDirection = input.Current.MoveInput;
        HandleDirection(MoveDirection);
        HandleAttack();
        
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

    private void HandleDirection(Vector2 movement)
    {
        if (movement != Vector2.zero)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (movement.y == 1 && movement.x == 0)
        {
            Direction = PlayerDirection.Up;
            anim.SetInteger("Direction", 1);
            return;
        }
        if(movement.x == 1 && movement.y == 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = 1;
            transform.localScale = temp;

            Direction = PlayerDirection.Right;
            anim.SetInteger("Direction", 2);
            return;
        }
        else if (movement.y == -1 && movement.x == 0)
        {
            Direction = PlayerDirection.Down;
            anim.SetInteger("Direction", 3);
            return;
        }
        else if (movement.x == -1 && movement.y == 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = -1;
            transform.localScale = temp;

            Direction = PlayerDirection.Left;
            anim.SetInteger("Direction", 4);
            return;
        }
        else
        {
            anim.SetInteger("Direction", 0);
        }
    }
    private void HandleAttack()
    {
        if (input.Current.AttackInput)
        {
            Attack = true;
            AttackTimer = AttackSpeed;
            anim.SetBool("IsAttacking", true);
        }
        if(Attack)
        {
            MoveDirection = Vector2.zero;
            AttackTimer -= Time.deltaTime;
            if(AttackTimer < 0)
            {
                Attack = false;
                anim.SetBool("IsAttacking", false);
            }
        }
    }
}
