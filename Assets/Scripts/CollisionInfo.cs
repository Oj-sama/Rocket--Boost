using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionInfo : MonoBehaviour
{
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip levelWon;
    [SerializeField] ParticleSystem won;
    [SerializeField] ParticleSystem death;
    bool check = false;
    bool toggle = false;
    AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            toggle = !toggle;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (check || toggle) { return; }
        switch (other.gameObject.tag)
        {
            case "friend":
                {
                    audioSource.Stop();
                }
                break;
            case "OB":
                {
                    CrashHandler();
                }
                break;
            case "finish":
                {
                    LevelCompleted();
                }
                break;
            default:

                break;

        }
    }
    void CrashHandler()
    {
        check = true;
        GetComponent<Movement>().enabled = false;
        death.Play();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(deathSound);
        }
        else
        {
            audioSource.Stop();
            audioSource.PlayOneShot(deathSound);
        }



        Invoke("ReloadLevel", 3);
        Debug.Log("u died");
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void LoadNextLevel()
    {
        int buildIndexNumber = SceneManager.GetActiveScene().buildIndex;
        int NextLevelIndex = buildIndexNumber + 1;
        if (NextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextLevelIndex = 0;
        }
        SceneManager.LoadScene(NextLevelIndex);

    }
    void LevelCompleted()
    {
        check = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1.5f);
        won.Play();
        Debug.Log("u made it");
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(levelWon);
        }
        else
        {
            audioSource.Stop();
            audioSource.PlayOneShot(levelWon);
        }
    }
}
