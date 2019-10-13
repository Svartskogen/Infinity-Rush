using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBackgrounds : MonoBehaviour
{
    public Transform player;
    //public Sprite groundLevelSprite;
    public int groundCeiling;
    public int skyCeiling;
    //public Sprite skyLevelSprite;

    public SpriteRenderer[] groundSprites;
    public SpriteRenderer[] skySprites;
    Color whiteNoAlpha = new Color(1, 1, 1, 0);
    bool toggleSky;
    bool toggleSpace;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 2f;
        toggleSky = false;
        toggleSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y > groundCeiling)
        {
            toggleSky = true;
        }
        if (player.position.y > skyCeiling)
        {
            time = 0.3f;
            toggleSpace = true;
        }
        if (toggleSky)
        {
            foreach(SpriteRenderer spriteRenderer in groundSprites)
            {
                spriteRenderer.color = Color.Lerp(spriteRenderer.color, whiteNoAlpha, time * Time.deltaTime);
            }
            //text.color = Color.Lerp(text.color, desiredColor, time * Time.deltaTime);
        }
        if (toggleSpace)
        {
            foreach (SpriteRenderer spriteRenderer in skySprites)
            {
                spriteRenderer.color = Color.Lerp(spriteRenderer.color, whiteNoAlpha, time * Time.deltaTime);
            }
        }
    }
}
