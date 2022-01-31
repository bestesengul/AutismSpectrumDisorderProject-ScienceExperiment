using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karistirma : MonoBehaviour
{
    
    public float tekrarAraligi = 1f;
    public float m_thrust = 10f;
    public int tekrar = 10;
    public GameObject Suzgec;

    private GameObject[] taneler;
    private Bounds suzgecBounds;
    private Vector3 pos;

    private float minX = 0, maxX = 0, minY = 0, maxY = 0, minZ = 0, maxZ = 0;
    private float offsetX = 0, offsetY = 0, offsetZ = 0;
    //private float zamanSayac = 10f;
    private float zamanSayaci = 0f , a;
    private int j = 0;
    private bool touch = false;

    
    void Start()
    {

        #region Tanenin karistirilabilecegi sinirlar tanimlanir
        pos = Suzgec.transform.position;
        suzgecBounds = Suzgec.GetComponent<Collider>().bounds;

        offsetX = suzgecBounds.extents.x / 2 - 0.002f;
        offsetY = suzgecBounds.extents.y / 2 - 0.007f;
        offsetZ = suzgecBounds.extents.z / 2 - 0.005f;

        minX = pos.x - offsetX;
        maxX = pos.x + offsetX;
        minY = pos.y - offsetY;
        maxY = pos.y + offsetY;
        minZ = pos.z - offsetZ;
        maxZ = pos.z + offsetZ;
        #endregion
      
    }

    void Update()
    {
        zamanSayaci -= Time.deltaTime;

        if (zamanSayaci < 0 && j < tekrar && touch == true)
        {
            j++;
            zamanSayaci = tekrarAraligi;
            taneler = GameObject.FindGameObjectsWithTag("bakliyat");
            
            #region Her tanecige konumuna gore uygulancak kuvvet belirlenir ve uygulanir
            foreach (var tane in taneler)
            {    
                a = tane.transform.position.x - Suzgec.transform.position.x;             
                if (a >= 0)
                {
                    tane.GetComponent<Rigidbody>().AddForce(-1 * transform.right * m_thrust);
                    tane.GetComponent<Rigidbody>().AddForce(-1 * new Vector3(0, 0, 1) * m_thrust);
                }
                else
                {
                    tane.GetComponent<Rigidbody>().AddForce(transform.right * m_thrust);
                    tane.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * m_thrust);
                }                
            }
        }
            #endregion

        if (tekrar == j)
        {
            touch = false;
            j = 0;
        }
    }

    public void Calistir()
    {
        touch = true;
    }
}
