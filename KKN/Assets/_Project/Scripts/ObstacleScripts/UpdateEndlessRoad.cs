using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEndlessRoad : MonoBehaviour
{
    
    private GameObject parentRoad; //Alt ve üst yolun parenti. Tüm yolun baðlý olduðu parent obje.


    private void Start()
    {
        AssignRoadVariables();




    }

    void AssignRoadVariables() //Yolla ilgili deðiþkenlerin deðerlerini sahneden bularak atadýðýmýz fonksiyon.
    {
        parentRoad = GameObject.FindGameObjectWithTag("ParentRoad");

        

        //Yol için kullanacaðýmýz Road adlý scriptte yol açýlýr açýlmaz engeller yerini ve sayýsýný otomatik ayarlayacak.

        //Yolun konumunun güncellenmesi ve açýlmasý iþlemleri de burada gerçekleþecek.
    }




}
