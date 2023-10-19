using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfos : MonoBehaviour
{
    public static PlayerInfos pi;
    public int pieces = 0;
    public int vie = 3;
    public Image[] vieImages;
    public Text nbrPiece;
    public PlayerCheckPoint playerchekpoint;
    // Start is called before the first frame update

    void Awake()
    {
        pi = this;
    }

    public void takePiece()
    {
        pieces++;
        nbrPiece.text = pieces.ToString();
    }

    public void perdreVie(int choque)
    {
        vie += choque;
        if(vie > 3) vie = 3;
        if(vie <= 0){
            vie = 0;
            playerchekpoint.setVieAndLastPosition();
        };
        setCoeur();
    }

    public void setCoeur(){
        // on vide la barre de vie, on le met vide
        foreach (Image image in vieImages)
        {
            image.enabled = false;
        }

        // on rempli la barre de vie pour que sa soit conforme au nombre de vie
        for (int i = 0; i < vie; i++)
        {
            vieImages[i].enabled = true;
        }
    }
}
