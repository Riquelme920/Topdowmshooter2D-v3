using UnityEngine;

public class Playermoviment : MonoBehaviour
{
[SerializeField] private float moveSpeed = 1f;
private PlayerControl playerControls;
private Vector2 moviment;
private Rigidbody2D rb;
private Animator myAnimator;
private SpriteRenderer mySpriteRenderer;
private void Awake()
{
    playerControls = new PlayerControl();
    rb = GetComponent<Rigidbody2D>();
    myAnimator = GetComponent<Animator>();
    mySpriteRenderer = GetComponent<SpriteRenderer>();
}
private void OnEnable()
{
    playerControls.Enable();
}
    void Start()
    {
        
    }

    void Update()
    {
        AdjustPlayerfacingDirection();
        PlayerImput();
    }
    private void PlayerImput(){
        moviment = playerControls.Moviment.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", moviment.x);
        myAnimator.SetFloat("moveY", moviment.y);
        }
        private void FixedUpdate()
        {
            move();
        }

        private void move()
        {
            rb.MovePosition(rb.position + moviment * (moveSpeed * Time.fixedDeltaTime));
        }

        private void AdjustPlayerfacingDirection()
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 playerScreemPoint = Camera.main.WorldToScreenPoint(transform.position);
            if (mousePos.x < playerScreemPoint.x)
            {
                mySpriteRenderer.flipX = true;
            }
            else
            {
               mySpriteRenderer.flipX = false;
            }
        }

}
