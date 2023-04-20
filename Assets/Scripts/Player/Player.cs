using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] audioClips;

    private void OnEnable()
    {
        HealtManager.decrementHealt += decrementHealtSound;
    }

    private void OnDisable()
    {
        HealtManager.decrementHealt -= decrementHealtSound;
    }

    private void decrementHealtSound()
    {
        audioSource.Play();
    }
}
