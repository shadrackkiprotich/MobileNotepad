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
                Text="Edit"
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
            EditingSpace.TextChanged += Increase;

            PageParent = NotOv;
        }

        async void StartEditing(object sender, EventArgs e)
        {
            await PageParent.Navigation.PushAsync(new NotePage(this));
        }

        void Increase(object sender, EventArgs e)
        {

        }

        public void SetToDelete()
        {
            Play.Clicked -= StartEditing;
            Play.Clicked += Delete;
        }

        void Delete(object sender, EventArgs e)
        {
            PageParent.deleteNote(this);
            
        }

        

        public Button getPlayButton() { return Play; }
        public Editor getEditingSpace() { return EditingSpace; }
    }
}
