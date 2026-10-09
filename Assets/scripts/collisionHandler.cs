using UnityEngine;

public class collisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destoryedVFX;
    gamescenemanager gamescenemanager;
    void Start()
    {
        gamescenemanager = FindAnyObjectByType<gamescenemanager>();
    }
    void OnTriggerEnter(Collider other)
    {
        //gamescenemanager.reloadlevel();
        Instantiate(destoryedVFX,transform.position,Quaternion.identity);
        //Destroy(gameObject);
    }
}
