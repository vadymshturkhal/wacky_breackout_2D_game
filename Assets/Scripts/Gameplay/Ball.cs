using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// FIXME change speed of current "Ball"

// Has a freeze timer after spawn
// Has a timer for lifetime
// Clamp in screen
// Destroy when fall bottom of the screen
// Monitor "EffectUtils.SpeedBoost" for change speed
public class Ball : MonoBehaviour
{
    Rigidbody2D rb2D;

    Vector2 force;

    Timer ballLifetime;
    Timer ballFreezeAfterSpawn;

    ReduceBallsLeft reduceBallsLeftEvent;

    float radius;

    bool moving = false;

    float angle = 90 * Mathf.Deg2Rad;
 
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        radius = GetComponent<CircleCollider2D>().radius;

        force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        
        // FIXME event
        ballLifetime = gameObject.AddComponent<Timer>();
        ballLifetime.Duration = ConfigurationUtils.BallLifeTime;
        ballLifetime.Run();
        // EventManager.AddTimerEventListener(BallLifetimeEvent);


        // FIXME event
        ballFreezeAfterSpawn = gameObject.AddComponent<Timer>();
        ballFreezeAfterSpawn.Duration = ConfigurationUtils.BallFreezeAfterSpawn;
        ballFreezeAfterSpawn.Run();
        // EventManager.AddTimerEventListener(BallFreezeAfterSpawnEvent);


        EventManager.AddBoostBallEffectListener(HandleAddBoostBallEffectActivatedEvent);

        reduceBallsLeftEvent = new ReduceBallsLeft();
        EventManager.ReduceBallsLeftInvoker(this);
    }

    void FixedUpdate()
    {
        if (ballLifetime.Finished)
        {
            Destroy(gameObject);
        }

        if (ballFreezeAfterSpawn.Finished && !moving)
        {
            moving = !moving;
            rb2D.AddForce(-force * angle);
        }

        ClampInScreen();
    }

    void BallLifetimeEvent()
    {
        Destroy(gameObject);
    }

    void BallFreezeAfterSpawnEvent()
    {
        // moving = !moving;
        print("Freeze after spawn event called");
        rb2D.AddForce(-force * angle);
    }

    public void SetDirection(Vector2 direction)
    {
        float speed = rb2D.velocity.magnitude;
        rb2D.velocity = direction * speed;
    }

    void OnBecameInvisible()
    {
        ballLifetime.Stop();
        reduceBallsLeftEvent.Invoke();
    }

    // Revert vectors for screen resolution
    void ClampInScreen()
    {
        Vector3 position = transform.position;

        // Axis X
        if (position.x - radius < ScreenUtils.ScreenLeft)
        {
            rb2D.velocity = new Vector2(-rb2D.velocity.x, rb2D.velocity.y);
        }
        else if (position.x + radius > ScreenUtils.ScreenRight)
        {
            rb2D.velocity = new Vector2(-rb2D.velocity.x, rb2D.velocity.y);
        }

        // Axis Y
        if (position.y - radius < ScreenUtils.ScreenBottom)
        {
            // Ball became invisible
        }
        else if (position.y + radius > ScreenUtils.ScreenTop)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -rb2D.velocity.y);
        }
    }

    void HandleAddBoostBallEffectActivatedEvent(bool start)
    {
        if (start)
        {
            // FIXME
            // SpeedBoost.ImpulseForce *= 2;
            rb2D.velocity *= EffectUtils.SpeedBoost;
        }
        else if (!start)
        {
            rb2D.velocity /= EffectUtils.SpeedBoost;
        }
    }

    public void ReduceBallsLeftListener(UnityAction listener)
    {
        reduceBallsLeftEvent.AddListener(listener);
    }
}
