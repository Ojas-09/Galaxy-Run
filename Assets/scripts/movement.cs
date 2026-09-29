using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    [SerializeField] float controlSpeed=10f;
    [SerializeField] float XClampRange = 5f;
    [SerializeField] float YClampRange = 5f;
    Vector2 moves;

    float StartX;
    float StartY;

    [SerializeField] float rollfactor=20f;
    [SerializeField] float rollspeed = 10f;
    float POSX;
    float POSY;
    float POSZ;

    
    void Start()
    {
        StartX = transform.localPosition.x;
        StartY = transform.localPosition.y;


        POSX = transform.localEulerAngles.x;
        POSY = transform.localEulerAngles.y;
        POSZ = transform.localEulerAngles.z;
    }
    
    void Update()
    {
        motion();
        Rotate();

    }

    void motion()
    {
        float xoffset = moves.x * controlSpeed * Time.deltaTime;
        float yoffset = moves.y * controlSpeed * Time.deltaTime;
        float RawPosX = transform.localPosition.x + xoffset;
        float RawPosY = transform.localPosition.y + yoffset;
        float clampedPosX = Mathf.Clamp(RawPosX,StartX - XClampRange, StartX + XClampRange);
        float clampedPosY = Mathf.Clamp(RawPosY,StartY - YClampRange, StartY + YClampRange);
        

        transform.localPosition = new Vector3(clampedPosX, clampedPosY, transform.localPosition.z);
    }

    void Rotate()
    {
        Quaternion targetlocation = Quaternion.Euler(-(POSX+12f)*moves.y,(POSY),-(POSZ+12f)*moves.y);
        if (moves.x > 0)
        {   
            targetlocation = Quaternion.Euler(-(POSX-15f)*moves.x,(POSY),(POSZ));
        }
        else if (moves.x < 0)
        {
            targetlocation = Quaternion.Euler((POSX),(POSY),-(POSZ+15f)*moves.x);
        }
        transform.localRotation = Quaternion.Lerp(transform.localRotation,targetlocation,rollspeed*Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        moves = value.Get<Vector2>();
    }
}
