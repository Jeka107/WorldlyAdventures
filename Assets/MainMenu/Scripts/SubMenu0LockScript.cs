using UnityEngine;
using UnityEngine.UI;
public class SubMenu0LockScript : MonoBehaviour
{
    [SerializeField] private GameObject Locked;
    [SerializeField] private Button GameButton;
    public Sprite NotPlayedMat;
    public Sprite PlayedMat;
    //a script to check player progression on tutorial world and lock the levels and mark them accoring to it
    void Start()
    {
        if (Locked.activeSelf)
        {
            if (PlayerPrefs.GetInt("TutorialDoodleJump") == 1)
            {
                Locked.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("TutorialRunner") == 1)
        {
            GameButton.GetComponent<Image>().sprite = PlayedMat;
        }
    }
}
