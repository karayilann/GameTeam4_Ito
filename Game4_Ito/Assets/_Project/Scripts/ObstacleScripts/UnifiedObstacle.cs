using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnifiedObstacle : MonoBehaviour
{
    private GameObject obstacle1; //Alttaki engel
    private GameObject obstacle2; //Üstteki engel
    private GameObject activator; //Aktivator (Engellerin ortasýndaki nesne)

    private GameObject road1; //Alttaki yol
    private GameObject road2; //Üstteki yol

    [SerializeField]
    private float obstacleScaleXZ; //Engellerin X ve Z eksenindeki scale deðerlerini bu deðiþkende tutacaðýz.

    [SerializeField]
    private float activatorScale; //Activatorun scale deðerini bu deðiþkende tutacaðýz.

    // ------------------------------------------------------------------

    private int randomObstacleIndex; //Oyuncu rengi ile ayný olacak olan engelin altta mý üstte mi olacaðýný bu deðiþkeni kontrol ederek belirleyeceðiz.

    private Color playerColor = Color.red; //Oyuncunun rengini bu deðiþkende tutuyoruz. Daha sonra deðiþecek.

    private Color[] colorPalette = new[] { Color.yellow, Color.red, Color.blue, Color.green }; //Renk paletini, yani olabilecek renk seçeneklerini bu dizide tutacaðýz.

    private Color obstacle1Color; //Alttaki engelin rengini bu deðiþkende tutacaðýz.
    private Color obstacle2Color; //Üstteki engelin rengini bu deðiþkende tutacaðýz.


    private Renderer obstacle1Renderer;
    private Renderer obstacle2Renderer;
    private MaterialPropertyBlock obstacle1PropertyBlock;
    private MaterialPropertyBlock obstacle2PropertyBlock;

    private void Awake()
    {
        obstacle1 = transform.GetChild(0).gameObject;
        obstacle2 = transform.GetChild(1).gameObject;
        activator = transform.GetChild(2).gameObject;

        road1 = GameObject.FindGameObjectWithTag("Road1");
        road2 = GameObject.FindGameObjectWithTag("Road2");

        obstacle1Renderer = obstacle1.GetComponent<Renderer>();
        obstacle2Renderer = obstacle2.GetComponent<Renderer>();
        obstacle1PropertyBlock = new MaterialPropertyBlock();
        obstacle2PropertyBlock = new MaterialPropertyBlock();
    }

    public void OnEnable()
    {
        SetRandomDifferentObstacle();
        SetObstacle1Color();
        SetObstacle2Color();

        SetActivatorTransform();
        SetObstacle1Transform();
        SetObstacle2Transform();
    }


    private void SetActivatorTransform() //Activator'un pozisyonunu ve scale deðerini bu fonksiyonla ayarlýyoruz.
    {
        activator.transform.localScale = new Vector3(activatorScale, activatorScale, activatorScale);
        activator.transform.position = this.gameObject.transform.position;
    }


    private void SetObstacle1Transform() //Alttaki engelin pozisyonunu ve scale deðerini bu fonksiyonla ayarlýyoruz.
    {

        /*       OBS1
     G = ACT.POS.Y-(ACT.SCL.Y/2)
     K = R1.POS.Y+(R1.SCL.Y/2)
     O1.SCALE => |G - K|
     O1.POS => (G + K)/2
     */

        float activatorPositionY = activator.transform.position.y - (activator.transform.localScale.y / 2);
        float road1PositionY = road1.transform.position.y + (road1.transform.localScale.y / 2);

        float obstacle1ScaleY = Mathf.Abs(activatorPositionY - road1PositionY);
        float obstacle1PositionY = (activatorPositionY + road1PositionY) / 2;

        Vector3 obstacle1Scale = new Vector3(obstacleScaleXZ, obstacle1ScaleY, obstacleScaleXZ);
        Vector3 obstacle1Position = new Vector3(activator.transform.position.x, obstacle1PositionY, activator.transform.position.z);

        obstacle1.transform.position = obstacle1Position;
        obstacle1.transform.localScale = obstacle1Scale;
    }


    private void SetObstacle2Transform() //Üstteki engelin pozisyonunu ve scale deðerini bu fonksiyonla ayarlýyoruz.
    {

        /*      OBS 2
     T = R2.POS.Y-(R2.SCL.Y/2)
     Z = ACT.POS.Y+(ACT.SCL.Y/2)
     O2.SCALE => |T - Z|
     O2.POS => (T + Z)/2
     */

        float road2PositionY = road2.transform.position.y - (road2.transform.localScale.y / 2);
        float activatorPositionY = activator.transform.position.y + (activator.transform.localScale.y / 2);

        float obstacle2ScaleY = Mathf.Abs(road2PositionY - activatorPositionY);
        float obstacle2PositionY = (road2PositionY + activatorPositionY) / 2;

        Vector3 obstacle2Scale = new Vector3(obstacleScaleXZ, obstacle2ScaleY, obstacleScaleXZ);
        Vector3 obstacle2Position = new Vector3(activator.transform.position.x, obstacle2PositionY, activator.transform.position.z);

        obstacle2.transform.position = obstacle2Position;
        obstacle2.transform.localScale = obstacle2Scale;
    }


    private void SetRandomDifferentObstacle() //Oyuncu rengiyle ayný olacak olan engelin alttaki mi üstteki mi olacaðýný kontrol ettiðimiz deðiþkenin deðerini bu fonksiyonla oluþturuyoruz.
    {
        randomObstacleIndex = Random.Range(0, 2);   //0 > obstacle1   ------   1 > obstacle2

    }


    private void SetObstacle1Color() //Alttaki engelin rengini bu fonksiyonla belirliyoruz.
    {
        if (randomObstacleIndex == 0)
        {
            obstacle1Color = playerColor;
        }
        else
        {
            int randomIndex = Random.Range(0, colorPalette.Length);
            obstacle1Color = colorPalette[randomIndex];

            while (obstacle1Color == playerColor)
            {
                randomIndex = Random.Range(0, colorPalette.Length);
                obstacle1Color = colorPalette[randomIndex];
            }
        }

        //obstacle1.GetComponent<Renderer>().material.color = obstacle1Color;

        obstacle1PropertyBlock.SetColor("_MainColor", obstacle1Color);
        obstacle1Renderer.SetPropertyBlock(obstacle1PropertyBlock);
    }

    private void SetObstacle2Color() //Üstteki engelin rengini bu fonksiyonla belirliyoruz.
    {
        if (randomObstacleIndex == 1)
        {
            obstacle2Color = playerColor;
        }
        else
        {
            int randomIndex = Random.Range(0, colorPalette.Length);
            obstacle2Color = colorPalette[randomIndex];

            while (obstacle2Color == playerColor)
            {
                randomIndex = Random.Range(0, colorPalette.Length);
                obstacle2Color = colorPalette[randomIndex];
            }
        }

        //obstacle2.GetComponent<Renderer>().material.color = obstacle2Color;

        obstacle2PropertyBlock.SetColor("_MainColor", obstacle2Color);
        obstacle2Renderer.SetPropertyBlock(obstacle2PropertyBlock);
    }
}
