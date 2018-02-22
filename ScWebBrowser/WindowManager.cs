using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace ScWebBrowser
{
  /// <summary>
  /// Manages the tabs, and their contents
  /// </summary>
  class WindowManager
  {

    /// <summary>
    /// Closes the active tab
    /// </summary>
    public void Close()
    {

    }

    /// <summary>
    /// Opens a new browser tab, and navigates to the home page
    /// </summary>
    /// <returns>The instance of the browser created</returns>
    public ExtendedWebBrowser New()
    {
      return New("about:blank");
    }

    /// <summary>
    /// Opens a new browser tab
    /// </summary>
    /// <param name="navigateHome">true to immediately navigate to the homepage, otherwise false</param>
    /// <returns>The instance of the browser created</returns>
    // We cannot dispose the browsercontrol here
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")]
    public ExtendedWebBrowser New(string pUrl)
    {
      // Create a new tab page
      // Create a new browser control
      BrowserControl browserControl = new BrowserControl();
      // Set the page as the Tag of the browser control, and vice-versa, this will come in handy later
      browserControl.Tag = _mainForm;
      _mainForm.Tag = browserControl;
      // Dock the browser control
      browserControl.Dock = DockStyle.Fill;
      // Add the browser control to the tab page
      _mainForm.panel1.Controls.Add(browserControl);
        // Navigate to the home page
      browserControl.WebBrowser.Navigate(pUrl);
      browserControl.WebBrowser.ScriptErrorsSuppressed = true;
      // Wire some events
      browserControl.WebBrowser.StatusTextChanged += new EventHandler(WebBrowser_StatusTextChanged);
      browserControl.WebBrowser.DocumentTitleChanged += new EventHandler(WebBrowser_DocumentTitleChanged);
      browserControl.WebBrowser.CanGoBackChanged += new EventHandler(WebBrowser_CanGoBackChanged);
      browserControl.WebBrowser.CanGoForwardChanged += new EventHandler(WebBrowser_CanGoForwardChanged);
      browserControl.WebBrowser.Navigated += new WebBrowserNavigatedEventHandler(WebBrowser_Navigated);
      browserControl.WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
      browserControl.WebBrowser.Quit += new EventHandler(WebBrowser_Quit);
      // Add the new page to the tab control
      return browserControl.WebBrowser;
    }


    void WebBrowser_Quit(object sender, EventArgs e)
    {
      // This event is launched when window.close() is called from script
      ExtendedWebBrowser brw = sender as ExtendedWebBrowser;
      if (brw == null)
        return;
      // See which page it was on...
      BrowserControl bc = BrowserControlFromBrowser(brw);
      if (bc == null)
        return;

      MainForm form = bc.Tag as MainForm;
      if(form!=null)
        form.Close();
        form.Dispose();
    }

    public void Open(Uri url)
    {
      ExtendedWebBrowser browser = this.New(url.ToString());
      browser.Navigate(url);
    }

    #region Events that cause the status of toolbar buttons or menu items to change
    void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      CheckCommandState();
    }

    void WebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
    {
      CheckCommandState();
    }

    void WebBrowser_CanGoForwardChanged(object sender, EventArgs e)
    {
      CheckCommandState();
    }

    void WebBrowser_CanGoBackChanged(object sender, EventArgs e)
    {
      CheckCommandState();
    }

    void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      CheckCommandState();
    }

    #endregion


    private void CheckCommandState()
    {
      BrowserCommands commands = BrowserCommands.None;
      if (ActiveBrowser != null)
      {
        if (ActiveBrowser.CanGoBack)
          commands |= BrowserCommands.Back;
        if (ActiveBrowser.CanGoForward)
          commands |= BrowserCommands.Forward;
        if (ActiveBrowser.IsBusy)
          commands |= BrowserCommands.Stop;
        // Add the default commands
        // You could do some aditional checking here. 
        // For example, Home could be disabled if the user is allready on the home page
        commands |= BrowserCommands.Home;
        commands |= BrowserCommands.Search;
        commands |= BrowserCommands.Print;
        commands |= BrowserCommands.PrintPreview;
        commands |= BrowserCommands.Reload;
      }

      //// If it's not the active browser, return aswel..
      //if (extendedWebBrowser != ActiveBrowser)
      //  return;

      OnCommandStateChanged(new CommandStateEventArgs(commands));
    }

    void WebBrowser_DocumentTitleChanged(object sender, EventArgs e)
    {
      // Update the title of the tab page of the control.
      ExtendedWebBrowser ewb = sender as ExtendedWebBrowser;
      // Return if we got nothing (shouldn't happen)
      if (ewb == null) return;

      // This is a little nasty. The Extended Web Browser is nested in 
      // a panel, wich is nested in the browser control
      BrowserControl bc = BrowserControlFromBrowser(ewb);
      // If we got null, return
      if (bc == null) return;
      
      // The Tag of the BrowserControl should point to the TabPage
      MainForm manForm = bc.Tag as MainForm;
      // If not, return
      if (manForm == null) return;

      // Update the tabPage
      // Keep it user-friendly, don't do those awful long web page titles 
      // in tabs and make sure the title is never empty
      string documentTitle = ewb.DocumentTitle;
      if (!string.IsNullOrEmpty(documentTitle))
      {
          manForm.Text = ewb.DocumentTitle;
      }
    }

    void WebBrowser_StatusTextChanged(object sender, EventArgs e)
    {
      // First, see if the active page is calling, or another page
      ExtendedWebBrowser ewb = sender as ExtendedWebBrowser;
      // Return if we got nothing (shouldn't happen)
      if (ewb == null) return;

        // Yep, send the event that updates the status bar text
        OnStatusTextChanged(new TextChangedEventArgs(ewb.StatusText));
    }

    public event EventHandler<TextChangedEventArgs> StatusTextChanged;

    /// <summary>
    /// Raises the StatusTextChanged event
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnStatusTextChanged(TextChangedEventArgs e)
    {
      if (StatusTextChanged != null)
        StatusTextChanged(this, e);
    }

    private static BrowserControl BrowserControlFromBrowser(ExtendedWebBrowser browser)
    {
      // This is a little nasty. The Extended Web Browser is nested in 
      // a panel, wich is nested in the browser control

      // Since we want to avoid a NullReferenceException, do some checking

      // Check if we got a extended web browser
      if (browser == null)
        return null;

      // Check if it got a parent
      if (browser.Parent == null)
        return null;

      // Return the parent of the parent using a safe cast.
      return browser.Parent.Parent as BrowserControl;
    }

    public ExtendedWebBrowser ActiveBrowser
    {
      get
      {
        if (_mainForm != null)
        {

            BrowserControl control = _mainForm.Tag as BrowserControl;
          if (control != null)
            return control.WebBrowser;
        }
        return null;
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
