//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EXIT: MonoBehaviour
{
    // Thoat game 
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    //public AudioSource audioSource;
    //void KiemTra()
    //{
    //    // Kiểm tra xem AudioSource có được gắn kết không
    //    if (audioSource == null)
    //    {
    //        audioSource = GetComponent<AudioSource>();
    //    }
    //}

    //    // Tăng âm lượng
    //public void IncreaseVolume(float amount)
    //{
    //    if (audioSource != null)
    //    {
    //        audioSource.volume = Mathf.Clamp01(audioSource.volume + amount);
    //    }
    //}

    //    // Giảm âm lượng
    //public void DecreaseVolume(float amount)
    //{
    //    if (audioSource != null)
    //    {
    //        audioSource.volume = Mathf.Clamp01(audioSource.volume - amount);
    //    }
    //}

}
