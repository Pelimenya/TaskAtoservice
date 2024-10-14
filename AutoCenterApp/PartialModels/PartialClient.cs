namespace AutoCenterApp.Models;

public partial class Client
{
    public string FullName
    {
        get
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }
    }
}