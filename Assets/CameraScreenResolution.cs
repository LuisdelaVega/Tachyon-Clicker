using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenResolution : MonoBehaviour
{
    private float defaultWidth;
    private void Start()
    {
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    private void Update()
    {
        Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
    }
}
