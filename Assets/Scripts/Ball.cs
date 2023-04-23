using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private bool isPressed = false;
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public GameObject nextBall;

    
    void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > 2)
            {
                rb.position = hook.position + (mousePos - hook.position).normalized * 2;
            }
            else 
            {
                rb.position = mousePos;
            }
            
        }
    }

    public void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    public void OnMouseUp()
    {
        isPressed =false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        if (nextBall != null )
        {
            nextBall.SetActive(true);
        }
        else
        {
            Debug.Log("Game Over");
            Enemy.EnemiesAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
