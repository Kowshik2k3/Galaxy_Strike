
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private float hitPoints = 10f;
    [SerializeField] private int destroyScore = 100;
    [SerializeField] private int hitScore = 10;
    [SerializeField] private ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        ProcessHit();
        scoreBoard.AddScore(hitScore);
    }

    private void ProcessHit()
    {
        if (hitPoints <= 0)
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);

            PlayableDirector director = GetComponent<PlayableDirector>();
            if (director != null) director.Stop();

            Animator animator = GetComponent<Animator>();
            if (animator != null) animator.enabled = false;

            foreach (var mr in GetComponentsInChildren<MeshRenderer>())
                mr.enabled = false;

            Destroy(gameObject);

            scoreBoard.AddScore(destroyScore);
        }
    }
}

/*here is the explanation of the code:
the abouve code defines an Enemy class in Unity that handles enemy behavior,
including hit points, score management, and visual effects upon destruction.
It uses particle collision to detect hits, updates the score, and manages the enemy's destruction with visual effects and animations.
The code also ensures that the enemy's components are properly disabled before destruction to prevent further interactions.
The ScoreBoard is used to keep track of the player's score throughout the game.*/