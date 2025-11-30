using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
