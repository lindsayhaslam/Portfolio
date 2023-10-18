//using UnityEditor.Timeline.Actions;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    //Array of invaders for spawning
    public Invader[] prefabs;
    //Grid of invaders
    public int rows = 4;
    public int columns = 4;
    //Speed at which invaders descend 
    public AnimationCurve speed;
    //Fireball projectile fired by invaders
    public Projectile missilePrefab;
    public float missileAttackRate = 1.0f;
    //Variables to keep track of the amount of invaders killed
    public int amountKilled { get; private set; }
    public int totalInvaders => this.rows * this.columns;
    public int amountAlive => this.totalInvaders - this.amountKilled;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;
    //Initial position of invader grid
    public Vector3 initialPosition { get; private set; }
    private Vector3 _direction = Vector2.right;

    //Includes for loop to change position of invader prefab
    private void Awake()
    {
        initialPosition = transform.position;

        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector3 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 2.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                invader.killed += InvaderKilled;

                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);
    }

    void Update()
    {
        //Checks that all invaders are destroyed
        bool allInvadersDestroyed = false;
        foreach (Invader prefab in prefabs)
        {
            if (amountAlive == 0)
            {
                allInvadersDestroyed = true;
                break;
            }
        }

        //If all invaders are destroyed, jump to "success" scene
        if (allInvadersDestroyed)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {       
                // If there are no more scenes, you can display a game over screen or perform other actions
                Debug.Log("Game Over");
            }
        }

        //Camera edges for boundaries 
        this.transform.position += _direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            
            // Skip any invaders that have been killed
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            // Check the left edge or right edge based on the current direction
            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1f))
            {
                AdvanceRow();
                break;
            }
            else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1f))
            {
                AdvanceRow();
                break;
            }
        }
    }

    //Method to flip direction and increase the invaders' descent
    private void AdvanceRow()
    {
        // Flip the direction the invaders are moving
        _direction = new Vector3(-_direction.x, 0f, 0f);

        // Move the entire grid of invaders down a row
        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }
    //Instantiates fireball projectile
    private void MissileAttack()
    {
        foreach (Transform invader in transform)
        {

            if (invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (Random.value < (1.0f / (float)this.amountAlive))
            {
                Instantiate(this.missilePrefab, new Vector3(0f,6f,0f), Quaternion.identity);
                break;
            }
        }
    }
    //Method to keep track of amount killed
    public void InvaderKilled()
    {
        this.amountKilled++;
    }
}


