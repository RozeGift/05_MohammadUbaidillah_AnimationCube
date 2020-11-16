using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    float jumpforce = 5.0f;
    bool move = true;
    bool OnPlane = true;
    int health = 100;

    public Animator playerAnim;
    public Rigidbody playerRb;
    public GameObject healthText;
    // Start is called before the first frame update
    void Start()
    {
        //Needed when playerAnim is declared as private
        //playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.GetComponent<Text>().text = "Health:" + health;

        if (Input.GetKey(KeyCode.W) && move)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("IsMove", true);
        }
      
        if(Input.GetKey(KeyCode.S) && move)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("IsMove", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            
            playerAnim.SetBool("IsMove", false);
        }
        if (Input.GetKey(KeyCode.A) && move)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnim.SetBool("IsMove", true);
        }
        
        if (Input.GetKey(KeyCode.D) && move)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAnim.SetBool("IsMove", true);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
        
            playerAnim.SetBool("IsMove", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && OnPlane && move)
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            playerAnim.SetTrigger("trigflip");
            OnPlane = false;
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            health -= 10;
            if (health == 0)
            {
                playerAnim.SetTrigger("IsDead");
                move = false;
            }
        }

        
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Plane"))
        {
            OnPlane = true;
        }
    }

}
