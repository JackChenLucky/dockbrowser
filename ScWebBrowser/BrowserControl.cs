using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ScWebBrowser
{
  partial class BrowserControl : UserControl
  {
    public BrowserControl()
    {
      InitializeComponent();
      _browser = new ExtendedWebBrowser();
      //_browser.ScriptErrorsSuppressed = true;
      _browser.Quit += new EventHandler(_browser_Quit);
      _browser.Dock = DockStyle.Fill;
      _browser.DownloadComplete += new EventHandler(_browser_DownloadComplete);
      _browser.Navigated += new WebBrowserNavigatedEventHandler(_browser_Navigated);
      _browser.StartNewWindow += new EventHandler<BrowserExtendedNavigatingEventArgs>(_browser_StartNewWindow);
      _browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(_browser_DocumentCompleted);
      this.containerPanel.Controls.Add(_browser);
      
      // Make the magenta color transparent on the go button
      Bitmap bmp = (Bitmap)goButton.Image;
      bmp.MakeTransparent(Color.Magenta);
      panel2.Visible = Global.sysConfig.WindowConfig.Toolbar;
    }

      void _browser_Quit(object sender, EventArgs e)
      {
          frmWebBrowser fwb = (this.Tag as frmWebBrowser);
          if (fwb != null)
              fwb.Close();
      }


    void _browser_DownloadComplete(object sender, EventArgs e)
    {
      // Check wheter the document is available (it should be)
      if (this.WebBrowser.Document != null)
      {
        // Subscribe to the Error event
        this._browser.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
        UpdateAddressBox();
      }
    }

    void Window_Error(object sender, HtmlElementErrorEventArgs e)
    {
      // We got a script error, record it
      ScriptErrorManager.Instance.RegisterScriptError(e.Url, e.Description, e.LineNumber);
      // Let the browser know we handled this error.
      e.Handled = true;
    }

    void _browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        _browser.Document.GetElementsByTagName("body")[0].Style += ";overflow:auto;";
        _browser.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
        UpdateAddressBox();
    }

    // Updates the addres box with the actual URL of the document
    private void UpdateAddressBox()
    {
      string urlString = this.WebBrowser.Document.Url.ToString();
      if (!urlString.Equals(this.addressTextBox.Text, StringComparison.InvariantCultureIgnoreCase))
      {
        this.addressTextBox.Text = urlString;
      }
    }

    void _browser_StartNewWindow(object sender, BrowserExtendedNavigatingEventArgs e)
    {
      frmWebBrowser mf = GetMainFormFromControl(sender as Control);
      if (mf == null)
        return;

      // Allow a popup when there is no information available or when the Ctrl key is pressed
      bool allowPopup = (e.NavigationContext == UrlContext.None) || ((e.NavigationContext & UrlContext.OverrideKey) == UrlContext.OverrideKey);

      if (!allowPopup)
      {
        // Give None, Low & Medium still a chance.
        switch (SettingsHelper.Current.FilterLevel)
        {
          case PopupBlockerFilterLevel.None:
            allowPopup = true;
            break;
          case PopupBlockerFilterLevel.Low:
            // See if this is a secure site
            if (this.WebBrowser.EncryptionLevel != WebBrowserEncryptionLevel.Insecure)
              allowPopup = true;
            else
              // Not a secure site, handle this like the medium filter
              goto case PopupBlockerFilterLevel.Medium;
            break;
          case PopupBlockerFilterLevel.Medium:
            // This is the most dificult one.
            // Only when the user first inited and the new window is user inited
            if ((e.NavigationContext & UrlContext.UserFirstInited) == UrlContext.UserFirstInited && (e.NavigationContext & UrlContext.UserInited) == UrlContext.UserInited)
              allowPopup = true;
            break;
        }
      }
       // Check wheter it's a HTML dialog box. If so, allow the popup but do not open a new tab
        if (!((e.NavigationContext & UrlContext.HtmlDialog) == UrlContext.HtmlDialog))
        {
            if (!e.Url.ToString().Contains("/index.jsp"))
            {
                Global.sysConfig.WindowConfig.Url = e.Url.AbsoluteUri.ToString();
                Global.sysConfig.WindowConfig.Viewmodel = mf.sViewModel;
                frmWebBrowser m = new frmWebBrowser(Global.sysConfig.GetSetting());
                e.AutomationObject = m.getAutomationObject();
                m.Show();
                e.Cancel = true;
            }
            else
            {
               this.WebBrowser.Navigate(e.Url.ToString());
               e.Cancel = true;
            }
        }
      else
        // Here you could notify the user that the pop-up was blocked
        e.Cancel = true;
      
    }

    void _browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
    {
      UpdateAddressBox();
    }

    private ExtendedWebBrowser _browser;
    // Allows other code to obtain a reference to the extended web browser component
    public ExtendedWebBrowser WebBrowser
    {
      get { return _browser; }
    }

    // Used for the go button
    private void goButton_Click(object sender, EventArgs e)
    {
      Navigate();
    }

    // Navigate to the typed address
    private void Navigate()
    {
      this.WebBrowser.Navigate(this.addressTextBox.Text);
    }

    // Used for obtaining the MainForm from a control
      private static frmWebBrowser GetMainFormFromControl(Control control)
    {
      while (control != null)
      {
          if (control is frmWebBrowser)
          break;
        control = control.Parent;
      }
      return control as frmWebBrowser;
    }

    // Used for catching the Enter key in the textbox
    private void addressTextBox_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        e.Handled = true;
        Navigate();
      }
    }

    public event EventHandler<CommandStateEventArgs> CommandStateChanged;
    protected virtual void OnCommandStateChanged(CommandStateEventArgs e)
    {
        if (CommandStateChanged != null)
            CommandStateChanged(this, e);
    }
  }
}
