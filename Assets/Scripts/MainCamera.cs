using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform camPlayer;
    public Vector3 suiviCamera;
    // Start is called before the first frame update
    void Start()
    {
        suiviCamera = camPlayer.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camPlayer.position - suiviCamera;
    }
}
