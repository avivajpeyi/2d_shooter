using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform;
    [Range(1.0f, 5.0f)]
    public float speed = 2.5f;


    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {

            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);
            
            transform.position = Vector2.Lerp(
                transform.position, new Vector2( clampedX, clampedY), 
                speed);
        }

        
    }
}
