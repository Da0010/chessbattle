using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakeSE : MonoBehaviour
{
    [SerializeField] AudioClip moveClip;
    [SerializeField] AudioClip killedClip;
    [SerializeField] AudioClip checkClip;
    [SerializeField] AudioClip timeOverClip;
    [SerializeField] AudioClip SEVolumeClip;

	[SerializeField] Slider SESlider;
    AudioSource SE;
    // Start is called before the first frame update
    void Start()
    {
        SE = this.GetComponent<AudioSource>();
        SESlider.onValueChanged.AddListener(value => SE.volume = value);
    }

    public void shotSEVolumeSound(){
        SE.PlayOneShot(SEVolumeClip);
    }
    public void shotMoveSound(){
        SE.PlayOneShot(moveClip);
    }
    public void shotKilledSound(){
        SE.PlayOneShot(killedClip);
    }
    public void shotCheckSound(){
        SE.PlayOneShot(checkClip);
    }
    public void shotTimeOverSound(){
        SE.PlayOneShot(timeOverClip);
    }
}
