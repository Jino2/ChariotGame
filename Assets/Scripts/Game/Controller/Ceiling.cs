using UnityEngine;

namespace Game.Controller
{
    public class Ceiling : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"tag: {other.tag}");
            if (other.CompareTag("Target"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
