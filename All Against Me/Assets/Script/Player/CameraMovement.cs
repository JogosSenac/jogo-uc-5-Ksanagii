using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        
    }
}
