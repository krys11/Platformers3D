using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCoin : MonoBehaviour
{
    public Vector3 animeDirection;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(animeDirection * Time.deltaTime);
    }
}
