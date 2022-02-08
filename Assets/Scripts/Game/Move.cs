using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField][Range(0, 50)] private float accelerationSpeed = 10;// скорость 
    [SerializeField][Range(0, 20)] private float jumpForce = 1;
    [SerializeField][Range(0, 5)]  private float jumpBoost = 0;// ВО сколько раз удлинниться прыжок (0 - зависит только от скорости )

    #region events, properties and fields
    // могу ли я прыгать
    private bool canMove = true;
    private bool canJump = false;
    // действую ли я
    private bool isMoving = false;
    private bool isJumping = false;

    private float speed;
    private Rigidbody2D rb;

    #endregion

    public bool IsMoving { get => isMoving; }
    public bool IsJumping { get => isJumping; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool CanJump { get => canJump; set => canJump = value; }
    public float Speed { get => speed; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    public void rightMove()
    {
        speed = accelerationSpeed;
        isMoving = true;
    }
    public void leftMove()
    {
        speed = -accelerationSpeed;
        isMoving = true;
    }
    public void stopMove()
    {
        speed = 0;
        isMoving = false;
    }


    public void jump()
    {
        isJumping = true;
    }
    public void stopJump()
    {
        isJumping = false;
    }

    void moveLogic()
    {
        if (canMove)
        {
            float xVelocity, yVelocity;// параметры для вектора движения
            xVelocity = speed;
            yVelocity = rb.velocity.y;

            Vector2 force = new Vector2(xVelocity, yVelocity);
            rb.AddForce(rb.mass * force);// нужно проверить нужгно ли умнажать на массу
        }
    }
    void jumpLogic()// если метод вызываеться значит прыгаем 
    {
        if (canJump && isJumping)
        {
            Vector2 force = new Vector2(rb.velocity.x * jumpBoost, jumpForce);// вектор прыжка 
            rb.AddForce(rb.mass * force, ForceMode2D.Impulse);// rb.mass убираем влияние массы на силу прыжка
        }
    }


    private void FixedUpdate()
    {
        jumpLogic();
        moveLogic();
    }
}
// использовать вместе с drageForce