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
    public sealed partial class Main : Page
    {
        public NavigationContext context { get; set; }
        public Main()
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

            user.Text = context.UserContext.FirstName;
        }

        private void list_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(List), context);
        }

        private void newnote_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewNote), context);

            //ServiceCalls.TestPost();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListDelete), context);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditList), context);
        }
    }
}
