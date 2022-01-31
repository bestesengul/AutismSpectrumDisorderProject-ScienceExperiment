using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Tenis topunun hareketi icin kullanilmaktadir.

public class DragDrop : MonoBehaviour
{
    #region Variables
    private Vector3 mOffset;
    private float mZcoord;
    public bool isDragging = false;
    #endregion

    #region Unity Functions
    private void OnMouseDown()
    {
        mZcoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mOffset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
        isDragging = true;
    }

    private void OnMouseUp()
    {
        if (this.GetComponent<Rigidbody>())
            this.GetComponent<Rigidbody>().isKinematic = false;
        isDragging = false;
    }
    #endregion

    #region Getting the mouse position 
    private Vector3 GetMouseWorldPos()
    {
        // pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZcoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    #endregion

}
