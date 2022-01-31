using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dokulme : MonoBehaviour
{
    #region Inspector Varibles
    [SerializeField] GameObject YeniTanelerParent;
    public GameObject sObject;
    public int sSayisi = 100;
    public Vector3 uzaklik; //bosaltilicak cismin olusturulma konumunun objenin merkezine gore uzakligi
    public float speed = .1f; //animasyon hizi
    public float olusturmaSuresi = .08f; // spawn sikligi
    public float bosaltmaSonrasiSure = 1f; //bosaltma bittigi an geri donme animsayonu ne zaman baslasin. ne kadar buyukse o kadar gec
    public GameObject konumCismi; //dokulecek hedef cisim
    public Vector3 hedefUzaklik; // dokulecek hedef cisme gore offset ayarlama
    #endregion

    #region Private Variables
    Vector3 startP;
    Vector3 hedef;
    Quaternion startQ;
    Vector3 positon1;
    Quaternion quaternio1;
    
    float zamanSayaci = 0f;
    int i = 0;
    bool spawner;
    public bool touch = false;
    bool bosaltildi = false;
    #endregion

    void Start()
    {
        #region karistirma oncesi kase konumundan ilk deger atamalari
        hedef = konumCismi.transform.position;
        startP = transform.position;
        startQ = transform.rotation;
        positon1 = startP;
        quaternio1 = startQ;
        #endregion

        spawner = false;
    }

    void FixedUpdate()
    {
        
        zamanSayaci -= Time.deltaTime;
        if (touch == true)
        {
            positon1 = new Vector3(hedef.x + hedefUzaklik.x, hedef.y + hedefUzaklik.y, hedef.z + hedefUzaklik.z);
            quaternio1 = Quaternion.Euler(0, 0, 60);
            spawner = true;
            touch = false;
        }

        transform.position = Vector3.Lerp(transform.position, positon1, speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, quaternio1, speed);

        if (spawner == true && transform.position.x <= hedef.x + hedefUzaklik.x + 0.01f)
        {
            if (zamanSayaci < 0 && i < sSayisi)
            {
                i++;
                zamanSayaci = olusturmaSuresi;
                Instantiate(sObject, transform.position + uzaklik, Quaternion.Euler(0, 0, 0), YeniTanelerParent.transform);  
            }
            else if (i == sSayisi)
            {

                i = 0;
                spawner = false;              
                bosaltildi = true;
            }
        }

        if (zamanSayaci < bosaltmaSonrasiSure * -1 && bosaltildi == true)
        {
            positon1 = startP;
            quaternio1 = startQ;
            bosaltildi = false;
        }

    }

    void OnMouseDown()
    {
        touch = true;
    }

}
