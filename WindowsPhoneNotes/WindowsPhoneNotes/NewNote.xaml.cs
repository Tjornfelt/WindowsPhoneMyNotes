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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WindowsPhoneNotes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewNote : Page
    {
        public NavigationContext context { get; set; }
        public NewNote()
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
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Main), context);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            var result = ServiceCalls.CreateNote(context.UserContext.UserName, context.UserContext.Password, title.Text);

            if (result)
            {
                NoteNavigationContext nnc = new NoteNavigationContext()
                {
                    NoteHeader = title.Text,
                    NoteBody = "", //The note is empty by default...no need to fetch anything just yet
                    UserContext = context.UserContext
                };

                Frame.Navigate(typeof(EditNote), nnc);
            }
        }
    }
}
