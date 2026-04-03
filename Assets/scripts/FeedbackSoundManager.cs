using UnityEngine;

public class FeedbackSoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Sound Effects")]
    public AudioClip correctSound;  
    public AudioClip wrongSound;    

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
           
        }
    }

    
    public void PlayCorrectSound()
    {
        if (audioSource != null && correctSound != null)
        {
            audioSource.Stop();  
            audioSource.PlayOneShot(correctSound);
        }
        else
        {
           
        }
    }

    
    public void PlayWrongSound()
    {
        if (audioSource != null && wrongSound != null)
        {
            audioSource.Stop();  
            audioSource.PlayOneShot(wrongSound);
        }
        else
        {
            
        }
    }
}
