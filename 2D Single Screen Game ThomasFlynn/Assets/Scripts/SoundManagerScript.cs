using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerDeathSound, teleportSound, findTreasureSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerDeathSound = Resources.Load<AudioClip>("playerDeath");
        teleportSound = Resources.Load<AudioClip>("teleport");
        findTreasureSound = Resources.Load<AudioClip>("findTreasure");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
