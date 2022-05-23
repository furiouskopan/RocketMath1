using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    bool isTransitioning = false;
    AudioSource audioSource;
    bool disableCollision = false;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip win;

    void Update()
    {
        DebugKeyListener();
    }
    void DebugKeyListener()
    {   
        if(Input.GetKeyDown(KeyCode.Q))
        {
            NextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            disableCollision = !disableCollision;
            Debug.Log("Collision disabled");
        }
    }
    void Start()
    { 
        audioSource = GetComponent<AudioSource>();
    }
    void Respawn()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void StartWinSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(win);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", 1.3f);
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(crash);
        Invoke("Respawn", 1.2f);
    }
   
    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning || disableCollision){ return; }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("+1!");
                break;
            case "Finish":
                Debug.Log("Level finished!");
                StartWinSequence();
                break;
            case "Coin":
                Debug.Log("+1 coin");
                break;
            case "Unfriendly":
                Debug.Log("Ispuka ;(");
                StartCrashSequence();
                break;
            default:
            Debug.Log("nisto ");   
            break;
        }    
    }
}
