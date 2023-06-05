using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float zoomSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float padding;
    Vector3 moveDir;
    Vector2 mousePos;
    private float zoomScroll;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void LateUpdate()
    {
        Zoom();
        Pointer();
    }

    private void Pointer()
    {
        transform.Translate(Vector3.forward * moveDir.y * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * moveDir.x * moveSpeed * Time.deltaTime, Space.World);
    }
    private void OnPointer(InputValue input)
    {
        mousePos = input.Get<Vector2>();

        if (mousePos.x <= padding)
            moveDir.x = -1;
        else if (mousePos.x >= Screen.width - padding)
            moveDir.x = 1;
        else moveDir.x = 0;

        if (mousePos.y <= padding)
            moveDir.y = -1;
        else if (mousePos.y >= Screen.height - padding)
            moveDir.y = 1;
        else moveDir.y = 0;
    }

    private void Zoom()
    {
        transform.Translate(Vector3.forward * zoomScroll * Time.deltaTime * zoomSpeed, Space.Self);
    }
    private void OnZoom(InputValue input)
    {
        zoomScroll = input.Get<Vector2>().y;
    }
}
