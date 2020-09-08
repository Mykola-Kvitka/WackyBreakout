using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBlock : Blocks
{
    [SerializeField]
    
    private List<Sprite> standardBlockSprites;
  
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteIndex = Random.Range(0, standardBlockSprites.Count);
        spriteRenderer.sprite = standardBlockSprites[spriteIndex];

        score = ConfigurationUtils.StandardBlockPoints;
    }

  
}
