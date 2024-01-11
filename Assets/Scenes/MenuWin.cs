
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuWin : MonoBehaviour
{
    private void Awake() {

    }
    // Start is called before the first frame update
    public void VeManHinhChinh(){
        SceneManager.LoadScene(2);
    }
}
