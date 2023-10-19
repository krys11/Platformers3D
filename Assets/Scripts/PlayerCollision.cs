using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public int nbrDePieceRamasse;
    public GameObject particulEffectDestroyPiece;
    public GameObject particulEffectDestroyEnemies;
    public GameObject piece;
    public GameObject cam1;
    public AudioClip ennemiClip;
    public AudioClip pieceClip;
    public SkinnedMeshRenderer skinmeshrenderer;
    AudioSource audioSong;
    bool isTime = true;
    bool isImortel = false;

    private void Start()
    {
        audioSong = GetComponent<AudioSource>();
    }
   

    void OnTriggerEnter(Collider other)
    {
        // si on entre en collision avec une pieces
        if(other.gameObject.tag == "piece"){
            audioSong.PlayOneShot(pieceClip);
            GameObject obj =  Instantiate(particulEffectDestroyPiece, other.transform.position, Quaternion.identity);
            Destroy(obj, 0.8f);
            PlayerInfos.pi.takePiece(); // on ajoute +1
            Destroy(other.gameObject); // on detruit la piece
        }

        // si on entre en collision avec une pieces
        if(other.gameObject.tag == "cam1triger"){
            cam1.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "cam1triger"){
            cam1.SetActive(false);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "hurt" && !isImortel)
        {
            print("Aiiiiiie");
            isImortel = true;
            PlayerInfos.pi.perdreVie(-1);
            iTween.PunchPosition(gameObject, Vector3.back * 2f, 0.5f);
            StartCoroutine("setIsimortel");
        }

         if (hit.gameObject.tag == "dos" && isTime)
        {
            hit.gameObject.transform.parent.GetComponent<BoxCollider>().enabled = false;
            isTime = false;
            audioSong.PlayOneShot(ennemiClip);
            iTween.PunchScale(hit.gameObject.transform.parent.gameObject, new Vector3(60,60,60), 0.5f);
            GameObject obj =  Instantiate(particulEffectDestroyEnemies, hit.transform.position, Quaternion.identity);
            GameObject objPiece =  Instantiate(piece, hit.transform.position + new Vector3(0,0,1), Quaternion.identity);
            objPiece.transform.Rotate(new Vector3(0,0,3f), 0.3f);
            Destroy(obj, 0.3f);
            Destroy(hit.gameObject.transform.parent.gameObject, 0.3f);
            StartCoroutine("setIstimeFalse");
        }

        if(hit.gameObject.tag == "fall"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // on remet isTime a True
     IEnumerator setIstimeFalse(){
        yield return new WaitForSeconds(0.4f);
        isTime = true;
    }

    IEnumerator setIsimortel(){

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            skinmeshrenderer.enabled = !skinmeshrenderer.enabled;
        }

        yield return new WaitForSeconds(1);
        skinmeshrenderer.enabled = true;
        isImortel = false;
    }
}
