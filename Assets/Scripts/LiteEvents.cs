using System;

public static class LiteEvents
{
    public static Action OnPlayerDeadCallback { get; set; }
    public static Action OnButtonPressedPlay { get; set; }
    public static Action OnButtonPressedContinue { get; set; }
    public static Action OnEscapeButtonPressed { get; set; }
}

