using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpPower = 10;
    bool isJump;
    public Rigidbody rigid;
    public int itemCount;
    public int TotalItemCount;
    public int thisLevel;
    AudioSource audioSource;
    public AudioClip audio1;
    public AudioClip audio2;
    public float Speed = 10.0f;
    
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
        Vector3 move = new Vector3(h, 0, v);
    }

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    { 
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            audioSource.clip = audio2;
            audioSource.Play();
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            audioSource.clip = audio1;
            audioSource.Play();
            itemCount++;
            other.gameObject.SetActive(false);
        }

        if(other.tag == "Manager")
        {
            SceneManager.LoadScene("Scene1-1");
        }

        else if(other.tag == "Flag")
        {
            if(TotalItemCount == itemCount)
            {
                SceneManager.LoadScene("Scene1-" + (thisLevel+1).ToString());
            }
            else
            {
                SceneManager.LoadScene("Scene1-1");
            }
        }
    }
}
