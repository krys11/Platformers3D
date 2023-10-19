using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [Range(0.1f, 50f)]
    public float detectDistance = 3f;
    public Transform[] points;
    NavMeshAgent navMesh;
    Transform player;
    public GameObject GPlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
        if(navMesh != null){
            navMesh.destination = points[Random.Range(0, points.Length)].position;
        }
    }

    void Update()
    {
        deplacementEnemi();
        agrandiEnnemi();
        prendrePlayerEnChasse();
    }

    void deplacementEnemi(){
        float dist = navMesh.remainingDistance;
        if(dist <= 0.05f){
            navMesh.destination = points[Random.Range(0,points.Length)].position;
        }
    }

    void prendrePlayerEnChasse(){
        float distanceEntreEnemiPalyer = Vector3.Distance(transform.position, player.position);
        if(distanceEntreEnemiPalyer <= detectDistance){
            navMesh.destination = player.position;
            navMesh.speed = 2f;
        }else{
            // navMesh.destination = points[Random.Range(0,3)].position;
            navMesh.speed = 1.5f;
        }
    }

    void agrandiEnnemi(){
        if(Vector3.Distance(GPlayer.transform.position, gameObject.transform.position) <= detectDistance + 1){
            iTween.ScaleTo(gameObject, Vector3.one, 0.5f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
    }
}
