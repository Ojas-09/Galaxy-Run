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
    float POSX;
    float POSY = 44.09f;
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
        //transform.Rotate(0f, 0f, 50f * Time.deltaTime, Space.Self);

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
        transform.localRotation = Quaternion.Euler(POSX,POSY,POSZ);
    }

    public void OnMove(InputValue value)
    {
        moves = value.Get<Vector2>();
    }
}
