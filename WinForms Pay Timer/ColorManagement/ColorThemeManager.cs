namespace WinForms_Pay_Timer.ColorManagement;

public static partial class ColorThemeManager
{
    public static ColorTheme? CurTheme { get; private set; }

    public static void InitColors(Form form)
    {
        CurTheme = GetTheme((ThemeMode)Properties.Settings.Default.ColorThemeOption);
        form.BackColor = CurTheme.ColorBg;
        form.ForeColor = CurTheme.FontColor;
        ChangeControlsColor(form, CurTheme);
    }

    static ColorTheme GetTheme(ThemeMode mode) => mode switch
    {
        ThemeMode.Dark => ColorThemePalette.Dark,
        ThemeMode.Light => ColorThemePalette.Light,
        ThemeMode.Ocean => ColorThemePalette.Ocean,
        ThemeMode.Sunset => ColorThemePalette.Sunset,
        ThemeMode.RoseGarden => ColorThemePalette.RoseGarden,
        ThemeMode.Winter => ColorThemePalette.Winter,
        ThemeMode.HighContrast => ColorThemePalette.HighContrast,
        ThemeMode.Halloween => ColorThemePalette.Halloween,
        ThemeMode.MutedHalloween => ColorThemePalette.MutedHalloween,
        _ => ColorThemePalette.Dark,
    };


    static void ChangeControlsColor(Control control, ColorTheme theme)
    {
        foreach(Control childControl in control.Controls)
        {
            if(childControl is Button button)
            {
                button.BackColor = theme.ButtonColor;
                button.ForeColor = theme.ButtonFontColor;
                if(!button.Enabled)
                    button.BackColor = theme.DisabledButtonColor;

                button.EnabledChanged += (sender, e) =>
                {
                    Button btn = (Button)sender!;
                    if(btn.Enabled)
                    {
                        btn.BackColor = theme.ButtonColor;
                        btn.ForeColor = theme.ButtonFontColor;
                    }
                    else
                        btn.BackColor = theme.DisabledButtonColor;
                };
            }
            else if(childControl is Form form)
            {
                form.BackColor = theme.ColorBg;
                form.ForeColor = theme.FontColor;
            }
            else if(childControl is Label label)
            {
                if(label.Name.Contains("Money"))
                {
                    label.BackColor = theme.ColorBg;
                    label.ForeColor = theme.MoneyFontColor;
                }
                else if(label.Name == "labelTimerDisplay")
                {
                    label.BackColor = theme.ColorBg;
                    label.ForeColor = theme.TimerColor;
                }
                else
                {
                    label.BackColor = theme.ColorBg;
                    label.ForeColor = theme.FontColor;
                }
            }
            else if(childControl is ListView LV)
            {
                LV.ForeColor = theme.FontColorListViewCaption;
                LV.BackColor = theme.ColorBg;
            }

            if(childControl.Controls.Count > 0)
                ChangeControlsColor(childControl, theme);
        }
    }
}
