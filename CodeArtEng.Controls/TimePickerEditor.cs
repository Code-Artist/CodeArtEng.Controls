using System;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// <para>Time Picker Editor for <see cref="PropertyGrid"/></para> 
    /// <para>Usage: Add attributes [Editor(typeof(TimePickerEditor), typeof(UITypeEditor))] object's property to activate this control.</para>
    /// </summary>
    public class TimePickerEditor : UITypeEditor, IDisposable
    {
        IWindowsFormsEditorService editorService;
        DateTimePicker picker = new DateTimePicker();
        string CurrentDateTimeFormat;

        /// <summary>
        /// Create TimePicker Editor Control.
        /// </summary>
        public TimePickerEditor()
        {
            picker.Format = DateTimePickerFormat.Custom;
            DateTimeFormatInfo tInfo = CultureInfo.CurrentCulture.DateTimeFormat;
            CurrentDateTimeFormat = tInfo.ShortDatePattern + " " + tInfo.ShortTimePattern;
            picker.CustomFormat = CurrentDateTimeFormat;
            picker.ShowUpDown = true;
        }

        /// <summary>
        /// Edit value
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                this.editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            }
            if (this.editorService != null)
            {
                DateTime dateTimeValue = (DateTime)value;
                DateTime tNow = RoundDown(DateTime.Now, TimeSpan.FromMinutes(1));
                if (dateTimeValue == null) picker.Value = tNow;
                else if ((dateTimeValue < picker.MinDate) || (dateTimeValue > picker.MaxDate)) picker.Value = tNow;
                else picker.Value = dateTimeValue;

                this.editorService.DropDownControl(picker);
                value = RoundDown(picker.Value, TimeSpan.FromMinutes(1));
            }
            return value;
        }

        /// <summary>
        /// Override <see cref="UITypeEditorEditStyle"/> as <see cref="UITypeEditorEditStyle.DropDown"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
        }

        DateTime RoundDown(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks / d.Ticks) * d.Ticks);
        }

        #region [ Dispose Pattern ]
        /// <summary>
        /// Manually dispose instance.
        /// </summary>
        public void Dispose()
        {
            //Do not modify
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            //Do not modify
            ReleaseUnmanagedResources();
            if (disposing) ReleaseManagedResources();
        }
        /// <summary>
        /// Dispose function. Release manage resources.
        /// </summary>
        protected virtual void ReleaseManagedResources()
        {
            //Release unamanged resources
        }
        /// <summary>
        /// Dispose function. Release unmanaged resources.
        /// </summary>
        protected virtual void ReleaseUnmanagedResources()
        {
            //Release managed resources
            picker.Dispose();
            picker = null;
        }
        #endregion  
    }
}
