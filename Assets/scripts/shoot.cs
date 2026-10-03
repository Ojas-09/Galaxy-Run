using UnityEngine;
using UnityEngine.InputSystem;

public class shoot : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetpoint;
    [SerializeField] float targetdistance;
    bool isfiring = false;
    

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        processfiring();
        movecrosshair();
        movetargetpoint();
        aimlaser();
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

    void movetargetpoint()
    {
        Vector3 targetpostionpoint = new Vector3(Mouse.current.position.ReadValue().x,Mouse.current.position.ReadValue().y,targetdistance);
        targetpoint.position = Camera.main.ScreenToWorldPoint(targetpostionpoint);
    }

    void aimlaser()
    {
        foreach(GameObject laser in lasers)
        {
            Vector3 firedirection = targetpoint.position - laser.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(firedirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
