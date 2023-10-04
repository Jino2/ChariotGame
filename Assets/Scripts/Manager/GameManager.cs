using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controller
{
    public class GameManager : MonoBehaviour
    {
        private GameManager()
        {
        }

        public bool isGameOver = false;
        public TMP_Text finishText;
        public TMP_Text remainTimeText;
        public GameObject menuGroupPanel;
        public Slider angerSlider;
        public Slider tiredSlider;

        private static GameManager _instance;
        private TextMeshProUGUI scoreText;
        private int score;
        private float timer = 60.0f;
        private int angerPoint;
        private int slothPoint;
        private AudioSource scoringAudio;

        public static GameManager GetInstance()
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }

            return _instance;
        }

        private void Start()
        {
            score = 0;
            scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            angerSlider = GameObject.Find("AngerSlider").GetComponent<Slider>();
            tiredSlider = GameObject.Find("TiredSlider").GetComponent<Slider>();
            scoringAudio = GetComponent<AudioSource>();
        }

        private void Update()
        {
            scoreText.text = score.ToString();
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                timer = 0.0f;
                GameOver();
            }

            angerSlider.value = angerPoint;
            tiredSlider.value = slothPoint;
            
            remainTimeText.text = timer.ToString("F1");
        }

        public void AddScore(int scoreToAdd)
        {
            scoringAudio.Play();
            this.score += scoreToAdd;
        }


        private void GameOver()
        {
            isGameOver = true;
            menuGroupPanel.SetActive(isGameOver);
        }

        public void AddTime(float time)
        {
            timer += time;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void SetAngerPoint(int point)
        {
            angerPoint = point;
        }

        public void SetSlothPoint(int point)
        {
            slothPoint = point;
        }
        
    }
}