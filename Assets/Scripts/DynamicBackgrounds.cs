using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dynamic background manager, keeps track of the <see cref="Player"/> height to change from a different set of Sprites.
/// </summary>
public class DynamicBackgrounds : MonoBehaviour
{
    public Transform player;
    public int groundCeiling;
    public int skyCeiling;

    public SpriteRenderer[] groundSprites;
    public SpriteRenderer[] skySprites;
    Color whiteNoAlpha = new Color(1, 1, 1, 0);
    bool toggleSky;
    bool toggleSpace;
    float time;

    void Start()
    {
        time = 2f;
        toggleSky = false;
        toggleSpace = false;
    }
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
