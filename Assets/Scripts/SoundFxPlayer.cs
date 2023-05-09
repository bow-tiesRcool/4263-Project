using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxPlayer : MonoBehaviour
{

   public AudioSource src;
   public AudioClip sfx1, sfx2, sfx3, sfx4;

   public void PlayBotton() {
    src.clip = sfx1;
    src.Play();
   }
    public void Options() {
    src.clip = sfx2;
    src.Play();
   }
    public void Load() {
    src.clip = sfx3;
    src.Play();
   }
   public void Quit() {
    src.clip = sfx4;
    src.Play();
   }

   

   }
