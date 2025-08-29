using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    //필드에 캐싱
    private UserData d;

    public GameObject ButtonGroup;
    public GameObject DepositUI;
    public GameObject WithdrawalUI;
    public GameObject PopupError;
    public MoneyNum moneyNum;
    public InputField depositInputField;
    public InputField withdrawalInputField;

    private void Start()
    {
        d = GameManager.Instance.userData;
    }

    public void OpenDeposit()
    {
        DepositUI.SetActive(true);
        WithdrawalUI.SetActive(false);
        ButtonGroup.SetActive(false);
    }

    public void OpenWithdrawal()
    {
        DepositUI.SetActive(false);
        WithdrawalUI.SetActive(true);
        ButtonGroup.SetActive(false);
    }

    public void BackToMenu()
    {
        DepositUI.SetActive(false);
        WithdrawalUI.SetActive(false);
        ButtonGroup.SetActive(true);
    }

    public void Deposit(int amount)
    {
        
        //현금이 부족하면 팝업에러창을 띄움
        if(d.cash < amount)
        {
            PopupError.SetActive(true);
            return;
        }

        //입금처리
        d.cash -= amount;
        d.balance += amount;
        
        //처리한 후 값을 저장
        GameManager.Instance.SaveUserData();

        //UI갱신
        moneyNum.Refresh();
    }

    public void Withdrawal(int amount)
    {
        
        //통장 잔액이 부족하면 팝업에러창을 띄움
        if(d.balance < amount)
        {
            PopupError.SetActive(true);
            return;
        }

        d.balance -= amount;
        d.cash += amount;

        GameManager.Instance.SaveUserData();

        moneyNum.Refresh();
    }

    public void DepositToInput()
    {
        string raw = depositInputField.text;

        int amount;

        if(!int.TryParse(raw, out amount) || amount <= 0)
        {
            return;
        }

        //이미 Deposit에서 Save를 하고있으니 Save를 호출하지않아도 됨
        Deposit(amount);
        depositInputField.text = "";
    }

    public void WithdrawalToInput()
    {
        string raw = withdrawalInputField.text;

        int amount;

        if (!int.TryParse(raw, out amount) || amount <= 0)
        {
            return;
        }

        Withdrawal(amount);
        withdrawalInputField.text = "";
    }

    public void ClosePopupError()
    {
        PopupError.SetActive(false);
    }
}
