using UnityEngine;

public class Playermoviment : MonoBehaviour
{
[SerializeField] private float moveSpeed = 1f;
private PlayerControl playerControls;
private Vector2 moviment;
private Rigidbody2D rb;
private Animator myAnimator;
private void Awake()
{
    playerControls = new PlayerControl();
    rb = GetComponent<Rigidbody2D>();
    myAnimator = GetComponent<Animator>();
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

}
