using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEndlessRoad : MonoBehaviour
{
    
    private GameObject parentRoad; //Alt ve �st yolun parenti. T�m yolun ba�l� oldu�u parent obje.


    private void Start()
    {
        AssignRoadVariables();




    }

    void AssignRoadVariables() //Yolla ilgili de�i�kenlerin de�erlerini sahneden bularak atad���m�z fonksiyon.
    {
        parentRoad = GameObject.FindGameObjectWithTag("ParentRoad");

        

        //Yol i�in kullanaca��m�z Road adl� scriptte yol a��l�r a��lmaz engeller yerini ve say�s�n� otomatik ayarlayacak.

        //Yolun konumunun g�ncellenmesi ve a��lmas� i�lemleri de burada ger�ekle�ecek.
    }




}
