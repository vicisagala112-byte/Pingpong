using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool isUserLeft = true;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 2f;
    [SerializeField] Transform ball;
    [SerializeField] int level = 1;

    [Header("Batas Gerak")]
    [SerializeField] float minY = -3.5f; // batas bawah lapangan
    [SerializeField] float maxY = 3.5f;  // batas atas lapangan

    float direction;

    void Update()
    {
        if (isUserLeft)
        {
#if UNITY_ANDROID || UNITY_IOS
            TouchInput(true);   // Player1 kontrol layar kiri
#else
            UserLeftInput(); // biar di PC masih bisa test
#endif
        }
        else
        {
#if UNITY_ANDROID || UNITY_IOS
            if (level == 2)
                TouchInput(false); // Player2 kontrol layar kanan
            else
                BotInput();
#else
            if (level == 2)
                UserRightInput();
            else
                BotInput();
#endif
        }

        rb.linearVelocity = new Vector2(0, direction) * speed;

        // clamp posisi
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    void TouchInput(bool UserLeft)
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                // ambil posisi sentuhan
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                // tentukan area kontrol
                if (UserLeft && touch.position.x < Screen.width / 2)
                {
                    // area kiri → Player1
                    if (touchPos.y > transform.position.y + 0.2f)
                        direction = 1f;
                    else if (touchPos.y < transform.position.y - 0.2f)
                        direction = -1f;
                    else
                        direction = 0f;
                }
                else if (!UserLeft && touch.position.x > Screen.width / 2)
                {
                    // area kanan → Player2
                    if (touchPos.y > transform.position.y + 0.2f)
                        direction = 1f;
                    else if (touchPos.y < transform.position.y - 0.2f)
                        direction = -1f;
                    else
                        direction = 0f;
                }
            }
        }
        else
        {
            direction = 0f;
        }
    }

    void UserLeftInput()
    {
        if (Input.GetKey(KeyCode.W))
            direction = 1f;
        else if (Input.GetKey(KeyCode.S))
            direction = -1f;
        else
            direction = 0;
    }

    void UserRightInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            direction = 1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction = -1f;
        else
            direction = 0;
    }

    void BotInput()
    {
        if (ball == null) return;

        if (ball.position.y > transform.position.y + 0.2f)
            direction = 1f;
        else if (ball.position.y < transform.position.y - 0.2f)
            direction = -1f;
        else
            direction = 0;
    }
}
