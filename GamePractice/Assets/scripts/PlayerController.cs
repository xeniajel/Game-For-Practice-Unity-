using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 VectorToRight = new Vector2(1, 0);
    private Vector2 VectorToLeft = new Vector2(-1, 0);
    public string CurrentAnimation = "idle girl";

    public bool OnGround = false;
    public float MoveSpeed = 1;
    
    public Rigidbody2D PlayerRigidbody2D;
    public SpriteRenderer PlayerSpriteRenderer;
    public Animator PlayerAnimator;
    void Update()
    {
        if (Input.GetKey("d"))
        {
            PlayerMoving(VectorToRight);
            RotatePlayer(false);
        }
        else if (Input.GetKey("a"))
        {
            PlayerMoving(VectorToLeft);
            RotatePlayer(true);
        }
        else
        {
            AnimationStop();
        }
    }

    void PlayerMoving(Vector2 MoveVector)
    {
        Vector2 NewMoveVector = new Vector2(MoveVector.x * MoveSpeed, PlayerRigidbody2D.linearVelocity.y);
        PlayerRigidbody2D.linearVelocity = NewMoveVector;

        if (OnGround == true)
        {
            PlayingAnimation("walk girl");
        }
    }
    void RotatePlayer(bool Bool_Value)
    {
        PlayerSpriteRenderer.flipX = Bool_Value;
    }

    void AnimationStop()
    {
        if (OnGround == true)
        {
            PlayingAnimation("idle girl");
        }
    }

    void PlayingAnimation(string AnimationName)
    {
        if (CurrentAnimation != AnimationName)
        {
            CurrentAnimation = AnimationName;
            PlayerAnimator.Play(CurrentAnimation);
        }
    }
}
