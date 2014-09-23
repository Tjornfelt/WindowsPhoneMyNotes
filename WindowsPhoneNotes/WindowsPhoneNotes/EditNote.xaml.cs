﻿using System;
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
    public sealed partial class EditNote : Page
    {
        public NoteNavigationContext context { get; set; }
        public EditNote()
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
            context = (NoteNavigationContext)e.Parameter;

            noteheader.Text = context.NoteHeader;
            notebody.Text = context.NoteBody;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Main), (NavigationContext)context);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (ServiceCalls.UpdateNote(context.UserContext.UserName, context.UserContext.Password, noteheader.Text, notebody.Text))
            {
                Frame.Navigate(typeof(Main), (NavigationContext)context);
            }
        }
    }
}
