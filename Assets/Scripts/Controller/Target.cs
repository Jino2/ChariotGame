using System;
using Controller;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject balloon;
    public GameObject targetBox;
    
    private Rigidbody targetBoxRb;
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        targetBoxRb = targetBox.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetBox.IsDestroyed())
        {
            Destroy(gameObject);
            return;
        }
        if(balloon.IsDestroyed()) targetBoxRb.isKinematic = false;
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
        DestroyAtTop();
    }

    private void DestroyAtTop()
    {
        if (transform.position.y > 30.0f)
        {
            Destroy(gameObject);
        }
    }


}