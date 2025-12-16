using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] int hitPoints = 6;
    [SerializeField] int scoreValue = 10;
    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
