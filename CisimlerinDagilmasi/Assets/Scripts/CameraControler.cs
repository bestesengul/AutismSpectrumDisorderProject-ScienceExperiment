using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Animation animasyon1;
    public float kamerazamanlama = 5;
    // Start is called before the first frame update
    void Start()
    {
        animasyon1 = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        animasyon1.Play("bezelye");

    }
}
    
   
