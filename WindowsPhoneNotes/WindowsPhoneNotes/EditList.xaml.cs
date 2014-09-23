using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsPhoneNotes.Classes;
using WindowsPhoneNotes.Classes.DataModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WindowsPhoneNotes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditList : Page
    {
        public NavigationContext context { get; set; }
        public List<Note> notes { get; set; }
        public EditList()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            context = (NavigationContext)e.Parameter;

            //Get the lists from the database
            notes = ServiceCalls.GetNotes(context.UserContext.UserName, context.UserContext.Password);

            foreach (var item in notes)
            {
                //add the lists to the listview as listviewitems
                ListViewItem lvi = new ListViewItem()
                {
                    Content = item.Name,
                    FontSize = 32
                };
                listview.Items.Add(lvi);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Main), context);
        }

        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var si = (ListViewItem)listview.SelectedItem;
            var name = si.Content;
            var selectedNote = notes.FirstOrDefault(x => x.Name == name.ToString());

            NoteNavigationContext nnc = new NoteNavigationContext()
            {
                NoteHeader = selectedNote.Name,
                NoteBody = selectedNote.Content,
                UserContext = context.UserContext

            };

            Frame.Navigate(typeof(EditNote), nnc);
        }
    }
}
