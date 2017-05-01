using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileNotepad
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {
        private Note DataPointer;

        public NotePage(Note DtPtr)
        {
            InitializeComponent();

            DataPointer = DtPtr;

            string txt = String.Empty;
            for (int i = 0; i < 200; i++)
                txt += "hehheeee";

            edit.Text = DataPointer.getText();
        }

        void EditingCompleted(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edit.Text))
                return;

            DataPointer.setText(edit.Text);
            String shorttext = String.Empty;

            bool isLonger = true;
            for (int i = 0; i < 20; i++)
            {
                if (i >= edit.Text.Length)
                {
                    isLonger = false;
                    break;
                }
                if (edit.Text[i] == '\n')
                    shorttext += ' ';
                else
                    shorttext += edit.Text[i];
            }
            if (isLonger)
                shorttext += "...";
            DataPointer.setPlayButton(shorttext);
        }
    }
}
