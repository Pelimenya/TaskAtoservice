namespace AutoCenterApp.Models;

public  partial class Auto
{
    public string MaskStateNumber
    {
        get
        {
            return $"{StateNumber[0]}**{StateNumber.Substring(3)}";
        }
    }
}