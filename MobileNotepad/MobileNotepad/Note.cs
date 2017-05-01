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
        private String Short;
        private NotesOverview PageParent;

        public Note(NotesOverview NotOv)
        {
            Text = String.Empty;

            Play = new Button
            {
                Text="Empty"
            };
            Play.Clicked += StartEditing;
            
            Short = String.Empty;

            PageParent = NotOv;
        }

        public async void StartEditing(object sender, EventArgs e)
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

        async void Delete(object sender, EventArgs e)
        {
            if (await PageParent.DisplayAlert("Warning!", "Are you sure you want to delete \"" + Short + "\"Note?", "Yes", "No"))
                PageParent.RemoveNote(this);
        }
        
        public Button getPlayButton() { return Play; }
        public String getText() { return Text; }

        public void setText(String arg) { Text = arg; }
        public void setPlayButton(String arg) { Play.Text = arg; }
    }
}
