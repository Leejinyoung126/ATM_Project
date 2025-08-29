using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public GameObject ButtonGroup;
    public GameObject DepositUI;
    public GameObject WithdrawalUI;
    
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

    public void Deposit()
    {

    }

    public void Withdrawal()
    {

    }
}
