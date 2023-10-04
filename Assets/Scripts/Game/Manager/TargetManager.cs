using UnityEngine;

namespace Game.Manager
{
    public class TargetManager : MonoBehaviour
    {
        public GameObject targetPrefab;
        public GameObject user;

        private float runningTime;
        private float TimeLimit = 5f;


        // Start is called before the first frame update
        void Start()
        {
            runningTime = Time.fixedTime;
        }

        // Update is called once per frame
        void Update()
        {
            CreateTargetAfterTimeLimit();
        }

        private void CreateTargetAfterTimeLimit()
        {
            var time = Time.fixedTime;
            if (time - runningTime > TimeLimit)
            {
                runningTime = time;
                CreateTarget();
            }
        }

        private void CreateTarget()
        {
            Instantiate(targetPrefab, GetRandomPosition(), targetPrefab.transform.rotation);
        }

        private Vector3 GetRandomPosition()
        {
            var userPosition = user.transform.position;
            return new Vector3(Random.Range(userPosition.x - 40f, userPosition.x + 40f),
                0,
                Random.Range(userPosition.z - 40f, userPosition.z + 40f)
            );
        }
    }
}