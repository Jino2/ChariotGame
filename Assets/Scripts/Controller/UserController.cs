using System;
using Controller;
using UnityEngine;
using static UnityEngine.Screen;

public class UserController : MonoBehaviour
{
    public GameObject chariot;
    public GameObject arrowPrefab;
    public float shootDistance;
    private Rigidbody userRb;
    private GameManager _gameManager;

    // public Texture2D cursorTexture;
    // public CursorMode cursorMode = CursorMode.Auto;
    // public Vector2 hotSpot = Vector2.zero;
    //
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.GetInstance();
        userRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager.isGameOver) return;
        RotateByChariot();
        ShootArrow();
    }

    private void RotateByChariot()
    {
        transform.position = chariot.transform.position + new Vector3(0f, 3f, 0f);
        transform.rotation = chariot.transform.rotation;
    }

    private void ShootArrow()
    {
        var mouseLeftButtonClicked = Input.GetMouseButtonDown(0);
        var mouseX = Input.mousePosition.x;
        var mouseY = Input.mousePosition.y;

        if (mouseLeftButtonClicked)
        {
            var dx = mouseX - (float)width / 2;
            var dy = mouseY - (float)height / 2;

            var thetaY = Mathf.Atan2(dx, shootDistance) / Math.PI * 180;
            var thetaX = Mathf.Atan2(dy, shootDistance) / Math.PI * -180;
            var eulerAnger = transform.rotation.eulerAngles;
            eulerAnger.z += (float)thetaX;
            eulerAnger.y += (float)thetaY + 90;
            Instantiate(arrowPrefab, transform.position, Quaternion.Euler(eulerAnger));
        }
    }
}