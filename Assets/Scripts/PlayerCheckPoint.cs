using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    public Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "checkpoint"){
            lastPosition = transform.position;
            other.gameObject.GetComponent<AnimateCoin>().enabled = true;
        }
    }

    public void setVieAndLastPosition(){
        transform.position = lastPosition;
        PlayerInfos.pi.perdreVie(3);
    }

}
