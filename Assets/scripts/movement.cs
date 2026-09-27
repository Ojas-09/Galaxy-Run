using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [SerializeField] float controlSpeed=10f;
    [SerializeField] float XClampRange = 5f;
    [SerializeField] float YClampRange = 5f;
    Vector2 moves;

    float StartX;
    float StartY;
    void Start()
    {
        StartX = transform.localPosition.x;
        StartY = transform.localPosition.y;
    }
    
    void Update()
    {
        motion();

    }

    private void motion()
    {
        float xoffset = moves.x * controlSpeed * Time.deltaTime;
        float yoffset = moves.y * controlSpeed * Time.deltaTime;
        float RawPosX = transform.localPosition.x + xoffset;
        float RawPosY = transform.localPosition.y + yoffset;
        float clampedPosX = Mathf.Clamp(RawPosX,StartX - XClampRange, StartX + XClampRange);
        float clampedPosY = Mathf.Clamp(RawPosY,StartY - YClampRange, StartY + YClampRange);
        

        transform.localPosition = new Vector3(clampedPosX, clampedPosY, transform.localPosition.z);
    }

    public void OnMove(InputValue value)
    {
        moves = value.Get<Vector2>();
    }
}
