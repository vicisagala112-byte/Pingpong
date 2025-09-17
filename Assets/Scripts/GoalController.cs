using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] private bool isLeftGoal;   // centang kalau ini gawang kiri (belakang Player 1)
    [SerializeField] private BallController ball;
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (isLeftGoal)
            {
                // Bola masuk gawang kiri (Player 1 tidak nangkap) → Player 2 (bot) dapat skor
                gameManager.UserRightScored();
            }
            else
            {
                // Bola masuk gawang kanan (Bot tidak nangkap) → Player 1 dapat skor
                gameManager.UserLeftScored();
            }

            ball.LaunchBall();
        }
    }
}
