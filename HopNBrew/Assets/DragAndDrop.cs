using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Vector3 startingPosition;
    private Vector3 GetMouseWorldPosition()
    {
        // capture mouse position & return WorldPoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    //OnMouseDown is called on the first frame of mouse click
    private void OnMouseDown()
    {
        //Capture the mouse offset
        startingPosition = this.transform.position;
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }
    //OnMouseDrag is called on all the other frames of mouse click
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }
    //OnMouseUp is called on the last frame of mouse click
    private void OnMouseUp()
    {
        transform.position = startingPosition;
    }
}
