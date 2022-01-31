using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakliyatController : MonoBehaviour
{
    #region Private Variables
    GameObject yeniTane;
    Vector3 pos; // DeepPlate pozisyonu
    Bounds plateBounds;

    private float minX = 0, maxX = 0, minZ = 0, maxZ = 0, offsetX = 0, offsetZ = 0;

    // bir tiklamada kac tane uretildigini tutar
    private int taneSayisi = 0;
    private int nohutTaneSayisi = 30;
    private int bezelyeTaneSayisi = 150;
    private int tenisTopuSayisi = 1;
    private int digerTaneSayisi = 300;

    //public LayerMask m_LayerMask;
    #region not
    // Tabak olculerinin tahmini min-max en ve boy sinirlari (nohut icin)
    // private float minX = -0.04f, maxX = 0.2f;
    // private float minZ = -1.5f, maxZ = -1.4f;
    #endregion
    #endregion

    #region Inspector Variables
    [SerializeField] GameObject bakliyatTanesi;
    [SerializeField] GameObject yeniTanelerParent;
    #endregion

    private void Start()
    {
        #region Yeni tanenin olusturulabilecegi sinirlar tanimlanir
        
        pos = transform.position;
        plateBounds = gameObject.GetComponent<Collider>().bounds;

        offsetX = plateBounds.extents.x / 3 - 0.005f;
        offsetZ = plateBounds.extents.z / 3 - 0.005f;

        minX = pos.x - offsetX;
        maxX = pos.x + offsetX;
        minZ = pos.z - offsetZ;
        maxZ = pos.z + offsetZ;
        #endregion
        
        #region Bakliyata gore uretilecek tane sayisi belirlenir
        
        if (bakliyatTanesi.name == "nohutTanesi") taneSayisi = nohutTaneSayisi;
        else if (bakliyatTanesi.name == "bezelyeTanesi") taneSayisi = bezelyeTaneSayisi;
        else if (bakliyatTanesi.name == "TenisTopu") taneSayisi = tenisTopuSayisi;
        else taneSayisi = digerTaneSayisi;
        #endregion


        #region Tane uretimi
        
        for (int i = 0; i < taneSayisi; i++)
        {
            yeniTane = Instantiate(bakliyatTanesi, new Vector3(Random.Range(minX, maxX), pos.y, Random.Range(minZ, maxZ)), Quaternion.identity, yeniTanelerParent.transform);
            if (!plateBounds.Contains(yeniTane.transform.position))
                Debug.Log("BOOM.");

        }

        #endregion
    }

    #region Tane yerinin kontrolu
    private void Update()
    {
        GameObject[] bakliyatTaneleri = GameObject.FindGameObjectsWithTag("bakliyat");
        if (bakliyatTanesi.GetComponent<Collider>().CompareTag("Ground") || bakliyatTanesi.transform.position.y < -10)
        { 
            Destroy(bakliyatTanesi);
            Debug.Log("Yok oldu.");
        }          
    }


    #endregion


}
