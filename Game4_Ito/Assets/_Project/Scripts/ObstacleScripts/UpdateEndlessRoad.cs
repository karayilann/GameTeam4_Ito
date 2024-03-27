using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEndlessRoad : MonoBehaviour
{
    
    private GameObject parentRoad1; //Alt ve üst yolun parenti. Tüm yolun baðlý olduðu parent obje.
    private GameObject parentRoad2; //Alt ve üst yolun parenti. Tüm yolun baðlý olduðu parent obje.
    [SerializeField] private float roadLength;

    


    private void Start()
    {
        AssignRoadVariables();




    }

    void AssignRoadVariables() //Yolla ilgili deðiþkenlerin deðerlerini sahneden bularak atadýðýmýz fonksiyon.
    {
        parentRoad1 = GameObject.FindGameObjectWithTag("ParentRoad1");

        

        //Yol için kullanacaðýmýz Road adlý scriptte yol açýlýr açýlmaz engeller yerini ve sayýsýný otomatik ayarlayacak.

        //Yolun konumunun güncellenmesi ve açýlmasý iþlemleri de burada gerçekleþecek.
    }




}
