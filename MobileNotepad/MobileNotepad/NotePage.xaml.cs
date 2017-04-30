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
        private Editor edit;

        public NotePage(Note DtPtr)
        {
            InitializeComponent();

            DataPointer = DtPtr;

            string txt = String.Empty;
            for (int i = 0; i < 200; i++)
                txt += "hehheeee";

            var stack = new StackLayout();
            edit = new Editor { VerticalOptions = LayoutOptions.FillAndExpand };
            edit.TextChanged += inc;
            edit.Completed += comp;
            stack.Children.Add( DataPointer.getEditingSpace() );
            Content = new ScrollView { Content = stack };
        }

        void inc(object sender, EventArgs e)
        {
            edit.HeightRequest = 1;
        }

        void comp(object sender, EventArgs e)
        {
            var stack = new StackLayout();
            stack.Children.Add(new Button { Text = "zal" });
            Content = new ScrollView { Content = stack };
        }
    }
}
