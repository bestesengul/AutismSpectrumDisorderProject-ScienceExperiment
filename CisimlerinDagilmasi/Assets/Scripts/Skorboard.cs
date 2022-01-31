using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skorboard : MonoBehaviour
{
    public Sprite[] cicekarray;

    // Update is called once per frame
    void Update()
    {
        switch (PopUpController.score)
        {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[0];
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[1];
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[2];
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[3];
                break;           
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[4];
                break;
            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[5];
                break;
            case 6:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[6];
                break;
            case 7:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[7];
                break;
            case 8:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[8];
                break;
            case 9:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[9];
                break;
            case 10:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[10];
                break;
            case 11:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cicekarray[11];
                PopUpController.score = 0;
                break;

        }
    }
}
