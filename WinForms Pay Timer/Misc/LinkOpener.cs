namespace RealTime_Revenue.Misc;

public class LinkOpener
{
    public void OpenLink(string link)
    {
        using(var process = new System.Diagnostics.Process())
        {
            process.StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = link
            };
            process.Start();
        }
    }
}
