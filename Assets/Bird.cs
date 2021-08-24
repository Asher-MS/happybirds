using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    [SerializeField] private float _launchPower=500;
    private bool _birdwasLaunched;

    private void Awake()
    {
        _initialPosition = transform.position;

    }
    private void Update()
    {   
        if(_birdwasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude<=0.1)
        {
            _timeSittingAround += Time.deltaTime;

        }
        if (transform.position.y > 5 || transform.position.y<-5 || transform.position.x>8.5 || transform.position.y<-8.5    )
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }



    }

    public void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    
    public void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition*_launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdwasLaunched = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        transform.position =new Vector3(newPosition.x,newPosition.y);
    }
    
}
