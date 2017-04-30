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

            PageParent = NotOv;
        }

        async void StartEditing(object sender, EventArgs e)
        {
            await PageParent.Navigation.PushAsync(new NotePage(this));
        }



        public Button getPlay() { return Play; }
        public Editor getEditingSpace() { return EditingSpace; }
    }
}
