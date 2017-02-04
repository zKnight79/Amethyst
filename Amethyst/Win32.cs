using System.Runtime.InteropServices;

namespace Amethyst
{
    static class Win32
    {
        /// <summary>
        /// Pixel format descriptor "Double Buffer" flag
        /// </summary>
        public const uint PFD_DOUBLEBUFFER = 0x00000001;
        /// <summary>
        /// Pixel format descriptor "Draw to Window" flag
        /// </summary>
        public const uint PFD_DRAW_TO_WINDOW = 0x00000004;
        /// <summary>
        /// Pixel format descriptor "Support OpenGL" flag
        /// </summary>
        public const uint PFD_SUPPORT_OPENGL = 0x00000020;
        /// <summary>
        /// Pixel format descriptor "RGBA color mode" flag
        /// </summary>
        public const uint PFD_TYPE_RGBA = 0;
        /// <summary>
        /// Pixel format descriptor "Main plane" flag
        /// </summary>
        public const uint PFD_MAIN_PLANE = 0;
        /// <summary>
        /// Device mode "Bits per pixel" flag
        /// </summary>
        public const int DM_BITSPERPEL = 0x40000;
        /// <summary>
        /// Device mode "Pixels width" flag
        /// </summary>
        public const int DM_PELSWIDTH = 0x80000;
        /// <summary>
        /// Device mode "Pixels height" flag
        /// </summary>
        public const int DM_PELSHEIGHT = 0x100000;
        /// <summary>
        /// Change display settings "Fullscreen" flag
        /// </summary>
        public const int CDS_FULLSCREEN = 0x00000004;

        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.<br />
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.<br />
        /// The device context is an opaque data structure, whose values are used internally by GDI.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.</param>
        /// <returns>If the function succeeds, the return value is a handle to the DC for the specified window's client area. If the function fails, the return value is 0.</returns>
        [DllImport("user32")]
        public static extern uint GetDC(uint hwnd);
        /// <summary>
        /// The ReleaseDC function releases a device context (DC), freeing it for use by other applications.<br />
        /// The effect of the ReleaseDC function depends on the type of DC.<br />
        /// It frees only common and window DCs.<br />
        /// It has no effect on class or private DCs.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
        /// <param name="hDC">A handle to the DC to be released.</param>
        /// <returns>The return value indicates whether the DC was released. If the DC was released, the return value is 1. If the DC was not released, the return value is zero.</returns>
        [DllImport("user32")]
        public static extern int ReleaseDC(uint hWnd, uint hDC);
        /// <summary>
        /// The ChoosePixelFormat function attempts to match an appropriate pixel format supported by a device context to a given pixel format specification.
        /// </summary>
        /// <param name="hdc">Specifies the device context that the function examines to determine the best match for the pixel format descriptor pointed to by ppfd.</param>
        /// <param name="ppfd">Pointer to a PIXELFORMATDESCRIPTOR structure that specifies the requested pixel format.</param>
        /// <returns>If the function succeeds, the return value is a pixel format index (one-based) that is the closest match to the given pixel format descriptor.If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("gdi32")]
        public static extern int ChoosePixelFormat(uint hdc, ref PIXELFORMATDESCRIPTOR ppfd);
        /// <summary>
        /// The SetPixelFormat function sets the pixel format of the specified device context to the format specified by the iPixelFormat index.
        /// </summary>
        /// <param name="hdc">Specifies the device context whose pixel format the function attempts to set.</param>
        /// <param name="iPixelFormat">Index that identifies the pixel format to set. The various pixel formats supported by a device context are identified by one-based indexes.</param>
        /// <param name="ppfd">Pointer to a PIXELFORMATDESCRIPTOR structure that contains the logical pixel format specification. The system's metafile component uses this structure to record the logical pixel format specification. The structure has no other effect upon the behavior of the SetPixelFormat function.</param>
        /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. To get extended error information, call GetLastError.</returns>
        [DllImport("gdi32")]
        public static extern int SetPixelFormat(uint hdc, int iPixelFormat, ref PIXELFORMATDESCRIPTOR ppfd);
        /// <summary>
        /// Retrieves the calling thread's last-error code value.<br />
        /// The last-error code is maintained on a per-thread basis.<br />
        /// Multiple threads do not overwrite each other's last-error code.
        /// </summary>
        /// <returns>The return value is the calling thread's last-error code.</returns>
        [DllImport("kernel32")]
        public static extern uint GetLastError();
        /// <summary>
        /// The ChangeDisplaySettings function changes the settings of the default display device to the specified graphics mode.
        /// </summary>
        /// <param name="lpDevMode">A pointer to a DEVMODE structure that describes the new graphics mode. If lpDevMode is NULL, all the values currently in the registry will be used for the display setting. Passing NULL for the lpDevMode parameter and 0 for the dwFlags parameter is the easiest way to return to the default mode after a dynamic mode change.</param>
        /// <param name="dwflags">Indicates how the graphics mode should be changed.</param>
        /// <returns>If the function succeeds, the return value is 0. If the function fails, the return value is NON-ZERO.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int ChangeDisplaySettings([MarshalAs(UnmanagedType.LPStruct)] DEVMODE lpDevMode, uint dwflags);
        /// <summary>
        /// Displays or hides the cursor.
        /// </summary>
        /// <param name="bShow">If bShow is TRUE, the display count is incremented by one. If bShow is FALSE, the display count is decremented by one.</param>
        /// <returns>The return value specifies the new display counter.</returns>
        [DllImport("user32")]
        public static extern int ShowCursor(bool bShow);
        /// <summary>
        /// The SwapBuffers function exchanges the front and back buffers if the current pixel format for the window referenced by the specified device context includes a back buffer
        /// </summary>
        /// <param name="hdc">Specifies a device context. If the current pixel format for the window referenced by this device context includes a back buffer, the function exchanges the front and back buffers</param>
        /// <returns>True if succeeds, false if fails</returns>
        [DllImport("gdi32")]
        public static extern bool SwapBuffers(uint hdc);
    }

    /// <summary>
    /// The PIXELFORMATDESCRIPTOR structure describes the pixel format of a drawing surface.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    struct PIXELFORMATDESCRIPTOR
    {
        /// <summary>
        /// Specifies the size of this data structure. This value should be set to sizeof(PIXELFORMATDESCRIPTOR).
        /// </summary>
        public ushort nSize;
        /// <summary>
        /// Specifies the version of this data structure. This value should be set to 1.
        /// </summary>
        public ushort nVersion;
        /// <summary>
        /// A set of bit flags that specify properties of the pixel buffer. The properties are generally not mutually exclusive; you can set any combination of bit flags, with the exceptions noted. The following bit flag constants are defined.
        /// </summary>
        public uint dwFlags;
        /// <summary>
        /// Specifies the type of pixel data. The following types are defined.
        /// </summary>
        public byte iPixelType;
        /// <summary>
        /// Specifies the number of color bitplanes in each color buffer. For RGBA pixel types, it is the size of the color buffer, excluding the alpha bitplanes. For color-index pixels, it is the size of the color-index buffer.
        /// </summary>
        public byte cColorBits;
        /// <summary>
        /// Specifies the number of red bitplanes in each RGBA color buffer.
        /// </summary>
        public byte cRedBits;
        /// <summary>
        /// Specifies the shift count for red bitplanes in each RGBA color buffer.
        /// </summary>
        public byte cRedShift;
        /// <summary>
        /// Specifies the number of green bitplanes in each RGBA color buffer.
        /// </summary>
        public byte cGreenBits;
        /// <summary>
        /// Specifies the shift count for green bitplanes in each RGBA color buffer.
        /// </summary>
        public byte cGreenShift;
        /// <summary>
        /// Specifies the number of blue bitplanes in each RGBA color buffer.
        /// </summary>
        public byte cBlueBits;
        /// <summary>
        /// Specifies the shift count for blue bitplanes in each RGBA color buffer.
        /// </summary>
        public byte cBlueShift;
        /// <summary>
        /// Specifies the number of alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.
        /// </summary>
        public byte cAlphaBits;
        /// <summary>
        /// Specifies the shift count for alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.
        /// </summary>
        public byte cAlphaShift;
        /// <summary>
        /// Specifies the total number of bitplanes in the accumulation buffer.
        /// </summary>
        public byte cAccumBits;
        /// <summary>
        /// Specifies the number of red bitplanes in the accumulation buffer.
        /// </summary>
        public byte cAccumRedBits;
        /// <summary>
        /// Specifies the number of green bitplanes in the accumulation buffer.
        /// </summary>
        public byte cAccumGreenBits;
        /// <summary>
        /// Specifies the number of blue bitplanes in the accumulation buffer.
        /// </summary>
        public byte cAccumBlueBits;
        /// <summary>
        /// Specifies the number of alpha bitplanes in the accumulation buffer.
        /// </summary>
        public byte cAccumAlphaBits;
        /// <summary>
        /// Specifies the depth of the depth (z-axis) buffer.
        /// </summary>
        public byte cDepthBits;
        /// <summary>
        /// Specifies the depth of the stencil buffer.
        /// </summary>
        public byte cStencilBits;
        /// <summary>
        /// Specifies the number of auxiliary buffers. Auxiliary buffers are not supported.
        /// </summary>
        public byte cAuxBuffers;
        /// <summary>
        /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
        /// </summary>
        public byte iLayerType;
        /// <summary>
        /// Specifies the number of overlay and underlay planes. Bits 0 through 3 specify up to 15 overlay planes and bits 4 through 7 specify up to 15 underlay planes.
        /// </summary>
        public byte bReserved;
        /// <summary>
        /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
        /// </summary>
        public uint dwLayerMask;
        /// <summary>
        /// Specifies the transparent color or index of an underlay plane. When the pixel type is RGBA, dwVisibleMask is a transparent RGB color value. When the pixel type is color index, it is a transparent index value.
        /// </summary>
        public uint dwVisibleMask;
        /// <summary>
        /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
        /// </summary>
        public uint dwDamageMask;
    }

    /// <summary>
    /// The DEVMODE data structure contains information about the initialization and environment of a printer or a display device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    class DEVMODE
    {
        /// <summary>
        /// A zero-terminated character array that specifies the "friendly" name of the printer or display; for example, "PCL/HP LaserJet" in the case of PCL/HP LaserJet. This string is unique among device drivers. Note that this name may be truncated to fit in the dmDeviceName array.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] dmDeviceName;
        /// <summary>
        /// The version number of the initialization data specification on which the structure is based. To ensure the correct version is used for any operating system, use DM_SPECVERSION.
        /// </summary>
        public short dmSpecVersion;
        /// <summary>
        /// The driver version number assigned by the driver developer.
        /// </summary>
        public short dmDriverVersion;
        /// <summary>
        /// Specifies the size, in bytes, of the DEVMODE structure, not including any private driver-specific data that might follow the structure's public members. Set this member to sizeof (DEVMODE) to indicate the version of the DEVMODE structure being used.
        /// </summary>
        public short dmSize;
        /// <summary>
        /// Contains the number of bytes of private driver-data that follow this structure. If a device driver does not use device-specific information, set this member to zero.
        /// </summary>
        public short dmDriverExtra;
        /// <summary>
        /// Specifies whether certain members of the DEVMODE structure have been initialized. If a member is initialized, its corresponding bit is set, otherwise the bit is clear. A driver supports only those DEVMODE members that are appropriate for the printer or display technology.
        /// </summary>
        public int dmFields;
        /// <summary>
        /// DEVMODE internal union
        /// </summary>
        public DEVMODE_UNION u;
        /// <summary>
        /// Switches between color and monochrome on color printers.
        /// </summary>
        public short dmColor;
        /// <summary>
        /// Selects duplex or double-sided printing for printers capable of duplex printing.
        /// </summary>
        public short dmDuplex;
        /// <summary>
        /// Specifies the y-resolution, in dots per inch, of the printer. If the printer initializes this member, the dmPrintQuality member specifies the x-resolution, in dots per inch, of the printer.
        /// </summary>
        public short dmYResolution;
        /// <summary>
        /// Specifies how TrueType fonts should be printed.
        /// </summary>
        public short dmTTOption;
        /// <summary>
        /// Specifies whether collation should be used when printing multiple copies. (This member is ignored unless the printer driver indicates support for collation by setting the dmFields member to DM_COLLATE.)
        /// </summary>
        public short dmCollate;
        /// <summary>
        /// A zero-terminated character array that specifies the name of the form to use; for example, "Letter" or "Legal". A complete set of names can be retrieved by using the EnumForms function.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] dmFormName;
        /// <summary>
        /// The number of pixels per logical inch. Printer drivers do not use this member.
        /// </summary>
        public short dmLogPixels;
        /// <summary>
        /// Specifies the color resolution, in bits per pixel, of the display device (for example: 4 bits for 16 colors, 8 bits for 256 colors, or 16 bits for 65,536 colors). Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
        /// </summary>
        public int dmBitsPerPel;
        /// <summary>
        /// Specifies the width, in pixels, of the visible device surface. Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
        /// </summary>
        public int dmPelsWidth;
        /// <summary>
        /// Specifies the height, in pixels, of the visible device surface. Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
        /// </summary>
        public int dmPelsHeight;
        /// <summary>
        /// Specifies the device's display mode.<br />
        /// OR<br />
        /// Specifies where the NUP is done.
        /// </summary>
        public int dmDisplayFlagsOrdmNup;
        /// <summary>
        /// Specifies the frequency, in hertz (cycles per second), of the display device in a particular mode. This value is also known as the display device's vertical refresh rate. Display drivers use this member. It is used, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
        /// </summary>
        public int dmDisplayFrequency;
        /// <summary>
        /// Specifies how ICM is handled. For a non-ICM application, this member determines if ICM is enabled or disabled. For ICM applications, the system examines this member to determine how to handle ICM support.
        /// </summary>
        public int dmICMMethod;
        /// <summary>
        /// Specifies which color matching method, or intent, should be used by default. This member is primarily for non-ICM applications. ICM applications can establish intents by using the ICM functions.
        /// </summary>
        public int dmICMIntent;
        /// <summary>
        /// Specifies the type of media being printed on.
        /// </summary>
        public int dmMediaType;
        /// <summary>
        /// Specifies how dithering is to be done.
        /// </summary>
        public int dmDitherType;
        /// <summary>
        /// Not used; must be zero.
        /// </summary>
        public int dmReserved1;
        /// <summary>
        /// Not used; must be zero.
        /// </summary>
        public int dmReserved2;
        /// <summary>
        /// Not used; must be zero.
        /// </summary>
        public int dmPanningWidth;
        /// <summary>
        /// Not used; must be zero.
        /// </summary>
        public int dmPanningHeight;
    }

    /// <summary>
    /// DEVMODE internal union
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    struct DEVMODE_UNION
    {
        /// <summary>
        /// For printer devices only, selects the orientation of the paper. This member can be either DMORIENT_PORTRAIT (1) or DMORIENT_LANDSCAPE (2).
        /// </summary>
        [FieldOffset(0)]
        public short dmOrientation;
        /// <summary>
        /// For printer devices only, selects the size of the paper to print on. This member can be set to zero if the length and width of the paper are both set by the dmPaperLength and dmPaperWidth members. Otherwise, the dmPaperSize member can be set to a device specific value greater than or equal to DMPAPER_USER or to one of the predefined values.
        /// </summary>
        [FieldOffset(2)]
        public short dmPaperSize;
        /// <summary>
        /// For printer devices only, overrides the length of the paper specified by the dmPaperSize member, either for custom paper sizes or for devices such as dot-matrix printers that can print on a page of arbitrary length. These values, along with all other values in this structure that specify a physical length, are in tenths of a millimeter.
        /// </summary>
        [FieldOffset(4)]
        public short dmPaperLength;
        /// <summary>
        /// For printer devices only, overrides the width of the paper specified by the dmPaperSize member.
        /// </summary>
        [FieldOffset(6)]
        public short dmPaperWidth;
        /// <summary>
        /// Specifies the factor by which the printed output is to be scaled. The apparent page size is scaled from the physical page size by a factor of dmScale /100. For example, a letter-sized page with a dmScale value of 50 would contain as much data as a page of 17- by 22-inches because the output text and graphics would be half their original height and width.
        /// </summary>
        [FieldOffset(8)]
        public short dmScale;
        /// <summary>
        /// Selects the number of copies printed if the device supports multiple-page copies.
        /// </summary>
        [FieldOffset(10)]
        public short dmCopies;
        /// <summary>
        /// Specifies the paper source. To retrieve a list of the available paper sources for a printer, use the DeviceCapabilities function with the DC_BINS flag.
        /// </summary>
        [FieldOffset(12)]
        public short dmDefaultSource;
        /// <summary>
        /// Specifies the printer resolution.
        /// </summary>
        [FieldOffset(14)]
        public short dmPrintQuality;

        /// <summary>
        /// For display devices only, a POINTL structure that indicates the positional coordinates of the display device in reference to the desktop area. The primary display device is always located at coordinates (0,0).
        /// </summary>
        [FieldOffset(0)]
        public int dmPosition_x;
        /// <summary>
        /// For display devices only, a POINTL structure that indicates the positional coordinates of the display device in reference to the desktop area. The primary display device is always located at coordinates (0,0).
        /// </summary>
        [FieldOffset(4)]
        public int dmPosition_y;
        /// <summary>
        /// For display devices only, the orientation at which images should be presented. If DM_DISPLAYORIENTATION is not set, this member must be zero.
        /// </summary>
        [FieldOffset(8)]
        public int dmDisplayOrientation;
        /// <summary>
        /// For fixed-resolution display devices only, how the display presents a low-resolution mode on a higher-resolution display. For example, if a display device's resolution is fixed at 1024 x 768 pixels but its mode is set to 640 x 480 pixels, the device can either display a 640 x 480 image somewhere in the interior of the 1024 x 768 screen space or stretch the 640 x 480 image to fill the larger screen space. If DM_DISPLAYFIXEDOUTPUT is not set, this member must be zero.
        /// </summary>
        [FieldOffset(12)]
        public int dmDisplayFixedOutput;
    }
}
