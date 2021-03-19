using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerJumpSound, playerDeathSound, teleportSound, findTreasureSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("playerJump");
        playerDeathSound = Resources.Load<AudioClip>("playerDeath");
        teleportSound = Resources.Load<AudioClip>("teleport");
        findTreasureSound = Resources.Load<AudioClip>("findTreasure");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "playerJump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "teleport":
                audioSrc.PlayOneShot(teleportSound);
                break;
            case "findTreasure":
                audioSrc.PlayOneShot(findTreasureSound);
                break;
        }
    }
}
