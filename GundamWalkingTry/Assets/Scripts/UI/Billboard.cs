using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    [SerializeField] Transform camera;

    private void Start()
    {
        camera = CameraManager.Instance.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }

}
