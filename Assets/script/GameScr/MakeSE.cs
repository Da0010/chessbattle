using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSE : MonoBehaviour
{
    [SerializeField] AudioClip moveClip;
    [SerializeField] AudioClip killedClip;
    [SerializeField] AudioClip checkClip;
    [SerializeField] AudioClip timeOverClip;
    AudioSource SE;
    // Start is called before the first frame update
    void Start()
    {
        SE = this.GetComponent<AudioSource>();
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
