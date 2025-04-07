using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claneder
{
    public static class WindowStyles
    {
        public const long BORDER = 0x00800000L; // The window has a thin-line border.
        public const long CAPTION = 0x00C00000L; // The window has a title bar (includes the WS_BORDER style).
        public const long CHILD = 0x40000000L; // The window is a child window.
        public const long CHILDWINDOW = CHILD; // Same as the WS_CHILD style.
        public const long CLIPCHILDREN = 0x02000000L; // Excludes child window areas when drawing.
        public const long CLIPSIBLINGS = 0x04000000L; // Clips child windows relative to each other.
        public const long DISABLED = 0x08000000L; // The window is initially disabled.
        public const long DLGFRAME = 0x00400000L; // The window has a dialog-box style border.
        public const long GROUP = 0x00020000L; // The window is the first control of a group.
        public const long HSCROLL = 0x00100000L; // The window has a horizontal scroll bar.
        public const long ICONIC = 0x20000000L; // The window is initially minimized.
        public const long MAXIMIZE = 0x01000000L; // The window is initially maximized.
        public const long MAXIMIZEBOX = 0x00010000L; // The window has a maximize button.
        public const long MINIMIZE = 0x20000000L; // The window is initially minimized.
        public const long MINIMIZEBOX = 0x00020000L; // The window has a minimize button.
        public const long OVERLAPPED = 0x00000000L; // The window is an overlapped window.
        public const long POPUP = 0x80000000L; // The window is a pop-up window.
        public const long SIZEBOX = 0x00040000L; // The window has a sizing border.
        public const long SYSMENU = 0x00080000L; // The window has a system menu.
        public const long TABSTOP = 0x00010000L; // The window can receive focus with TAB key.
        public const long THICKFRAME = 0x00040000L; // The window has a sizing border.
        public const long TILED = OVERLAPPED; // The window is an overlapped window.
        public const long VISIBLE = 0x10000000L; // The window is initially visible.
        public const long VSCROLL = 0x00200000L; // The window has a vertical scroll bar.

        public const long OVERLAPPEDWINDOW =
            OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX; // Overlapped window.

        public const long TILEDWINDOW = OVERLAPPEDWINDOW; // Same as WS_OVERLAPPEDWINDOW.

        public const long POPUPWINDOW = POPUP | BORDER | SYSMENU; // Pop-up window.
    }


    internal static class WindowCornerPreference
    {
        public const int DEFAULT = 0;
        public const int DONOTROUND = 1;
        public const int ROUND = 2;
        public const int ROUNDSMALL = 3;
        public const int PREFERENCE = 33;
    }

    internal static class PvAttribute
    {
        public const int TRUE = 1;
        public const int FALSE = 0;
    }

    internal static class DwmWindowBackdropType
    {
        public const int DWMSBT_AUTO = 1;
        public const int DWMSBT_NONE = 2;
        public const int DWMSBT_MAINWINDOW = 3;
        public const int DWMSBT_TRANSIENTWINDOW = 4;
        public const int DWMSBT_TABBEDWINDOW = 5;
    }

    internal static class Win32Index
    {
        public const int PROC = -4; // Retrieves or sets the window procedure.

        public const int INSTANCE = -6; // Retrieves or sets the application instance handle.

        public const int PARENT = -8; // Retrieves or sets the parent window handle.

        public const int STYLE = -16; // Retrieves or sets the window styles.

        public const int EXSTYLE = -20; // Retrieves or sets the extended window styles.

        public const int USERDATA = -21; // Retrieves or sets the user data associated with the window.

        public const int ID = -12; // Retrieves or sets the window identifier.
    }

    public static class WindowPositionFlags
    {
        public const int ASYNCWINDOWPOS = 0x4000; // Prevents blocking if threads are different
        public const int DEFERERASE = 0x2000; // Prevents WM_SYNCPAINT message
        public const int DRAWFRAME = 0x0020; // Draws a frame around the window
        public const int FRAMECHANGED = 0x0020; // Applies new frame styles
        public const int HIDEWINDOW = 0x0080; // Hides the window
        public const int NOACTIVATE = 0x0010; // Does not activate the window
        public const int NOCOPYBITS = 0x0100; // Discards client area contents
        public const int NOMOVE = 0x0002; // Retains current position
        public const int NOOWNERZORDER = 0x0200; // Does not change owner window position
        public const int NOREDRAW = 0x0008; // Does not redraw changes
        public const int NOREPOSITION = 0x0200; // Same as SWP_NOOWNERZORDER
        public const int NOSENDCHANGING = 0x0400; // Prevents WM_WINDOWPOSCHANGING message
        public const int NOSIZE = 0x0001; // Retains current size
        public const int NOZORDER = 0x0004; // Retains current Z order
        public const int SHOWWINDOW = 0x0040; // Shows the window
        public const int NOCHANGE = NOZORDER | NOMOVE | FRAMECHANGED | NOSIZE;
        public const int TOPMOST = NOMOVE | NOMOVE | SHOWWINDOW; // Places window at the topmost position
    }

    public static class WindowZOrder
    {
        public const int BOTTOM = 1; // Places window at the bottom
        public const int NOTOPMOST = -2; // Places window above non-topmost windows
        public const int TOP = 0; // Places window at the top
        public const int TOPMOST = -1; // Places window at the topmost position
    }
    public static class BlurOptions
    {
        public const uint ENABLE = 0x00000001;
        public const uint BLURREGION = 0x00000002;
        public const uint TRANSITIONONMAXIMIZED = 0x00000004;
    }
    public static class WindowLayeredOptions
    {
        public const int EXLAYERS = 0x00080000;
        public const int ALPHA = 0x00000002;
        public const int COLORKEY = 0x00000001;
    }
}
