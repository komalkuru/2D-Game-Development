using UnityEngine;
using Assests.Scripts.Level;

public class LevelCompleteController : MonoBehaviour
{
    [SerializeField] GameCompleteMenuController gameCompleteMenuController;
    [SerializeField] ParticleController playerWin;

    void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.CompareTag("Player")) 
        {         
            Debug.Log("Level finished by the player");
            playerWin.PlayWinEffect();
            SoundManager.Instance.Play(Sounds.LevelWin);
            LevelManager.Instance.MarkCurrentLevelComplete();
            gameCompleteMenuController.Invoke("LevelComplete", 3f);
            //gameCompleteMenuController.LevelComplete();
        }
    }
}
