using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    Bu Script Nas�l �al���yor?

        1-Bu scriptin g�revi, ayr�k tipte olan engellerin Y ekseni konumunu ve rengini ayarlamakt�r.
        2-Di�er eksenlerdeki konumu ayarlamama nedenimiz, x ekseninin sabit olmas�, z de�erini ise daha sonra ba�ka bir scriptten verecek olmam�z.
        3-Y ekseninde konumunu ayarlamaktaki amac�m�z, �stteki engelin �st yola, alttaki engelin de alt yola endeksli tam kenar kenara denk gelecekleri �ekilde konumland�rmakt�r.
        4-Yollar�n y eksenindeki konumu ve scale de�eri bilinmekte, engelin de scale de�eri bilinmektedir. 
        4.1 Bu y�zden kullanaca��m�z form�l: ---O1.POS.Y= (R1.POS.Y+(R1.SCL.Y/2))+(O1.SCL.Y/2)--- VE ---O2.POS.Y= (R2.POS.Y-(R2.SCL.Y/2))-(O2.SCL.Y/2)--- �eklindedir.

    */
public class SeparateObstacle : MonoBehaviour
{
    //Objects
    private GameObject obstacle1; //1.Child obje (Alttaki engel)
    private GameObject obstacle2; //2.Child Obje (�stteki engel)
    private GameObject obstacleEndPoint;
    private GameObject road1; //Alttaki yol
    private GameObject road2; //�stteki yol

    //Obstacle Z position Offset
    [SerializeField] private float minZOffset; // obstacle2'nin obstacle1'den en az uzakl���
    [SerializeField] private float maxZOffset; // obstacle2'nin obstacle1'den en fazla uzakl���
    [SerializeField] private float ZPosOffset; // Rastgele olarak �retilecek offset de�erini bu de�i�kende tutaca��z.
    [SerializeField] private int backOrForward; //obstacle2, obstacle1'in ilerisinde mi gerisinde mi olacak?

    //Obstacle Y position
    private float obstacle1YPosition; //obstacle1'in form�l ile buldu�umuz Y eksenindeki de�erini bu de�i�kende tutaca��z.
    private float obstacle2YPosition; //obstacle2'nin form�l ile buldu�umuz Y eksenindeki de�erini bu de�i�kende tutaca��z.
    private Vector3 obstacle1Position; //obstacle1'in pozisyon bilgisini bu de�i�kende tutaca��z.
    private Vector3 obstacle2Position; //obstacle2'nin pozisyon bilgisini bu de�i�kende tutaca��z.

    //Obstacle color
    private Color playerColor = Color.red; //Oyuncu rengi. Bu daha sonra de�i�ecek.
    private Color[] colorPalette = new Color[4]; //Renk se�eneklerimizi tuttu�umuz dizi.
    private Color obstacle1Color = new Color(); //obstacle1'in rengini bu de�i�kende tutaca��z.
    private Color obstacle2Color = new Color(); //obstacle2'nin rengini bu de�i�kende tutaca��z.

    private MaterialPropertyBlock obstacle1PropertyBlock;
    private MaterialPropertyBlock obstacle2PropertyBlock;
    private Renderer obstacle1Renderer;
    private Renderer obstacle2Renderer;

    



    private void Awake()
    {
        colorPalette[0] = Color.yellow;
        colorPalette[1] = Color.red;
        colorPalette[2] = Color.blue;
        colorPalette[3] = Color.green;

        obstacle1 = this.transform.GetChild(0).gameObject; //Objelerimizi cache ediyoruz.
        obstacle2 = this.transform.GetChild(1).gameObject;
        obstacleEndPoint = this.transform.GetChild(2).gameObject;

        road1 = GameObject.FindGameObjectWithTag("Road1");
        road2 = GameObject.FindGameObjectWithTag("Road2");

        obstacle1Renderer = obstacle1.GetComponent<Renderer>();
        obstacle2Renderer = obstacle2.GetComponent<Renderer>();

        obstacle1PropertyBlock = new MaterialPropertyBlock();
        obstacle2PropertyBlock = new MaterialPropertyBlock();
    }

    private void OnEnable()
    {
        SetObstacle1Position();
        SetObstacle2Position();
        SetObstacle1Color();
        SetObstacle2Color();
    }


    void SetObstacle1Position() //Alttaki engelin (obstacle1) konumunun belirlendi�i fonksiyon.
    {
        //Form�l=> O1.POS.Y= (R1.POS.Y+(R1.SCL.Y/2))+(O1.SCL.Y/2)


        obstacle1YPosition = (road1.transform.position.y + (road1.transform.localScale.y / 2)) + (obstacle1.transform.localScale.y / 2);
        obstacle1Position = new Vector3(0, obstacle1YPosition, this.gameObject.transform.position.z);
        obstacle1.transform.position = obstacle1Position;


    }
    void SetObstacle2Position() //�stteki engelin (obstacle2) konumunun belirlendi�i fonksiyon.
    {
        //Form�l=> O2.POS.Y= (R2.POS.Y-(R2.SCL.Y/2))-(O2.SCL.Y/2)

        obstacle2YPosition = (road2.transform.position.y - (road2.transform.localScale.y / 2)) - (obstacle2.transform.localScale.y / 2);

        backOrForward = Random.Range(0, 2);
        ZPosOffset = Random.Range(minZOffset, maxZOffset);


        if (backOrForward == 0) //Arkadaysa
        {
            obstacle2Position = new Vector3(0, obstacle2YPosition, obstacle1.transform.position.z - ZPosOffset);
            obstacleEndPoint.transform.position = new Vector3(obstacleEndPoint.transform.position.x, obstacleEndPoint.transform.position.y, obstacle1.transform.position.z);
        }
        else //�ndeyse
        {
            obstacle2Position = new Vector3(0, obstacle2YPosition, obstacle1.transform.position.z + ZPosOffset);
            obstacleEndPoint.transform.position = new Vector3(obstacleEndPoint.transform.position.x, obstacleEndPoint.transform.position.y, obstacle2Position.z);
        }

        obstacle2.transform.position = obstacle2Position;
    }

    void SetObstacle1Color() //obstacle1'in rengini belirledi�imiz fonksiyon. 
    {
        int randomIndex = Random.Range(0, colorPalette.Length);

        obstacle1Color = colorPalette[randomIndex];

        while (obstacle1Color == playerColor)
        {
            randomIndex = Random.Range(0, colorPalette.Length);
            obstacle1Color = colorPalette[randomIndex];
        }

        obstacle1.GetComponent<Renderer>().material.color = obstacle1Color;

        //obstacle1PropertyBlock.SetColor("_MainColor", obstacle1Color);
        //obstacle1Renderer.SetPropertyBlock(obstacle1PropertyBlock);


    }

    void SetObstacle2Color() //obstacle2'nin rengini belirledi�imiz fonksiyon. 
    {
        int randomIndex = Random.Range(0, colorPalette.Length);

        obstacle2Color = colorPalette[randomIndex];

        while (obstacle2Color == playerColor || obstacle2Color == obstacle1Color)
        {
            randomIndex = Random.Range(0, colorPalette.Length);
            obstacle2Color = colorPalette[randomIndex];
        }

        obstacle2.GetComponent<Renderer>().material.color = obstacle2Color;

        //obstacle2PropertyBlock.SetColor("_MainColor", obstacle2Color);
        //obstacle2Renderer.SetPropertyBlock(obstacle2PropertyBlock);
    }

    
}
