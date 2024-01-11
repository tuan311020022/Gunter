using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuOver : MonoBehaviour
{
    // Start is called before the first frame update
   
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
