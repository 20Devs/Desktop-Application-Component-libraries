﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Janus.Windows.GridEX.EditControls;
using MS_Control.CustomCombo;


namespace MS_Control.Controls
{
    [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public partial class MS_Janus_Custom_Combo : Janus.Windows.GridEX.EditControls.EditBox, MS_Control.CustomCombo.IPopupControlHost
    {
        #region فیلد
        private PopupControl m_popupCtrl = new PopupControl();
        System.Windows.Forms.Control m_dropDownCtrl;
        bool m_bDroppedDown = false;
        private CustomComboBox.SizeMode m_sizeMode;// = CustomComboBox.SizeMode.MS_Size;
        DateTime m_lastHideTime = DateTime.Now;
        Timer m_timerAutoFocus;
        Size m_sizeOriginal = new Size(1, 1);
        Size m_sizeCombo;
        bool m_bIsResizable = false, DroppedDown = false;
        #endregion
        #region Properties
        [Browsable(false)]
        public System.Windows.Forms.Control DropDownControl
        {
            get { return m_dropDownCtrl; }
            set { AssignControl(value); }
        }
        [Browsable(false)]
        public bool IsDroppedDown
        {
            get { return this.m_bDroppedDown /*&& m_popupCtrl.Visible*/; }
        }
        [Category("Custom Drop-Down"), Description("Indicates if drop-down is resizable.")]
        public bool AllowResizeDropDown
        {
            get { return this.m_bIsResizable; }
            set { this.m_bIsResizable = value; }
        }
        [Category("Custom Drop-Down"), Description("Indicates current sizing mode.")/*, DefaultValue(CustomComboBox.SizeMode.UseControlSize)*/]
        public CustomComboBox.SizeMode DropDownSizeMode
        {
            get { return this.m_sizeMode; }
            set
            {
                //if (value != this.m_sizeMode)
                {
                    this.m_sizeMode = value;
                    AutoSizeDropDown();
                }
            }
        }

        [Category("Custom Drop-Down")]
        public Size DropSize
        {
            get { return m_sizeCombo; }
            set
            {
                m_sizeCombo = value;
                if (DropDownSizeMode == CustomComboBox.SizeMode.UseDropDownSize)
                    AutoSizeDropDown();
            }
        }

        [Category("Custom Drop-Down"), Browsable(false)]
        public Size ControlSize
        {
            get { return m_sizeOriginal; }
            set
            {
                m_sizeOriginal = value;
                if (DropDownSizeMode == CustomComboBox.SizeMode.UseControlSize)
                    AutoSizeDropDown();
            }
        }

        #endregion
        #region Win32 message handlers

        public const uint WM_COMMAND = 0x0111;
        public const uint WM_USER = 0x0400;
        public const uint WM_REFLECT = WM_USER + 0x1C00;
        public const uint WM_LBUTTONDOWN = 0x0201;

        public const uint CBN_DROPDOWN = 7;
        public const uint CBN_CLOSEUP = 8;

        public static uint HIWORD(int n)
        {
            return (uint)(n >> 16) & 0xffff;
        }
        public override bool PreProcessMessage(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                if (HIWORD((int)m.WParam) == CBN_DROPDOWN)
                    return false;
            }
            return base.PreProcessMessage(ref m);
        }

        private static DateTime m_sShowTime = DateTime.Now;

        private void AutoDropDown()
        {
            if (m_popupCtrl != null && m_popupCtrl.Visible)
                HideDropDown();
            else if ((DateTime.Now - m_lastHideTime).Milliseconds > 50)
                ShowDropDown();
        }

        #endregion
        #region Methods

        /// <summary>
        /// Automatically resize drop-down from properties.
        /// </summary>
        public void AutoSizeDropDown()
        {
            if (DropDownControl != null)
            {
                switch (DropDownSizeMode)
                {
                    case CustomComboBox.SizeMode.UseComboSize:
                        DropDownControl.Size = new Size(Width, m_sizeCombo.Height);
                        break;

                    case CustomComboBox.SizeMode.MS_Middle_Size:
                    case CustomComboBox.SizeMode.UseControlSize:
                        DropDownControl.Size = new Size(m_sizeOriginal.Width, m_sizeOriginal.Height);
                        break;

                    case CustomComboBox.SizeMode.UseDropDownSize:
                        DropDownControl.Size = m_sizeCombo;
                        break;
                    case CustomComboBox.SizeMode.MS_Size:
                        DropDownControl.Size = new Size(Width, m_sizeOriginal.Height);
                        break;
                }
            }
        }
        /// <summary>
        /// Assigns control to custom drop-down area of combo box.
        /// </summary>
        /// <param name="control">Control to be used as drop-down. Please note that this control must not be contained elsewhere.</param>
        public void AssignControl(System.Windows.Forms.Control control)
        {
            // If specified control is different then...
            if (control != DropDownControl)
            {
                // Preserve original container size.
                m_sizeOriginal = control.Size;

                // Reference the user-specified drop down control.
                m_dropDownCtrl = control;
            }
        }

        #endregion
        #region IPopupControlHost Members
        /// <summary>
        /// Displays drop-down area of combo box, if not already shown.
        /// </summary>
        public virtual void ShowDropDown()
        {
            if (m_popupCtrl != null && !IsDroppedDown)
            {
                // Raise drop-down event.
                RaiseDropDownEvent();

                // Restore original control size.
                AutoSizeDropDown();


                int w = Width - (this.DropDownControl == null ? 0 : this.DropDownControl.Width);

                w = w > 0 ? Width - m_dropDownCtrl.Width - 2 : w;

                Point location = PointToScreen(new Point(w, Height));

                if (DropDownSizeMode == CustomComboBox.SizeMode.MS_Middle_Size)
                {
                    var azaf = Math.Abs((Width - (this.DropDownControl == null ? 0 : this.DropDownControl.Width)) / 2);
                    location = PointToScreen(new Point(w + azaf, Height));
                }
                PopupResizeMode resizeMode = PopupResizeMode.None;

                m_popupCtrl.Show(this.DropDownControl, location.X, location.Y, 
                    m_dropDownCtrl.Width, m_dropDownCtrl.Height, resizeMode);
                m_bDroppedDown = true;
                m_popupCtrl.PopupControlHost = this;
                if (m_timerAutoFocus == null)
                {
                    m_timerAutoFocus = new Timer();
                    m_timerAutoFocus.Interval = 5;
                    m_timerAutoFocus.Tick += new EventHandler(timerAutoFocus_Tick);
                }
                m_timerAutoFocus.Enabled = true;
                m_sShowTime = DateTime.Now;
            }
        }
        /// <summary>
        /// Hides drop-down area of combo box, if shown.
        /// </summary>
        public virtual void HideDropDown()
        {
            if (m_popupCtrl != null && IsDroppedDown)
            {
                // Hide drop-down control.
                m_popupCtrl.Hide();
                m_bDroppedDown = false;

                // Disable automatic focus timer.
                if (m_timerAutoFocus != null && m_timerAutoFocus.Enabled)
                    m_timerAutoFocus.Enabled = false;

                // Raise drop-down closed event.
                RaiseDropDownClosedEvent();
                try
                {
                    var frm = this.FindForm();
                    if (frm != null)
                        frm.Activate();
                }
                catch
                {
                }
                this.Focus();

            }
        }

        #endregion
        #region Events

        public static new event EventHandler DropDown;
        public new event EventHandler DropDownClosed;

        public new event OldNewEventHandler<object> SelectedValueChanged;

        public void RaiseDropDownEvent()
        {
            EventHandler eventHandler = MS_Janus_Custom_Combo.DropDown;
            if (eventHandler != null)
                MS_Janus_Custom_Combo.DropDown(this, EventArgs.Empty);
        }

        public void RaiseDropDownClosedEvent()
        {
            EventHandler eventHandler = this.DropDownClosed;
            if (eventHandler != null)
                this.DropDownClosed(this, EventArgs.Empty);
        }

        public void RaiseSelectedValueChangedEvent(object oldValue, object newValue)
        {
            OldNewEventHandler<object> eventHandler = this.SelectedValueChanged;
            if (eventHandler != null)
                this.SelectedValueChanged(this, new OldNewEventArgs<object>(oldValue, newValue));
        }
        #endregion
        #region Event handlers
        private void timerAutoFocus_Tick(object sender, EventArgs e)
        {
            if (m_popupCtrl.Visible && !DropDownControl.Focused)
            {
                DropDownControl.Focus();
                m_timerAutoFocus.Enabled = false;
            }

            if (DroppedDown)
                DroppedDown = false;
        }
        #endregion
        //==================================================
        #region فیلد
        Color _Back_Color;
        bool _Do_Popup = false;
        private Color _borderColor = Color.Silver, _old_border_color;
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;
        #endregion
        #region پراپرتی
        public bool MS_Exit_By_Enter { get; set; }
        public bool MS_Exit_By_Down { get; set; }
        public bool MS_Exit_By_Up { get; set; }
        public System.Windows.Forms.Control MS_Next_Control { get; set; }
        public System.Windows.Forms.Control MS_Last_Control { get; set; }

        public bool MS_Change_Color_On_Enter { set; get; }
        public Color MS_Enter_Color { get; set; }

        public bool MS_Change_Border_Color_On_Enter { set; get; }
        public Color MS_Enter_Border_Color { get; set; }
        public Color MS_BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate(); // causes control to be redrawn
            }
        }
        public ButtonBorderStyle MS_BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                _borderStyle = value;
                Invalidate();
            }
        }

        public bool MS_Auto_Popup
        {
            get { return _Do_Popup; }
            set { _Do_Popup = value; }
        }
        #endregion
        public MS_Janus_Custom_Combo()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                ControlPaint.DrawBorder(g, bounds, _borderColor, _borderStyle);
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && MS_Exit_By_Down)
            {
                if (MS_Next_Control != null && MS_Next_Control.Enabled && MS_Next_Control.Visible)
                    MS_Next_Control.Focus();
                else
                    SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up && MS_Exit_By_Up)
            {
                if (MS_Last_Control != null && MS_Last_Control.Enabled && MS_Last_Control.Visible)
                    MS_Last_Control.Focus();
                else
                    SendKeys.Send("+{TAB}");
                e.Handled = true;
            }

            base.OnKeyUp(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && MS_Exit_By_Enter)
            {
                if (MS_Next_Control != null && MS_Next_Control.Enabled && MS_Next_Control.Visible)
                    MS_Next_Control.Focus();
                else
                    SendKeys.Send("{TAB}");
                e.Handled = true;
                base.OnKeyPress(e);
                return;
            }
            if (char.IsLetterOrDigit(e.KeyChar) 
                || char.IsSymbol(e.KeyChar) 
                || char.IsWhiteSpace(e.KeyChar))
            {
                ShowDropDown();
                SendKeys.Send(e.KeyChar.ToString());
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            if (MS_Change_Color_On_Enter && MS_Enter_Color != null)
            {
                _Back_Color = this.BackColor;
                this.BackColor = MS_Enter_Color;
            }
            if (MS_Change_Border_Color_On_Enter && MS_Enter_Border_Color != null)
            {
                _old_border_color = MS_BorderColor;
                MS_BorderColor = MS_Enter_Border_Color;
            }
            if (_Do_Popup && !DesignMode)
                ShowDropDown();
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            if (MS_Change_Color_On_Enter && MS_Enter_Color != null)
            {
                this.BackColor = _Back_Color;
            }
            if (MS_Change_Border_Color_On_Enter && MS_Enter_Border_Color != null)
            {
                MS_BorderColor = _old_border_color;
            }
            base.OnLeave(e);
        }
        protected override void OnClick(EventArgs e)
        {
            if (_Do_Popup)
                ShowDropDown();
            base.OnClick(e);
        }

        protected override void OnButtonClick(EditButton editButton)
        {
            base.OnButtonClick(editButton);
            ShowDropDown();
        }
      
    }
}
