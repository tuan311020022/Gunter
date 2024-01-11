using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuOver : MonoBehaviour
{
    SoundManager soundManager;

    private void Awake() {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.PlayMusic(SoundType.GameOver, true, 1);
        soundManager.PlayMusic(SoundType.GameMusic, false, 0);
    }
   
    public void ChoiLai(){
        SceneManager.LoadScene(4);
    }
    public void VeManHinhChinh(){
        SceneManager.LoadScene(0);
    }
    public void Thoat(){
        Application.Quit();
    }
}
