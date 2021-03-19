using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SoundManagerScript.PlaySound("playerDeath");
            Destroy(gameObject);
            LevelManagerScript.instance.Respawn();
        }
    }

}
