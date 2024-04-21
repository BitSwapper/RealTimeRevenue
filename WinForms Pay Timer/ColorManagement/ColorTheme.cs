namespace WinForms_Pay_Timer.ColorManagement;

public static class ColorTheme
{
    static bool useDarkMode => Properties.Settings.Default.UseDarkMode;
    static Color colorBgWhite = SystemColors.Control;
    static Color colorBgDark = Color.FromArgb(255, 24, 28, 35);
    static Color fontColorWhite = Color.Black;
    static Color fontColorDark = Color.WhiteSmoke;
    static Color buttonColorWhite = Color.FromArgb(255, 225, 225, 225);
    static Color buttonColorDark = Color.FromArgb(255, 59, 64, 76);
    static Color buttonFontColorWhite = Color.Black;
    static Color buttonFontColorDark = Color.WhiteSmoke;
    static Color disabledButtonColorWhite = Color.FromArgb(255, 155, 155, 155); // New color for disabled buttons in light theme
    static Color disabledButtonColorDark = Color.FromArgb(255, 100, 100, 100); // New color for disabled buttons in dark theme

    public static void InitColors(Form form)
    {
        if(useDarkMode)
        {
            form.BackColor = colorBgDark;
            form.ForeColor = fontColorDark;
            ChangeControlsColor(form, colorBgDark, fontColorDark, buttonColorDark, buttonFontColorDark, disabledButtonColorDark);
        }
        else
        {
            form.BackColor = colorBgWhite;
            form.ForeColor = fontColorWhite;
            ChangeControlsColor(form, colorBgWhite, fontColorWhite, buttonColorWhite, buttonFontColorWhite, disabledButtonColorWhite);
        }
    }

    private static void ChangeControlsColor(Control control, Color bgColor, Color fontColor, Color buttonColor, Color buttonFontColor, Color disabledButtonColor)
    {
        foreach(Control childControl in control.Controls)
        {
            if(childControl is Button)
            {
                Button button = (Button)childControl;
                button.BackColor = buttonColor;
                button.ForeColor = buttonFontColor;
                if(!button.Enabled)
                {
                    button.BackColor = disabledButtonColor; // Set the disabled color
                }
                button.EnabledChanged += (sender, e) => // Handle the EnabledChanged event
                {
                    Button btn = (Button)sender;
                    if(btn.Enabled)
                    {
                        btn.BackColor = buttonColor; // Reset the color when re-enabled
                        btn.ForeColor = buttonFontColor;
                    }
                    else
                    {
                        btn.BackColor = disabledButtonColor; // Set the disabled color
                    }
                };
            }
            else if(childControl is Form)
            {
                Form form = (Form)childControl;
                form.BackColor = bgColor;
                form.ForeColor = fontColor;
            }
            else if(childControl is Label)
            {
                Label label = (Label)childControl;
                if(label.Name.Contains("Money"))
                    continue;
                label.BackColor = bgColor;
                label.ForeColor = fontColor;
            }

            if(childControl.Controls.Count > 0)
            {
                ChangeControlsColor(childControl, bgColor, fontColor, buttonColor, buttonFontColor, disabledButtonColor);
            }
        }
    }
}