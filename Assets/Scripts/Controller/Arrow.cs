using Controller;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 50f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * speed));
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;
        if (other.CompareTag("Target"))
        {
            
            gameManager.AddScore(1);
            gameManager.AddTime(5.0f);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Balloon"))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}