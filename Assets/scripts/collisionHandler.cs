using UnityEngine;

public class collisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit " + other.name);
    }
}
