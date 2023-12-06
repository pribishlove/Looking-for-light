using UnityEngine;

public class RespawnOnCollision : MonoBehaviour
{
    public Vector2 respawnPoint;
    public DeathCounter deathCounter;

    private void Start()
    {
        respawnPoint = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
            PlayerDeath();
        }
    }

    void Die()
    {
        RespawnPlayer();
    }

    void RespawnPlayer()
    {
        transform.position = respawnPoint;
    }

    void PlayerDeath()
    {
        deathCounter.PlayerDied();
    }
}
