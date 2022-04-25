using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAim : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance=200f;
    [SerializeField] public Texture aim; 
    private void OnGUI()
    {
        //var world = transform.TransformPoint(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1000f));
        //Debug.DrawLine(transform.position, world);
        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(world);
        //var width = Camera.main.pixelWidth;
        //var height = Camera.main.pixelHeight;
        //GUI.DrawTexture(new Rect(new Vector2(screenPosition.x-25f,height-screenPosition.y+25f),new Vector2(50f,50f)),aim);
    }
}
