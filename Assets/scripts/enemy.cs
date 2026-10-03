using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject destoryedVFX;
    void OnParticleCollision(GameObject other)
    {
        Instantiate(destoryedVFX,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
