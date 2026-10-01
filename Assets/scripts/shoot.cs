using UnityEngine;
using UnityEngine.InputSystem;

public class shoot : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    bool isfiring = false;
    void Update()
    {
        processfiring();
    }
    public void OnFire(InputValue value)
    {
        isfiring = value.isPressed;
    }

    void processfiring()
    {
        foreach(GameObject laser in lasers)
        {
            var emissionmodule = laser.GetComponent<ParticleSystem>().emission;
            emissionmodule.enabled = isfiring;
        }
        
    }
}
