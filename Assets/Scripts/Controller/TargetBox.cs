using Manager;
using UnityEngine;

namespace Controller
{
    public class TargetBox : MonoBehaviour
    {
        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameManager.GetInstance();
        }
    
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameManager.AddScore(3);
                gameManager.AddTime(5.0f);
                Destroy(gameObject);
            }

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
}