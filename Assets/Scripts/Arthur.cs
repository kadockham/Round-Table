using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arthur : MonoBehaviour
{
	private Rigidbody2D arthur2D;
    public LayerMask GroundLayers;
    private Transform a_GroundCheck1, a_GroundCheck2;

	private float faceDirectionX;
	public float moveDirectionX;

    [SerializeField]private float minWalkSpeedX = .25f;
    [SerializeField]private float walkAccX = .25f;
    private float curSpeedX;
    [SerializeField]private float maxWalkSpeedX = 5.5f;
    [SerializeField]private float releaseDecelerationX = .25f;
    //[SerializeField]private float skidDecelerationX = .5f;
    [SerializeField]private float skidTurnaroundX = 3.5f;

    //[SerializeField] private float jumpSpeedY = 3.5f;

    [SerializeField]private bool isGrounded;
    [SerializeField]private bool isJumping;
    [SerializeField]private bool jumpButtonHeld;
    //private bool JumpButtonReleased;
    private bool isChangingDirection;
	
    // Start is called before the first frame update
    void Start()
    {
        a_GroundCheck1 = transform.Find("Ground Check 1");
        a_GroundCheck2 = transform.Find("Ground Check 2");
        arthur2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        //Horizontal movement and facing
        if (faceDirectionX != 0)
        {
            if (curSpeedX == 0)
            {
                curSpeedX = minWalkSpeedX;
            } else if (curSpeedX < maxWalkSpeedX)
            {
                curSpeedX = IncreaseWithinBound(curSpeedX, walkAccX, maxWalkSpeedX);
            }
        } else if ( curSpeedX > 0)
        {
            curSpeedX = DecreaseWithinBound(curSpeedX, releaseDecelerationX);
            Debug.Log(curSpeedX);
        }
        
        isChangingDirection = ((curSpeedX > 0) && ((faceDirectionX * moveDirectionX) < 0));
       
        if (isChangingDirection)
        {
            if (curSpeedX > skidTurnaroundX)
            {
                moveDirectionX = -faceDirectionX;
            }
        } else
        {
            if (curSpeedX < skidTurnaroundX)
            {
                moveDirectionX = faceDirectionX;
            }
        }

        arthur2D.velocity = new Vector2(moveDirectionX * curSpeedX, arthur2D.velocity.y);

        if (faceDirectionX > 0)
        {
            transform.localScale = new Vector2(1, 1);
            
        }
        else if (faceDirectionX < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (isGrounded && !isJumping && jumpButtonHeld)
        {
            arthur2D.velocity = new Vector2(arthur2D.velocity.x, 10);
            isJumping = true;
        } else if (isGrounded && isJumping)
        {
            isJumping = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        faceDirectionX = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapPoint(a_GroundCheck1.position, GroundLayers) || Physics2D.OverlapPoint(a_GroundCheck2.position, GroundLayers);
        jumpButtonHeld = (Input.GetAxisRaw("Vertical") > 0) ? true : false;
        //jumpButtonReleased = (Input.GetAxisRaw("Vertical") <= 0 && !jumpButtonReleased) ? false : true;
    }

    float IncreaseWithinBound(float val, float delta, float maxVal)
    {
        val += delta;
        if (val > maxVal)
        {
            val = maxVal;
        }

        return val;
    }

    float DecreaseWithinBound(float val, float delta, float minVal = 0)
    {
        val -= delta;
        if (val < minVal)
        {
            val = minVal;
        }
        return val;
    }

}
