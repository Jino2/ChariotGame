using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed;
    private Rigidbody targetRb;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // targetRb.AddForce(Vector3.up * 9.81f, ForceMode.Force);
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