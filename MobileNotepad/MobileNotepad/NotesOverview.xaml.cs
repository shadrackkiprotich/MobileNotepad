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
        private StackLayout stack;
        private List<Note> Notes;
        private Button AddNote;

        public NotesOverview()
        {
            InitializeComponent();

            stack = new StackLayout();
            Notes = new List<Note>();

            //Add Note Button
            AddNote = new Button
            {
                Text = "Add Note"
            };
            AddNote.Clicked += ClickAddNote;
            stack.Children.Add(AddNote);
            Content = new ScrollView { Content = stack };
        }
       
        void ClickAddNote(object sender, EventArgs e)
        {
            var NewNote = new Note(this);
            Notes.Add(NewNote);
            stack.Children.Add(NewNote.getPlay());
            Content = new ScrollView { Content = stack };
        }
    }
}
