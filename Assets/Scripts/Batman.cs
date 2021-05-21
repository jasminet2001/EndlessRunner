using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Batman : MonoBehaviour
{
    bool alive = true;

    float horizontalInput;
    public Rigidbody rb;

    public float Speed;
    public Animator animator;

    //why doesn't it work?
    //[SerializeField] float horizontalMultiplier = 30;

    private void FixedUpdate()
    {
        if (!alive) return;

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("jump", true);
            this.GetComponent<Rigidbody>().AddForce(0f, 25f, 0f);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        Vector3 forwardMove = transform.forward * Speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * Speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (15 < transform.position.x)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    public void Die()
    {
        alive = false;
        //restart the game
        Invoke("Restart", 2f);
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            animator.SetBool("death", true);
        }
    }
}
