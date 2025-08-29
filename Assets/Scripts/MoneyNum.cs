using UnityEngine;
using UnityEngine.UI;

public class MoneyNum : MonoBehaviour
{
    public Text nameText;
    public Text balanceNum;
    public Text cashNum;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh()
    {
        var d = GameManager.Instance.userData;
        nameText.text = d.name;
        balanceNum.text = "Balance\t\t" + string.Format("{0:N0}", d.balance);
        cashNum.text = string.Format("{0:N0}", d.cash);
    }
}
