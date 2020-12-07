using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Destroys block
// Without animation
public class Block : MonoBehaviour
{
    protected int weight = 1;

    AddScore addScore;

    virtual protected void Start()
    {
        addScore = new AddScore();
        EventManager.AddScoreInvoker(this);
    }

    virtual protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            // This isn't an optimal object-oriented solution because Block objects shouldn't really have to
            // know about the existence of the HUD or the methods it exposes, but it's a reasonable solution
            // given the C# knowledge we have at this point.
            // Don't worry, we'll make this much better once we
            // know about delegates and event handling.

            // Finally, we did it better!
            addScore.Invoke(weight);
            Destroy(gameObject);
        }
    }

    public void AddScoreListener(UnityAction<int> listener)
    {
        addScore.AddListener(listener);
    }
}
