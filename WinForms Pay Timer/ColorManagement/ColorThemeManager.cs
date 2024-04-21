namespace WinForms_Pay_Timer.ColorManagement;

public static partial class ColorThemeManager
{
    public static ColorTheme Light { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = SystemColors.Control,
        FontColor = Color.Black,
        ButtonColor = Color.FromArgb(255, 225, 225, 225),
        ButtonFontColor = Color.Black,
        DisabledButtonColor = Color.FromArgb(255, 155, 155, 155)
    };

    public static ColorTheme Dark { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 24, 28, 35),
        FontColor = Color.WhiteSmoke,
        ButtonColor = Color.FromArgb(255, 59, 64, 76),
        ButtonFontColor = Color.WhiteSmoke,
        DisabledButtonColor = Color.FromArgb(255, 100, 100, 100)
    };

    public static ColorTheme OceanBreeze { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 135, 206, 235),
        FontColor = Color.FromArgb(255, 3, 43, 68),
        ButtonColor = Color.FromArgb(255, 52, 168, 90),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 55, 80, 80)
    };

    public static ColorTheme Sunset { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 255, 192, 128),
        FontColor = Color.FromArgb(255, 102, 51, 0),
        ButtonColor = Color.FromArgb(255, 255, 153, 0),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 128, 80, 60)
    };

    public static ColorTheme Midnight { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 25, 25, 112),
        FontColor = Color.FromArgb(255, 192, 192, 192),
        ButtonColor = Color.FromArgb(255, 75, 0, 130),
        ButtonFontColor = Color.FromArgb(255, 230, 230, 250),
        DisabledButtonColor = Color.FromArgb(255, 45, 45, 90)
    };

    public static ColorTheme RoseGarden { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 240, 128, 128),
        FontColor = Color.FromArgb(255, 0, 32, 0),
        ButtonColor = Color.FromArgb(255, 205, 92, 92),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 165, 82, 82)
    };

    public static ColorTheme Winter { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 225, 225, 255),
        FontColor = Color.FromArgb(255, 0, 0, 128),
        ButtonColor = Color.FromArgb(255, 173, 216, 230),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 150, 190, 225)
    };

    public static ColorTheme Neon { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 10, 10, 10),
        FontColor = Color.FromArgb(255, 0, 255, 255),
        ButtonColor = Color.FromArgb(255, 0, 255, 127),
        ButtonFontColor = Color.Black,
        DisabledButtonColor = Color.FromArgb(255, 50, 50, 50)
    };


    public static void InitColors(Form form)
    {
        ColorTheme theme = GetTheme((ThemeMode)Properties.Settings.Default.ColorThemeOption);
        form.BackColor = theme.ColorBg;
        form.ForeColor = theme.FontColor;
        ChangeControlsColor(form, theme.ColorBg, theme.FontColor, theme.ButtonColor, theme.ButtonFontColor, theme.DisabledButtonColor);
    }

    static ColorTheme GetTheme(ThemeMode mode)
    {
        switch(mode)
        {
            case ThemeMode.Light:
                return Light;
            case ThemeMode.Dark:
                return Dark;
            case ThemeMode.OceanBreeze:
                return OceanBreeze;
            case ThemeMode.Sunset:
                return Sunset;
            case ThemeMode.Midnight:
                return Midnight;
            case ThemeMode.Rose:
                return RoseGarden;
            case ThemeMode.Winter:
                return Winter;
            case ThemeMode.Neon:
                return Neon;
            default:
                return Light;
        }
    }


    static void ChangeControlsColor(Control control, Color bgColor, Color fontColor, Color buttonColor, Color buttonFontColor, Color disabledButtonColor)
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
