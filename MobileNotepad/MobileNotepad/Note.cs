using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileNotepad
{
    public class Note
    {
        private String Text;
        private Button Play;
        private Label Short;
        private Editor EditingSpace;
        private NotesOverview PageParent;

        public Note(NotesOverview NotOv)
        {
            Text = String.Empty;

            Play = new Button
            {
                Text="Empty"
            };
            Play.Clicked += StartEditing;


            Short = new Label
            {
                Text = String.Empty
            };

            EditingSpace = new Editor
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            EditingSpace.Completed += EditingCompleted;

            PageParent = NotOv;
        }

        async void StartEditing(object sender, EventArgs e)
        {
            await PageParent.Navigation.PushAsync(new NotePage(this));
        }
        

        public void SetToDelete()
        {
            Play.Clicked -= Delete;
            Play.Clicked -= StartEditing;
            Play.Clicked += Delete;
        }

        public void SetToEdit()
        {
            Play.Clicked -= StartEditing;
            Play.Clicked -= Delete;
            Play.Clicked += StartEditing;
        }

        void Delete(object sender, EventArgs e)
        {
            PageParent.RemoveNote(this);
        }

        void EditingCompleted(object sender, EventArgs e)
        {
            Text = EditingSpace.Text;
            String tmp = String.Empty;

            bool isLonger = true;
            for (int i=0;i <20; i++)
            {
                if (i >= Text.Length)
                {
                    isLonger = false;
                    break;
                }
                tmp += Text[i];
            }
            if (isLonger)
                tmp += "...";
            Play.Text = tmp;
        }

        public Button getPlayButton() { return Play; }
        public Editor getEditingSpace() { return EditingSpace; }
    }
}
