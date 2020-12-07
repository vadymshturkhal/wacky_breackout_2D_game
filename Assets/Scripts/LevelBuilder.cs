using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    #region Fields
    const int Rows = 3;
    Object[] blockSprites;
    GameObject block;
    GameObject bonusBlock;
    GameObject pickupBlock;
    GameObject paddle;

    float firstRowHeight;

    float standartProbably;
    float bonusProbably;
    float freezerProbably;
    float speedupProbably;
    #endregion

    // Instantiate paddle
    // Load sprites
    void Start()
    {
        block = Resources.Load<GameObject>("BlockPrefabs/StandartBlock");
        bonusBlock = Resources.Load<GameObject>("BlockPrefabs/BonusBlock");
        pickupBlock = Resources.Load<GameObject>("BlockPrefabs/PickupBlock");

        paddle = Resources.Load<GameObject>("PaddlePrefab");

        Instantiate<GameObject>(paddle, new Vector3(0, -9, 0), Quaternion.identity);

        firstRowHeight = ScreenUtils.ScreenTop / 5 * 4;
        
        standartProbably = ConfigurationUtils.StandartBlockProbably;
        bonusProbably = standartProbably + ConfigurationUtils.BonusBlockProbably;
        freezerProbably = bonusProbably + ConfigurationUtils.FreezerBlockProbably;
        speedupProbably = freezerProbably + ConfigurationUtils.SpeedupBlockProbably;

        CreateBlockSquadron();
    }


    // Calculates half width of sprite
    // Calculate probably for each block
    void CreateBlockSquadron()
    {
        Vector2 size = block.GetComponent<BoxCollider2D>().size;
        float width = size.x;
        float height = size.y;
        float halfWidth = size.x / 2;

        for (int i = 0; i < Rows; i ++)
        {

            Vector3 spawnPosition = new Vector3(ScreenUtils.ScreenLeft + halfWidth, firstRowHeight, 0);  // ScreenUtils.ScreenTop - top

            while (spawnPosition.x <= ScreenUtils.ScreenRight)
            {
                // 100%
                float randomBlock = Random.Range(0, 101);

                if (randomBlock <= ConfigurationUtils.StandartBlockProbably)
                {
                    Instantiate<GameObject>(block, spawnPosition, Quaternion.identity);
                }
                else if (randomBlock <= bonusProbably)
                {
                    Instantiate<GameObject>(bonusBlock, spawnPosition, Quaternion.identity);
                }
                else if (randomBlock <= freezerProbably)
                {
                    GameObject pickupGameobject = Instantiate<GameObject>(pickupBlock, spawnPosition, Quaternion.identity);
                    PickupBlock pickupBlockScript = pickupGameobject.GetComponent<PickupBlock>();
                    pickupBlockScript.Effect = PickupEffect.Freezer;
                }
                else if (randomBlock <= speedupProbably)
                {
                    GameObject pickupGameobject = Instantiate<GameObject>(pickupBlock, spawnPosition, Quaternion.identity);
                    PickupBlock pickupBlockScript = pickupGameobject.GetComponent<PickupBlock>();
                    pickupBlockScript.Effect = PickupEffect.Speedup;
                }

                spawnPosition.x += width;
            }
            firstRowHeight -= height + 1;
        }
    }
}
