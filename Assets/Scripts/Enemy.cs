using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] int hitPoints = 6;
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
