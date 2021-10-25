using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float orthographicSize;
    private float targetOrthographicSize;

    private void Start()
    {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleZoom()
    {
        float zoomAmount = 2f;
        targetOrthographicSize += -Input.mouseScrollDelta.y * zoomAmount;

        float minOrthographicSize = 10;
        float maxOrthographicSize = 30;
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);

        float zoomSpeed = 5f;
        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);

        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }

    private void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y).normalized;
        float moveSpeed = 30f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
