using UnityEngine;

namespace Game.Controller
{
    public class CameraController : MonoBehaviour
    {
        public GameObject user;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = user.transform.position;
            transform.rotation = user.transform.rotation;
        }
    }
}