using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Paddle : MonoBehaviour
{
    #region Fields
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad; 
    float moveUnitPerSecond = ConfigurationUtils.PaddleMoveUnitsPerSecond;
    Rigidbody2D rb2d;
    Vector2 velocity;
    float halfColliderWidth;
    Vector3 position;
    bool isFrozen = false;
    Timer frozenTimer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocity = new Vector2(1, 0);

        BoxCollider2D bc2D = GetComponent<BoxCollider2D>();
        halfColliderWidth = bc2D.size.x / 2;

        EventManager.AddFreezerEffectListener(HandleFreezerEffectActivatedEvent);
        frozenTimer = gameObject.AddComponent<Timer>();
    }

    // Move paddle left-right
    void FixedUpdate()
    {
        // move for horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0 && !isFrozen)
        {
            Vector2 position = rb2d.position;
            position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond *
                Time.deltaTime;
            position.x = CalculateClampedX(position.x);
            rb2d.MovePosition(position);
        }

        if (frozenTimer.Finished)
        {
            isFrozen = false;
        }
    }

    float CalculateClampedX(float x)
    {
        // clamp left and right edges
        if (x - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if (x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - halfColliderWidth;
        }
        return x;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
      
            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    // Add a freeze timer or update it if already added
    void HandleFreezerEffectActivatedEvent(float duration)
    {
        if (isFrozen)
        {
            frozenTimer.MakeLonger(duration);
        }
        else if (!isFrozen)
        {
            frozenTimer.Duration = duration;
            frozenTimer.Run();
            isFrozen = true;
        }
    }
}
