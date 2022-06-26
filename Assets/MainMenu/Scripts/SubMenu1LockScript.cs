using UnityEngine;
using UnityEngine.UI;
public class SubMenu1LockScript : MonoBehaviour
{
    [SerializeField] private GameObject Locked0;
    [SerializeField] private GameObject Locked1;
    [SerializeField] private Button GameButton1;
    [SerializeField] private Button GameButton2;
    public Sprite NotPlayedMat;
    public Sprite PlayedMat;
    //a script to check player progression on toy world and lock the levels and mark them accoring to it
    void Start()
    {
        if (Locked0.activeSelf)
        {
            if (PlayerPrefs.GetInt("ToyRunner") == 1)
            {
                Locked0.SetActive(false);
            }
        }
        if (Locked1.activeSelf)
        {
            if (PlayerPrefs.GetInt("ToyPlatform") == 1)
            {
                Locked1.SetActive(false);
                GameButton1.GetComponent<Image>().sprite = PlayedMat;
            }
        }
        if (PlayerPrefs.GetInt("ToyFlyer")==1)
        {
            GameButton2.GetComponent<Image>().sprite = PlayedMat;
        }
    }
}
