using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbeAnimation : MonoBehaviour
{
    public Vector3 amount;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        float randomTime = Random.Range(time + 0.5f, time);

        iTween.PunchScale(gameObject, iTween.Hash(
            "amount", amount,
            "time", time,
            "looptype", iTween.LoopType.loop
        ));
    }
}
