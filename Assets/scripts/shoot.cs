using UnityEngine;
using UnityEngine.InputSystem;

public class shoot : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    bool isfiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        processfiring();
        movecrosshair();
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

    void movecrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }
}
