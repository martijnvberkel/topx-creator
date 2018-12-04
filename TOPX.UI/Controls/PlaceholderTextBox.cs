using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOPX.UI.Controls
{
    public class PlaceHolderTextBox : TextBox
    {

        bool _isPlaceHolder = true;
        string _placeHolderText;
        public string PlaceHolderText
        {
            get => _placeHolderText;
            set
            {
                _placeHolderText = value;
                SetPlaceholder();
            }
        }

        public new string Text
        {
            get => _isPlaceHolder ? string.Empty : base.Text;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    base.Text = value;
                    RemovePlaceHolder();
                }
                else
                {
                    SetPlaceholder();
                }
            }
        }

        //when the control loses focus, the placeholder is shown
        private void SetPlaceholder()
        {
            if (string.IsNullOrEmpty(base.Text))
            {
                base.Text = PlaceHolderText;
                this.ForeColor = Color.Gray;
                this.Font = new Font(this.Font, FontStyle.Italic);
                _isPlaceHolder = true;
            }
        }

        //when the control is focused, the placeholder is removed
        private void RemovePlaceHolder()
        {

            if (_isPlaceHolder)
            {
                base.Text = "";
                this.ForeColor = System.Drawing.SystemColors.WindowText;
                this.Font = new Font(this.Font, FontStyle.Regular);
                _isPlaceHolder = false;
            }
        }
        public PlaceHolderTextBox()
        {
            GotFocus += RemovePlaceHolder;
            LostFocus += SetPlaceholder;
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            SetPlaceholder();
        }

        private void RemovePlaceHolder(object sender, EventArgs e)
        {
            RemovePlaceHolder();
        }
    }
}
