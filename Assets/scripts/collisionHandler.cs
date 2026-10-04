using UnityEngine;

public class collisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destoryedVFX;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(destoryedVFX,transform.position,Quaternion.identity);
        //Destroy(gameObject);
    }
}
