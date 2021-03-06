﻿using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Facebook;
using FaceSharp.Samples.WinForm;


namespace FacebookingTest
{
    public partial class Authorize : Form
    {
        public Authorize()
        {
            InitializeComponent();

        }

        public string ApplicationId
        {
            get
            {
                return ConfigurationManager.AppSettings["ApplicationId"];
            }
        }

        public string ExtendedPermissions
        {
            get
            {
                return ConfigurationManager.AppSettings["ExtendedPermissions"];
            }
        }

        public string AppSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["ApplicationSecret"];
            }
        }

        static public string AccessToken { get; set; }

        private void LoadAuthorize(object sender, EventArgs e)
        {
            var destinationURL = String.Format(
                @"https://www.facebook.com/dialog/oauth?client_id={0}&scope={1}&redirect_uri=http://www.facebook.com/connect/login_success.html&response_type=token",
                this.ApplicationId,
                this.ExtendedPermissions);
            webBrowser.Navigated += WebBrowserNavigated;
            webBrowser.Navigate(destinationURL);
        }

        private void WebBrowserNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // get token
            var url = e.Url.Fragment;
            if (url.Contains("access_token") && url.Contains("#"))
            {
                this.Hide();
                url = (new Regex("#")).Replace(url, "?", 1);
                AccessToken = System.Web.HttpUtility.ParseQueryString(url).Get("access_token");
                MessageBox.Show("Connected");
                 Get_Likes_Form get_Likes = new Get_Likes_Form();
                 get_Likes.Show();


            }

        }
    
     
    
    }
}

