using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
 
    public Projectile laserPrefab;
    //Projectile speed
    public float speed = 5.0f;
    //Track whether player can shoot
    private bool _lazerActive;

    //for flipping the character
    Rigidbody2D rb;
    float inputHorizontal;
    float inputVertical;
    bool facingRight = true;

    //Leave empty for now
    private void Awake()
    {

    }

    public void Update()
    {
        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX) pos.x = minX;
        if (pos.x > maxX) pos.x = maxX;

        // vertical contraint
        if (pos.y < minY) pos.y = minY;
        if (pos.y > maxY) pos.y = maxY;

        // Update position
        transform.position = pos;

        //Determine if player should be flipped (facing left or right)
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        if (inputHorizontal != 0)
        {
            rb.AddForce(new Vector2(inputHorizontal * speed, 0f));
        }
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }

        //Movement with left and right key
        if (Input.GetKey(KeyCode.LeftArrow))
         {
             this.transform.position += Vector3.left * this.speed * Time.deltaTime;
            Flip();
         }
         else if (Input.GetKey(KeyCode.RightArrow))
         {
             this.transform.position += Vector3.right * this.speed * Time.deltaTime;
            Flip();
         }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }
    //Only allow player to shoot heart lazer if previous heart lazer is destroyed
    public void Shoot()
    {
        if (!_lazerActive)
        {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LazerDestroyed;
            _lazerActive = true;
        }
    }
    //To check if lazer is destroyed
    public void LazerDestroyed()
    {
        _lazerActive = false;
    }
    //Collision detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") ||
            other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }

    //Positions of player determined by the camera's view
    private float minX, maxX, minY, maxY;

    void Start()
    {
        // If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;

        //Flipping the priestess
        rb = gameObject.GetComponent<Rigidbody2D>();

        
    }
    //Logic for flipping player imager
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

}
