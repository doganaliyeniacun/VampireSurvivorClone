using UnityEngine;
using UnityEngine.UI;

public class Healt : MonoBehaviour
{
    public bool healtStatus = true;

    public Texture[] healtImages;

    private RawImage rawImage;

    private void Start()
    {
        rawImage = GetComponent<RawImage>();
    }
    
    private void Update()
    {
        if (healtStatus)
            rawImage.texture = healtImages[0];
        else
            rawImage.texture = healtImages[1];
    }
}
