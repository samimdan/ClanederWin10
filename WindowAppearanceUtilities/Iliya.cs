using Claneder;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows;

namespace WindowAppearanceUtilities;

 public class WindowAppearanceUtilities
{
    /// <summary>
    /// Enables the blur effect on the specified WPF window.
    /// </summary>
    /// <param name="window">The WPF window on which to enable the blur effect.</param>
    public void EnableBlur(Window window)
    {
        var windowHelper = new WindowInteropHelper(window);
        var accent = new AccentPolicy
        {
            AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND,
            GradientColor = unchecked((int)0x99FFFFFF)
        };
        var accentStructSize = Marshal.SizeOf(accent);
        var accentPtr = Marshal.AllocHGlobal(accentStructSize);
        Marshal.StructureToPtr(accent, accentPtr, false);

        var data = new WindowCompositionAttributeData
        {
            Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
            SizeOfData = accentStructSize,
            Data = accentPtr
        };

        SetWindowCompositionAttribute(windowHelper.Handle, ref data);

        Marshal.FreeHGlobal(accentPtr);
    }

    /// <summary>
    /// Sets the specified WPF window to always stay on top of other windows.
    /// </summary>
    /// <param name="window">The WPF window to set as topmost.</param>
    public void SetWindowTopMost(Window window)
    {
        var windowHelper = new WindowInteropHelper(window);
        SetWindowPos(windowHelper.Handle, WindowZOrder.TOPMOST, 0, 0, 0, 0, WindowPositionFlags.NOMOVE | WindowPositionFlags.NOSIZE);
    }

    /// <summary>
    /// Sets the window composition attribute for a specified window.
    /// </summary>
    /// <param name="hwnd">The handle to the window.</param>
    /// <param name="data">The composition attribute data to set.</param>
    /// <returns>An integer indicating success or failure.</returns>
    [DllImport("user32.dll")]
    internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

    /// <summary>
    /// Sets the position of a window in the Z order.
    /// </summary>
    /// <param name="hWnd">The handle to the window.</param>
    /// <param name="hWndInsertAfter">The position in the Z order.</param>
    /// <param name="x">The new X position of the window.</param>
    /// <param name="y">The new Y position of the window.</param>
    /// <param name="cx">The new width of the window.</param>
    /// <param name="cy">The new height of the window.</param>
    /// <param name="uFlags">The window positioning flags.</param>
    /// <returns>True if the function succeeds; otherwise, false.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    /// <summary>
    /// Represents the possible accent states for a window.
    /// </summary>
    internal enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_ENABLE_ACRYLICBLURBEHIND = 4, // Requires Windows 10 v1803+
        ACCENT_ENABLE_HOSTBACKDROP = 5       // Newer
    }

    /// <summary>
    /// Represents the accent policy structure used for window composition attributes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    /// <summary>
    /// Represents the data structure for window composition attributes.
    /// </summary>
    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    /// <summary>
    /// Represents the possible window composition attributes.
    /// </summary>
    internal enum WindowCompositionAttribute
    {
        WCA_ACCENT_POLICY = 19
    }

}