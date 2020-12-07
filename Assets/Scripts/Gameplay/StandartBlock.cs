using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Get weight of block
// Choose a sprite
public class StandartBlock : Block
{
    Object[] standartBlockSprites;

    void Start()
    {
        // Points quantity for the block
        weight = ConfigurationUtils.StandartBlockPoint;
        
        standartBlockSprites = Resources.LoadAll("StandartBlockSprites", typeof(Sprite));
        SpriteRenderer standartBlockSpriteRenderer = GetComponent<SpriteRenderer>();
        int randomSprite = Random.Range(0, standartBlockSprites.Length);
        standartBlockSpriteRenderer.sprite = (Sprite)standartBlockSprites[randomSprite];

        base.Start();
    }
}
