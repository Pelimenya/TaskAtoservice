using System.IO;
using Avalonia.Controls;
using Avalonia.Media.Imaging;

namespace AutoCenterApp.Models;

public partial class Personal
{
    private string FullName
    {
        get { return $"{LastName} {FirstName} {MiddleName}"; }
    }

    private Bitmap Image
    {
        get
        {
            if (Photo == null)
                return null;

            using (var stream = new MemoryStream(Photo))
            {
                return new Bitmap(stream);
            }
        }
    }
}