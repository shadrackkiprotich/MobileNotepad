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
        private StackLayout NoteStack;
        private List<Note> Notes;

        private Button AddNote;
        private Button DeleteNote;
        private bool DeleteNoteState;     //Edit or deleting

        public NotesOverview()
        {
            InitializeComponent();
           
            NoteStack = new StackLayout();
            Notes = new List<Note>();

            //Add Note Button
            AddNote = new Button
            {
                Text = "Add Note"
            };
            AddNote.Clicked += ClickAddNote;

            DeleteNote = new Button
            {
                Text = "Delete Notes"
            };
            DeleteNote.Clicked += ClickDeleteButton;
            DeleteNoteState = true;

            NoteStack.Children.Add(AddNote);
            NoteStack.Children.Add(DeleteNote);

            Content = new ScrollView { Content = NoteStack };
        }
       
        void ClickAddNote(object sender, EventArgs e)
        {
            var NewNote = new Note(this);
            Notes.Add(NewNote);
            
            NoteStack.Children.Add(NewNote.getPlayButton());
            Content = new ScrollView { Content = NoteStack };

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
            RefreshScreen();
        }

        void RefreshScreen()
        {
            NoteStack = new StackLayout();
            NoteStack.Children.Add(AddNote);
            NoteStack.Children.Add(DeleteNote);
            foreach (Note x in Notes)
            {
                 NoteStack.Children.Add(x.getPlayButton());
            }
            Content = new ScrollView { Content = NoteStack };
        }

        public bool getDeleteState() { return DeleteNoteState; }
    }
}
