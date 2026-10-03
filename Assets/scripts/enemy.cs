using UnityEngine;

public class enemy : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
    }
}
