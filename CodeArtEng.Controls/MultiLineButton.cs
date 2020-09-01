using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Multiline Button display style
    /// </summary>
    public enum MultiLineButtonStyle
    {
        /// <summary>
        /// Rounded Rectangle Button
        /// </summary>
        RoundedRectangle, //Default Style
        /// <summary>
        /// Square Button
        /// </summary>
        Square
    }

    /// <summary>
    /// Button with Main Title and SubTitle
    /// </summary>
    [DefaultEvent("Click")]
    public partial class MultiLineButton : Control
    {
        /// <summary>
        /// Button's Color
        /// </summary>
        [Category("Appearance")]
        [Description("Button's color.")]
        [DefaultValue(typeof(Color), "225,225,225")]
        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; UpdateBrushandPen(); Refresh(); }
        }
        private Color fillColor = Color.FromArgb(225, 225, 225);

        /// <summary>
        /// Button's Color when mouse moved over.
        /// </summary>
        [Category("Appearance")]
        [Description("Button's COlor when mouse moved over.")]
        [DefaultValue(typeof(Color), "229,241,251")]
        public Color FillColorMouseHover
        {
            get { return fillColorMouseHover; }
            set { fillColorMouseHover = value; UpdateBrushandPen(); Refresh(); }
        }
        private Color fillColorMouseHover = Color.FromArgb(229, 241, 251);

        /// <summary>
        /// Button's Image
        /// </summary>
        [Category("Appearance")]
        [Description("Button's Image")]
        public Image Image
        {
            get { return image; }
            set { image = value; Refresh(); }
        }
        private Image image = null;

        /// <summary>
        /// Space between image, border and text.
        /// </summary>
        [Category("Appearance")]
        [Description("Specific space between image and border. When ButtonStyle is RoundedRectangle, " +
            "space between image circle from border defined by left margin; top and bottom margin is not used." +
            "Right margin specify space between image and text.")]
        public Padding ImageMargin { get; set; }

        #region [ Appearance - Border ]

        /// <summary>
        /// Border line style
        /// </summary>
        [Category("Appearance")]
        [Description("Border line style. [FixedSingle / None]")]
        [DefaultValue(BorderStyle.FixedSingle)]
        public BorderStyle BorderStyle
        {
            get { return borderStyle; }
            set { borderStyle = value; Refresh(); }
        }
        private BorderStyle borderStyle = BorderStyle.FixedSingle;

        /// <summary>
        /// Border line width
        /// </summary>
        [Category("Appearance")]
        [Description("Border line width.")]
        [DefaultValue(1)]
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; UpdateBrushandPen(); Refresh(); }
        }
        private int borderWidth = 1;

        /// <summary>
        /// Border's color
        /// </summary>
        [Category("Appearance")]
        [Description("Border's color.")]
        [DefaultValue(typeof(Color), "173,173,173")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; UpdateBrushandPen(); Refresh(); }
        }
        private Color borderColor = Color.FromArgb(173, 173, 173);

        /// <summary>
        /// Border's color when clicked or focused.
        /// </summary>
        [Category("Appearance")]
        [Description("Border's color when clicked or focused.")]
        [DefaultValue(typeof(Color), "0,120,215")]
        public Color BorderColorActive
        {
            get { return borderColorActive; }
            set { borderColorActive = value; UpdateBrushandPen(); Refresh(); }
        }
        private Color borderColorActive = Color.FromArgb(0, 120, 215);

        /// <summary>
        /// Button style, <see cref="MultiLineButtonStyle"/> 
        /// </summary>
        [Category("Appearance")]
        [Description("Button design style.")]
        [DefaultValue(MultiLineButtonStyle.RoundedRectangle)]
        public MultiLineButtonStyle ButtonStyle
        {
            get { return buttonStyle; }
            set { buttonStyle = value; Refresh(); }
        }
        private MultiLineButtonStyle buttonStyle = MultiLineButtonStyle.RoundedRectangle;

        #endregion

        #region [ Appearance - Titles ]

        /// <summary>
        /// Main Title Text
        /// </summary>
        [Category("Appearance")]
        [Description("Main Title Text")]
        [DefaultValue("Main Title")]
        public string MainTitle
        {
            get { return mainTitle; }
            set { mainTitle = value; Refresh(); }
        }
        private string mainTitle = "Main Title";

        /// <summary>
        /// Subtitle Text
        /// </summary>
        [Category("Appearance")]
        [Description("Subtitle Text")]
        [DefaultValue("Subtitle...")]
        public string Subtitle
        {
            get
            { return subTitle; }
            set { subTitle = value; Refresh(); }
        }
        private string subTitle = "Subtitle...";

        /// <summary>
        /// Show or Hide Subtitle
        /// </summary>
        [Category("Appearance")]
        [Description("Show or Hide Subtitle")]
        [DefaultValue(true)]
        public bool SubtitleVisible
        {
            get { return subTitleVisible; }
            set { subTitleVisible = value; Refresh(); }
        }
        private bool subTitleVisible = true;

        /// <summary>
        /// Configure Font for Main Title
        /// </summary>
        [Category("Appearance")]
        [Description("Define font for MainTitle")]
        public Font MainTitleFont
        {
            get { return mainTitleFont; }
            set { mainTitleFont = value; Refresh(); }
        }
        private Font mainTitleFont;

        /// <summary>
        /// Configure Font for Subtitle
        /// </summary>
        [Category("Appearance")]
        [Description("Define font for Subtitle")]
        public Font SubTitleFont
        {
            get { return subTitleFont; }
            set { subTitleFont = value; Refresh(); }
        }
        private Font subTitleFont;

        /// <summary>
        /// Define spacing between Main Title and Subtitle in pixels.
        /// </summary>
        [Category("Appearance")]
        [Description("Define spacing between Main Title and Subtitle in pixels.")]
        [DefaultValue(1)]
        public int SpacingBetweenTitles
        {
            get { return spacingBetweenTitles; }
            set { spacingBetweenTitles = value; Refresh(); }
        }
        private int spacingBetweenTitles = 1;

        #endregion

        #region [ Disabled Property ]

        /// <summary>
        /// Not Implemented.
        /// </summary>
        [Bindable(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Font Font { get; set; }

        /// <summary>
        /// Not Implemented.
        /// </summary>
        [Bindable(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string Text { get; set; }

        /// <summary>
        /// Not Implemented.
        /// </summary>
        [Bindable(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Image BackgroundImage { get; set; }

        /// <summary>
        /// Not Implemented.
        /// </summary>
        [Bindable(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout { get; set; }

        #endregion

        /// <summary>
        /// Create an instance of <see cref="MultiLineButton"/> 
        /// </summary>
        public MultiLineButton()
        {
            InitializeComponent();
            subTitleFont = new Font("Verdana", (float)6.75);
            mainTitleFont = new Font("Arial", (float)8.25, FontStyle.Regular);
            UpdateBrushandPen();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.DoubleBuffered = true;
            ImageMargin = new Padding(3);
        }

        /// <summary>
        /// Raises the System.Windows.Forms.Control.Paint event.
        /// Draw implementation.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Size mainTitleSize = TextRenderer.MeasureText(MainTitle, MainTitleFont);
            int mainTitleHeight = mainTitleSize.Height;
            int mainTitleWidth = mainTitleSize.Width;

            Size subTitleSize = TextRenderer.MeasureText(Subtitle, SubTitleFont);
            int subTitleHeight = subTitleSize.Height;
            int subTitleWidth = subTitleSize.Width;

            int spaceBetweenTitle = SpacingBetweenTitles;
            PointF mainTitlePosition, subTitlePosition;
            Color fontColor = Enabled ? ForeColor : Color.DimGray;

            Rectangle drawRegion = GetDrawRectangle();
            Rectangle arcStart = new Rectangle(drawRegion.Left, drawRegion.Top, drawRegion.Height, drawRegion.Height);
            Rectangle arcEnd = new Rectangle(drawRegion.Right - drawRegion.Height, drawRegion.Top, drawRegion.Height, drawRegion.Height);
            Rectangle centerRegion = new Rectangle(drawRegion.Left + (arcStart.Width / 2) - 1, drawRegion.Top, drawRegion.Width - arcStart.Width + 2, drawRegion.Height);
            Rectangle imageRegion, textRegion;
            imageRegion = Rectangle.Empty;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Fill Region
            switch (buttonStyle)
            {
                case MultiLineButtonStyle.Square:
                    e.Graphics.FillRectangle(drawBrush, drawRegion);
                    if (BorderStyle != BorderStyle.None) e.Graphics.DrawRectangle(drawPen, drawRegion);

                    textRegion = drawRegion;
                    if (Image != null)
                    {
                        imageRegion = new Rectangle(ImageMargin.Left, ImageMargin.Top, drawRegion.Height, drawRegion.Height - ImageMargin.Vertical);

                        if (imageRegion.Width > Image.Width)
                        {
                            int dx = (imageRegion.Width - Image.Width);
                            imageRegion.Width -= dx;
                        }

                        if (imageRegion.Height > Image.Height)
                        {
                            int dy = (imageRegion.Height - Image.Height);
                            imageRegion.Height -= dy;
                            imageRegion.Y += (dy / 2);
                        }

                        Rectangle srcImageRegion = new Rectangle((Image.Width - imageRegion.Width) / 2,
                                                                (Image.Height - imageRegion.Height) / 2,
                                                                Math.Min(imageRegion.Width, Image.Width),
                                                                Math.Min(imageRegion.Height, Image.Height));
                        e.Graphics.DrawImage(Image, imageRegion, srcImageRegion, GraphicsUnit.Pixel);
                        textRegion.Offset(imageRegion.Width + ImageMargin.Horizontal, 0);
                    }
                    else
                    {
                        textRegion.Offset(5, 0);
                    }

                    break;

                default: //RoundedRectangle
                    e.Graphics.FillPie(drawBrush, arcStart, 90, 180);
                    e.Graphics.FillPie(drawBrush, arcEnd, 90, -180);
                    e.Graphics.FillRectangle(drawBrush, centerRegion);

                    if (BorderStyle != BorderStyle.None)
                    {
                        e.Graphics.DrawArc(drawPen, arcStart, 90, 180);
                        e.Graphics.DrawArc(drawPen, arcEnd, 90, -180);
                        e.Graphics.DrawLine(drawPen, new Point(centerRegion.Left, centerRegion.Top), new Point(centerRegion.Right, centerRegion.Top));
                        e.Graphics.DrawLine(drawPen, new Point(centerRegion.Left, centerRegion.Bottom), new Point(centerRegion.Right, centerRegion.Bottom));

                    }

                    //NOTE: Text Position calculated from top left.
                    textRegion = centerRegion;
                    if (Image != null)
                    {
                        imageRegion = new Rectangle(ImageMargin.Left, ImageMargin.Left, drawRegion.Height, drawRegion.Height - (2 * ImageMargin.Left));

                        if (imageRegion.Width > Image.Width)
                        {
                            int dx = (imageRegion.Width - Image.Width);
                            imageRegion.Width -= dx;
                            imageRegion.X += (dx / 2);
                        }

                        if (imageRegion.Height > Image.Height)
                        {
                            int dy = (imageRegion.Height - Image.Height);
                            imageRegion.Height -= dy;
                            imageRegion.Y += (dy / 2);
                        }

                        Rectangle srcImageRegion = new Rectangle((Image.Width - imageRegion.Width) / 2,
                                                                (Image.Height - imageRegion.Height) / 2,
                                                                Math.Min(imageRegion.Width, Image.Width),
                                                                Math.Min(imageRegion.Height, Image.Height));

                        textRegion = drawRegion;
                        textRegion.Offset(imageRegion.Width + imageRegion.Left + ImageMargin.Right, 0);

                        //Draw image in circle
                        var path = new System.Drawing.Drawing2D.GraphicsPath();
                        path.AddEllipse(imageRegion);
                        e.Graphics.SetClip(path);
                        e.Graphics.DrawImage(Image, imageRegion, srcImageRegion, GraphicsUnit.Pixel);
                        e.Graphics.ResetClip();
                    }
                    break;
            }

            if (SubtitleVisible)
            {
                mainTitlePosition = new PointF(textRegion.Left, textRegion.Top + (textRegion.Height - MainTitleFont.Height - SubTitleFont.Height - spaceBetweenTitle) / 2);
                subTitlePosition = new PointF(mainTitlePosition.X, mainTitlePosition.Y + mainTitleHeight + spaceBetweenTitle);
                e.Graphics.DrawString(Subtitle, SubTitleFont, new SolidBrush(fontColor), subTitlePosition);
            }
            else
            {
                mainTitlePosition = new PointF(textRegion.Left, textRegion.Top + (textRegion.Height - MainTitleFont.Height) / 2);
            }
            e.Graphics.DrawString(MainTitle, MainTitleFont, new SolidBrush(fontColor), mainTitlePosition);
            base.OnPaint(e);
        }

        private Rectangle GetDrawRectangle()
        {
            return new Rectangle(
                ClientRectangle.Left + Padding.Left + 1, //Another 1 pixel on left and right for smooth rounding
                ClientRectangle.Top + Padding.Top,
                ClientRectangle.Right - Padding.Right - Padding.Left - 3, //Offset 1 pixel from right and bottom for border
                ClientRectangle.Bottom - Padding.Bottom - Padding.Top - 1);
        }

        private bool mouseDown = false;
        private bool mousePresent = false;
        private Brush drawBrush;
        private int drawBorderWidth;
        private Pen drawPen;

        private void UpdateBrushandPen()
        {
            Color brushColor = FillColor;
            Color penColor = BorderColor;
            drawBorderWidth = BorderWidth;

            if (!Enabled)
            {
                brushColor = Color.Silver;
                penColor = Color.Gray;
            }
            else if (mousePresent)
            {
                penColor = borderColorActive;
                brushColor = mouseDown ? Color.FromArgb(204, 228, 247) : fillColorMouseHover;
            }

            if (Focused)
            {
                drawBorderWidth += 1;
                penColor = borderColorActive;
            }

            //Default Settings
            drawBrush = new SolidBrush(brushColor);
            drawPen = new Pen(penColor, drawBorderWidth);
        }

        /// <summary>
        /// Raises the System.Windows.Forms.Control.PaddingChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            Refresh();
        }

        /// <summary>
        ///  Raises the System.Windows.Forms.Control.MouseEnter event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            mousePresent = true;
            UpdateBrushandPen();
            base.OnMouseEnter(e);
            Refresh();
        }

        /// <summary>
        ///  Raises the System.Windows.Forms.Control.MouseLeave event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            mousePresent = false;
            UpdateBrushandPen();
            base.OnMouseLeave(e);
            Refresh();
        }

        /// <summary>
        /// Raises the System.Windows.Forms.Control.EnabledChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            UpdateBrushandPen();
            Refresh();
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// Raises the System.Windows.Forms.Control.MouseDown event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseDown = true;
            UpdateBrushandPen();
            Refresh();
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the System.Windows.Forms.Control.MouseUp event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseDown = false;
            UpdateBrushandPen();
            Refresh();
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the System.Windows.Forms.Control.LostFocus event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            UpdateBrushandPen();
            Refresh();
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Raise the System.Windows.Forms.Controls.GotFocus event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(EventArgs e)
        {
            UpdateBrushandPen();
            Refresh();
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Raise the System.Windows.Forms.Controls.Click event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            Focus();
            UpdateBrushandPen();
            Refresh();
            base.OnClick(e);
        }

    }
}
