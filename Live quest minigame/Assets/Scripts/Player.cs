using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //creating a header before some public varaibles, good for ordering
    [Header("Refs")]
    public CameraFollower cam;
    public Rigidbody ball;
    public Animator animator;

    [Header("Player Settings")]
    public float turnDuration = 120;
    public float maxForce = 5;
    public float IncrementPerSecond = 0.5f;
    public float AnimationDuration = 0;

    [Header("Read Only")]
    public float currForce;
    public int hits;
    public float turnDurationLeft;

    private bool _charging;
    private bool _canPlay = false;
    private bool _isShooting;
    private float _delayUntilShoot;
    private bool _isPlaying = true;
    // Start is called before the first frame update
    void Start()
    {
        //making the player position at the ball
        //reseting the player for start game
        _isPlaying = true;
        _charging = false;
        _isShooting = false;
        hits = 0;
        PlayerCanPlay();
    }

    // Update is called once per frame
    void Update()
    {
        //when not playing dont update (only happens at the end of game)
        if (!_isPlaying) return;

        //check if the player can hit (when the ball is not moving)
        if (_canPlay)
        {
            //rotate the camera view (according to the input)
            RotateView();

            //get mouse left button down
            //input is a unity class that deals with the input, so mouse bottun down is for the left mouse button only when it's down (changing from up to down)
            if (Input.GetMouseButtonDown(0))
            {
                //zeroing the force
                currForce = 0;
                //start charging
                _charging = true;
            }
            //if player released the button, shoot
            else if (Input.GetMouseButtonUp(0))
            {
                TriggerShoot();
            }

            //as long its charging increase the force of the push
            if (_charging)
            {
                currForce += IncrementPerSecond * Time.deltaTime;
                //if force at the max, shoot!
                if (currForce > maxForce)
                {
                    currForce = maxForce;
                    TriggerShoot();
                }
            }

            //count the turn duration, if the turn has ended shoot at random
            turnDurationLeft -= Time.deltaTime;
            if(turnDurationLeft <= 0)
            {
                currForce = Random.Range(0, maxForce);
                TriggerShoot();
            }
        }
        //when the ball is moving and the player can't play
        else
        {
            //if not in shooting mode waut for the ball to stop
            if (!_isShooting)
            {
                if(ball.angularVelocity == Vector3.zero && ball.velocity == Vector3.zero)
                {
                    //make the player able to play
                    PlayerCanPlay();
                }
            }
        }
        //delay function for shoot (for animation if has any)
        WaitToShoot();
    }

    /// <summary>
    /// Shoot function, trigger animation for shoot so and wait delay to set the force
    /// </summary>
    private void TriggerShoot()
    {
        //if there is animator trigger the shoot animation
        if (animator)
            animator.SetTrigger("shoot");

        //add a hit to count
        hits++;
        //stop charging and don't allow the player to play
        _charging = false;
        _canPlay = false;
        
        
        Debug.Log("shoot!");
        //go for "shooting" mode
        _isShooting = true;
        _delayUntilShoot = AnimationDuration;
    }

    /// <summary>
    /// Wait the set delay and then push the ball (shoot)
    /// </summary>
    private void WaitToShoot()
    {
        if (!_isShooting) return;
        _delayUntilShoot -= Time.deltaTime;
        if(_delayUntilShoot <= 0)
        {
            //shoot the ball in the camera direction
            Vector3 dir = cam.offset.normalized;
            dir.y = 0;
            ball.velocity = dir * currForce;
            _isShooting = false;
        }
    }

    /// <summary>
    /// Rotate player view to aim
    /// </summary>
    private void RotateView()
    {
        //get the left and right arrow keys axis (-1 to 1) and swap it
        float rotation = Input.GetAxis("Horizontal") * -1;
        if (rotation != 0)
        {
            //rotate player
            transform.Rotate(Vector3.up * rotation);
            //rotate camera if get an input
            cam.Rotate(rotation);
        }
    }

    //bonus
    //add a winning animation
    public void OnCompleted()
    {
        //focus on player after ball is in hole
        cam.FocusOn(transform);
        //stops playing
        _isPlaying = false;
        //can play win animation

    }

    /// <summary>
    /// Make the player able to play
    /// </summary>
    private void PlayerCanPlay()
    {
        Debug.Log("can play");
        _canPlay = true;
        turnDurationLeft = turnDuration;
        transform.position = ball.transform.position;
        currForce = 0;
    }
}
