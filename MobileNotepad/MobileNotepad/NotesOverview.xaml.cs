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
    public partial class NotesOverview : ContentPage
    {
        private List<Note> Notes;
        private bool DeleteNoteState;     //Edit or deleting

        public NotesOverview()
        {
            InitializeComponent();
           
            Notes = new List<Note>();

            DeleteNoteState = true;
        }
       
        void ClickAddNote(object sender, EventArgs e)
        {
            var NewNote = new Note(this);
            Notes.Add(NewNote);
            
            NoteStack.Children.Add(NewNote.getPlayButton());
            
            NewNote.StartEditing(sender, e);
            foreach (Note x in Notes)
            {
                x.SetToEdit();
            }
            DeleteNote.Text = "Delete Notes";
            DeleteNoteState = true;
        }

        void ClickDeleteButton(object sender, EventArgs e)
        {
            if (DeleteNoteState == true)
            {
                DeleteNoteState = false;
                foreach (Note x in Notes)
                {
                    x.SetToDelete();
                }
                DeleteNote.Text = "Edit Notes";
            }
            else
            {
                DeleteNoteState = true;
                foreach (Note x in Notes)
                {
                    x.SetToEdit();
                }
                DeleteNote.Text = "Delete Notes";
            }
        }

        public void RemoveNote(Note del)
        {
            Notes.Remove(del);
            NoteStack.Children.Remove(del.getPlayButton());
         }       

        public bool getDeleteState() { return DeleteNoteState; }
    }
}
