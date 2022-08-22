using UnityEngine;
using UnityEngine.UI;
using playerMovement;

public class HealthController: MonoBehaviour
{
    public PlayerController playerController;
    public Image[] livesCount;
    private int livesRemaining = 3;

    public void LoseLife()
    {
        if (livesRemaining > 0)
        {
            livesCount[--livesRemaining].enabled = false;
            SoundManager.Instance.Play(Sounds.EnemyCollision);

            if (livesRemaining == 0)
            {
                Debug.Log("You Lost");
                playerController.KillPlayer();                
            }
        }
    }
}


