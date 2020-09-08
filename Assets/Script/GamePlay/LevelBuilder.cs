using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject paddelPrefab; 
    [SerializeField]
    private GameObject standartBlockPrefab;
    [SerializeField]
    private GameObject bonusBlockPrefab;
    [SerializeField]
    private GameObject pickupBlockPrefab ;

    private List<GameObject> blockPrefabs = new List<GameObject>();
    private List<GameObject> randomBlocks = new List<GameObject>();

    private List<PickupEffect> pickupBlocks = new List<PickupEffect>();
    private List<PickupEffect> randomPickupBlocks = new List<PickupEffect>();
    private PickupEffect pickupEffect ;

    private GameObject randomBlockPrefab ;

    private float screneSizeX;
    private float prefabSizeX;
    private float boxSizeXRoundedUp;
    
    private float blockRows = 3f;
    private float horizontalCountOfBlocks;

    private Vector2 paddelSpawnpos;
    // Start is called before the first frame update
    void Start()
    {
        //scene lenth 
        screneSizeX = Mathf.Floor(ScreenUtils.ScreenRight);

        //paddel spawn on the centre of bottom
        paddelSpawnpos = new Vector2((ScreenUtils.ScreenLeft+ ScreenUtils.ScreenRight)/2,ScreenUtils.ScreenBottom+1);
        Instantiate(paddelPrefab,paddelSpawnpos,Quaternion.identity);

        //Size of prefab
        prefabSizeX = standartBlockPrefab.GetComponent<BoxCollider2D>().size.x;
        boxSizeXRoundedUp = Mathf.CeilToInt(prefabSizeX);

        //Block buids
        BlockBuilder();

    }

    private void BlockBuilder()
    {
        //Check how many blocks we can create in the game
        horizontalCountOfBlocks = Mathf.Floor(screneSizeX * 2 );
        float yPos = ScreenUtils.ScreenTop - ((Mathf.Abs(ScreenUtils.ScreenTop) + Mathf.Abs(ScreenUtils.ScreenBottom)) / 5);
     

        //Block building loop
        for (int blockY = 0 ; blockY < blockRows ; blockY+= 1) 
        {
            for (int blockX = 0; blockX <= horizontalCountOfBlocks; blockX++)
            {
                PickRandomBlock();
                GameObject block = Instantiate(randomBlockPrefab,
                        new Vector2(-screneSizeX + (boxSizeXRoundedUp/2 * blockX), 4 - (boxSizeXRoundedUp/2 * blockY)),
                        Quaternion.identity);

            }

        }
    }
    private void PickRandomBlock()
    {
        for (int i = 0; i < ConfigurationUtils.StandardBlockSpawnProbability; i++)
        {
            blockPrefabs.Add(standartBlockPrefab);
        }

        for (int i = 0; i < ConfigurationUtils.BonusBlockSpawnProbability; i++)
        {
            blockPrefabs.Add(bonusBlockPrefab);
        }

        float totalPickupBlocks = ConfigurationUtils.FreezerBlockSpawnProbability + ConfigurationUtils.SpeedupBlockSpawnProbability;
        for (int i = 0; i < totalPickupBlocks; i++)
        {
            blockPrefabs.Add(pickupBlockPrefab);
            RandomPickupEffect();
        }

        int randomIndex = 0;
        while (blockPrefabs.Count > 0)
        {
            randomIndex = Random.Range(0, blockPrefabs.Count);
            randomBlocks.Add(blockPrefabs[randomIndex]);
            blockPrefabs.RemoveAt(randomIndex);
        }

        randomBlockPrefab = randomBlocks[Random.Range(0, randomBlocks.Count - 1)];
    }
    private void RandomPickupEffect()
    {
        for (int i = 0; i < ConfigurationUtils.FreezerBlockSpawnProbability; i++)
        {
            pickupBlocks.Add(PickupEffect.Freezer);
        }

        for (int i = 0; i < ConfigurationUtils.SpeedupBlockSpawnProbability; i++)
        {
            pickupBlocks.Add(PickupEffect.Speedup);
        }

        int randomIndex = 0;
        while (pickupBlocks.Count > 0)
        {
            randomIndex = Random.Range(0, pickupBlocks.Count);
            randomPickupBlocks.Add(pickupBlocks[randomIndex]);
            pickupBlocks.RemoveAt(randomIndex);
        }

        pickupEffect = randomPickupBlocks[Random.Range(0, randomPickupBlocks.Count)];
    }
}


