using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    void OnParticleCollision(GameObject other)
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
