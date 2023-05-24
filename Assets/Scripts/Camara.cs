using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public Transform target;

    public Vector2 LimitX;
    public Vector2 LimitY;

    public Vector3 offset;

    public float interpolationRatio;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Mario").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target !=null)
        {
            Vector3 desiredPosition = target.position + offset;

            float clampX = Mathf.Clamp(desiredPosition.x, LimitX.x, LimitX.y);
            float clampY = Mathf.Clamp(desiredPosition.y, LimitY.x, LimitY.y);

            Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);
            Vector3 lerpedPosition = Vector3.Lerp(transform.position, clampedPosition, interpolationRatio);
            transform.position = lerpedPosition;
        }
    }
}
