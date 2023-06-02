using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] Animator animator;
    private /*Array*/ List<bool> _canMove = new List<bool>();
    private bool direction = false;
    [HideInInspector] public bool isHurted = false;
    [SerializeField] public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        _canMove.Add(true);
        _canMove.Add(true);
        _canMove.Add(true);
        _canMove.Add(true);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        if (horizontalInput > 0 )
        {
            direction = false;
            if (_canMove[0] == false)
                horizontalInput = 0;
        }
        if (horizontalInput < 0 )
        {
            direction = true;
            if (_canMove[1] == false)
                horizontalInput = 0;
        }
        if (verticalInput > 0 && _canMove[2] == false)
        {
            verticalInput = 0;
        }
        if (verticalInput < 0 && _canMove[3] == false)
        {
            verticalInput = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("IsAttacking", true);
        }
        if (isHurted == true)
        {
            animator.SetBool("IHurted", true);
            isHurted = false;
        }
        gameObject.GetComponent<SpriteRenderer>().flipX = direction;
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
    }

    public void unMove(int direction)
    {
        Debug.Log("unMove called" + direction);
        _canMove[direction] = false;
    }

    public void Move(int direction)
    {
        Debug.Log("Move called" + direction);
        _canMove[direction] = true;
    }

    //on touch other component
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision detected");
        //direction: up = 0, down = 1, left = 2, right = 3
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall detected");
            if (other.gameObject.name == "NORTH")
            {
                Debug.Log("Wall above");
                unMove(0);
            }
            if (other.gameObject.name == "SOUTH")
            {
                Debug.Log("Wall below");
                unMove(1);
            }
            if (other.gameObject.name == "WEST")
            {
                Debug.Log("Wall left");
                unMove(2);
            }
            if (other.gameObject.name == "EAST")
            {
                Debug.Log("Wall right");
                unMove(3);
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        Debug.Log("Collision detected");
        //direction: up = 0, down = 1, left = 2, right = 3
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall detected");
            if (other.gameObject.name == "NORTH")
            {
                Debug.Log("Wall above");
                Move(0);
            }
            if (other.gameObject.name == "SOUTH")
            {
                Debug.Log("Wall below");
                Move(1);
            }
            if (other.gameObject.name == "WEST")
            {
                Debug.Log("Wall left");
                Move(2);
            }
            if (other.gameObject.name == "EAST")
            {
                Debug.Log("Wall right");
                Move(3);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player health: " + health);
        isHurted = true;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Application.Quit();
        }
    }
}
