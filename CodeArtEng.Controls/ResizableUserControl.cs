using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// User Control with runtime resize capability
    /// </summary>
    public partial class ResizableUserControl : UserControl
    {
        /// <summary>
        /// Dummy client panel added during resize operation to disable interaction to client controls.
        /// </summary>
        internal class ClientPanel : Panel
        {
            public ClientPanel()
            {
                BorderStyle = BorderStyle.FixedSingle;
            }

            public int Opacity { get; set; } = 200;
            const int WS_EX_TRANSPARENT = 0x20;
            protected override CreateParams CreateParams
            {
                get
                {
                    var cp = base.CreateParams;
                    cp.ExStyle |= WS_EX_TRANSPARENT;

                    return cp;
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
            }

        }

        /// <summary>
        /// Grip control type. Internal used only
        /// </summary>
        internal enum GripType
        {
            Center,
            Top,
            Bottom,
            Left,
            Right
        }

        /// <summary>
        /// Resize control
        /// </summary>
        internal class ResizableControlGrip : Panel
        {
            private UserControl Owner;
            private Cursor BackupCursor;
            private GripType GripType;
            private Action<MouseEventArgs> MouseAction = null;

            public ResizableControlGrip(UserControl sender, GripType gripType, int gripSize)
            {
                Owner = sender;
                GripType = gripType;
                Size = new Size(gripSize, gripSize);
                BorderStyle = BorderStyle.FixedSingle;
                BackColor = Color.White;

                switch (GripType)
                {
                    case GripType.Center:
                        Cursor = Cursors.SizeAll;
                        break;
                    case GripType.Top:
                    case GripType.Bottom:
                        Cursor = Cursors.SizeNS;
                        break;
                    case GripType.Left:
                    case GripType.Right:
                        Cursor = Cursors.SizeWE;
                        break;
                }
            }


            #region [ Mouse Events ]

            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                switch (GripType)
                {
                    case GripType.Center: MouseAction = MouseMoveControl; break;
                    case GripType.Top: MouseAction = MouseSizeTop; break;
                    case GripType.Bottom: MouseAction = MouseSizeBottom; break;
                    case GripType.Left: MouseAction = MouseSizeLeft; break;
                    case GripType.Right: MouseAction = MouseSizeRight; break;
                }
            }
            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                MouseAction = null;
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                MouseAction?.Invoke(e);
            }

            #endregion

            #region [ Mouse Actions ]

            private void MouseMoveControl(MouseEventArgs e)
            {
                Owner.Location = new Point(Owner.Location.X + e.X, Owner.Location.Y + e.Y);
            }

            private void MouseSizeTop(MouseEventArgs e)
            {
                Owner.Location = new Point(Owner.Location.X, Owner.Location.Y + e.Y);
                Owner.Size = new Size(Owner.Width, Owner.Height - e.Y);
            }

            private void MouseSizeBottom(MouseEventArgs e)
            {
                Owner.Size = new Size(Owner.Width, Owner.Height + e.Y);
            }

            private void MouseSizeLeft(MouseEventArgs e)
            {
                Owner.Location = new Point(Owner.Location.X + e.X, Owner.Location.Y);
                Owner.Size = new Size(Owner.Width - e.X, Owner.Height);
            }

            private void MouseSizeRight(MouseEventArgs e)
            {
                Owner.Size = new Size(Owner.Width + e.X, Owner.Height);
            }

            #endregion

        }

        public ResizableUserControl()
        {
            InitializeComponent();
        }

        private List<Panel> InternalControls = null;
        private Panel CenterGrip, TopGrip, BottomGrip, LeftGrip, RightGrip;
        private ClientPanel Client;

        private void CreateInternalControls()
        {
            if (InternalControls != null) return;
            InternalControls = new List<Panel>
            {
                (Client = new ClientPanel()),
                (CenterGrip = new ResizableControlGrip(this, GripType.Center, ResizeGripControl)),
                (LeftGrip =new ResizableControlGrip(this, GripType.Left, ResizeGripControl)),
                (RightGrip =new ResizableControlGrip(this, GripType.Right, ResizeGripControl)),
                (TopGrip =new ResizableControlGrip(this, GripType.Top, ResizeGripControl)),
                (BottomGrip =new ResizableControlGrip(this, GripType.Bottom, ResizeGripControl)),

            };
            Controls.AddRange(InternalControls.ToArray());
            foreach (Control c in InternalControls) Controls.SetChildIndex(c, 0);
            
            UpdateControl();
        }
        private void DisposeInternalControls()
        {
            if (InternalControls == null) return;
            foreach (Control c in InternalControls) Controls.Remove(c);
            InternalControls.Clear();
            InternalControls = null;
            UpdateControl();
        }

        /// <summary>
        /// Enter runtime resize mode
        /// </summary>
        public void BeginResize()
        {
            CreateInternalControls();
        }
        /// <summary>
        /// End runtime resize mode
        /// </summary>
        public void EndResize()
        {
            DisposeInternalControls();
        }
        /// <summary>
        /// Grip control size
        /// </summary>
        public int ResizeGripControl { get; set; } = 7;

        private void UpdateControl()
        {
            if (InternalControls != null)
            {
                Client.Location = new Point(-1, -1);
                Client.Size = new Size(Width, Height);
                CenterGrip.Location = new Point((Width - CenterGrip.Width) / 2, (Height - CenterGrip.Height) / 2);
                TopGrip.Location = new Point((Width - TopGrip.Width) / 2, -1);
                BottomGrip.Location = new Point((Width - BottomGrip.Width) / 2, Height - BottomGrip.Height - 1);
                LeftGrip.Location = new Point(-1, (Height - LeftGrip.Height) / 2);
                RightGrip.Location = new Point(Width - RightGrip.Width - 1, (Height - LeftGrip.Height) / 2);
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateControl();
        }
    }
}
