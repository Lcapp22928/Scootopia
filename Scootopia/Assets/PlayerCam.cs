using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float rotationSpeed = 5.0f;

    private Quaternion targetRotation;

    void Awake()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        transform.position = player.position + offset;
        Vector3 lookAtPosition = player.position + offset.normalized; // Calculate a position for the camera to look at
        targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position, Vector3.up); // Look towards the calculated position
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}