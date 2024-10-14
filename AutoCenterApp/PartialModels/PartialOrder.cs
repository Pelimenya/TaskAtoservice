using System.IO;
using Avalonia.Media.Imaging;

namespace AutoCenterApp.Models;

public partial class Order
{
    public Bitmap Image
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