using Avalonia.Media;

namespace AutoCenterApp.Models;

public partial class Status
{
    public SolidColorBrush SatusColor
    {
        get
        {
            if (StatusName == "Выполнено")
            {
                return new SolidColorBrush(Colors.Green);
            }

            if (StatusName == "Запланировано")
            {
                return new SolidColorBrush(Colors.Blue);
            }

            if (StatusName == "Принята к исполнению")
            {
                return new SolidColorBrush(Colors.Orange);
            }

            return new SolidColorBrush(Colors.Gray);
        }
    }
}