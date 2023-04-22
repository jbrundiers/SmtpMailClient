using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using mshtml;
using System.Web;

namespace HtmlEditor
{
    public partial class HtmlEditorControl : UserControl
    {
        private IHTMLDocument2 doc;
       
        public HtmlEditorControl()
        {
            InitializeComponent();
         
            SetupBrowser();
        }


        /// <summary>
        /// Add document body, turn on design mode on the whole document, 
        /// and overred the context menu
        /// </summary>
        private void SetupBrowser()
        {
            webBrowser.DocumentText = "<html><body></body></html>";
            doc = webBrowser.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "On";
            webBrowser.Document.ContextMenuShowing += new HtmlElementEventHandler(Document_ContextMenuShowing);
        }

             
        /// <summary>
        /// Clear the contents of the document, leaving the body intact.
        /// </summary>
        public void Clear()
        {
            if (webBrowser.Document.Body != null)
                webBrowser.Document.Body.InnerHtml = "";

            boldButton.Checked = false;
            italicButton.Checked = false;
            underlineButton.Checked = false;
           
        }

        /// <summary>
        /// Get the web browser component's document
        /// </summary>
        public HtmlDocument Document
        {
            get { return webBrowser.Document; }
        }

        /// <summary>
        /// Document text should be used to load/save the entire document, 
        /// including html and body start/end tags.
        /// </summary>
        [Browsable(false)]
        public string DocumentText
        {
            get
            {
                string html = webBrowser.DocumentText;
                if (html != null)
                {
                    html = ReplaceFileSystemImages(html);
                }
                return html;
            }
            set
            {
                if (value == null)
                    webBrowser.Document.Write("<html><body></body></html>");
                else
                    webBrowser.Document.Write(value);
                //                webBrowser1.DocumentText = value;
            }
        }


        /// <summary>
        /// Get/Set the contents of the document Body, in html.
        /// </summary>
        [Browsable(false)]
        public string BodyHtml
        {
            get
            {
                if (webBrowser.Document != null &&
                    webBrowser.Document.Body != null)
                {
                    string html = webBrowser.Document.Body.InnerHtml;
                    if (html != null)
                    {
                        html = ReplaceFileSystemImages(html);
                    }
                    return html;
                }
                else
                    return string.Empty;
            }
            set
            {
                if (webBrowser.Document.Body != null)
                    webBrowser.Document.Body.InnerHtml = value;
            }
        }



        private string ReplaceFileSystemImages(string html)
        {
            var matches = Regex.Matches(html, @"<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                string src = match.Groups[1].Value;
                src = src.Trim('\"');
                if (File.Exists(src))
                {
                    var ext = Path.GetExtension(src);
                    if (ext.Length > 0)
                    {
                        ext = ext.Substring(1);
                        src = string.Format("'data:image/{0};base64,{1}'", ext, Convert.ToBase64String(File.ReadAllBytes(src)));
                        html = html.Replace(match.Groups[1].Value, src);
                    }
                }
            }
            return html;
        }

        /// <summary>
        /// Get/Set the documents body as text.
        /// </summary>
        [Browsable(false)]
        public string BodyText
        {
            get
            {
                if (webBrowser.Document != null &&
                    webBrowser.Document.Body != null)
                {
                    return webBrowser.Document.Body.InnerText;
                }
                else
                    return string.Empty;
            }
            set
            {
                Document.OpenNew(false);
                if (webBrowser.Document.Body != null)
                    webBrowser.Document.Body.InnerText = HttpUtility.HtmlEncode(value);
            }
        }

      
        public string Html
        {
            get
            {
                if (webBrowser.Document != null &&
                    webBrowser.Document.Body != null)
                {
                    return webBrowser.Document.Body.InnerHtml;
                }
                else
                    return string.Empty;
            }
            set
            {
                Document.OpenNew(false);
                IHTMLDocument2 dom = Document.DomDocument as IHTMLDocument2;
                try
                {
                    if (value == null)
                        dom.clear();
                    else
                        dom.write(value);
                }
                finally
                {
                    dom.close();
                }
            }
        }



        /// <summary>
        /// Determine the status of the Copy command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanCopy()
        {
            return doc.queryCommandEnabled("Copy");
        }

        /// <summary>
        /// Determine the status of the Paste command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanPaste()
        {
            return doc.queryCommandEnabled("Paste");
        }




        /// <summary>
        /// Determine whether the current selection is in Bold mode.
        /// </summary>
        /// <returns>whether or not the current selection is Bold</returns>
        public bool IsBold()
        {
            return doc.queryCommandState("Bold");
        }

        /// <summary>
        /// Determine whether the current selection is in Italic mode.
        /// </summary>
        /// <returns>whether or not the current selection is Italicized</returns>
        public bool IsItalic()
        {
            return doc.queryCommandState("Italic");
        }

        /// <summary>
        /// Determine whether the current selection is in Underline mode.
        /// </summary>
        /// <returns>whether or not the current selection is Underlined</returns>
        public bool IsUnderline()
        {
            return doc.queryCommandState("Underline");
        }

        /// <summary>
        /// Called when the editor context menu should be displayed.
        /// The return value of the event is set to false to disable the 
        /// default context menu.  A custom context menu (contextMenuStrip1) is 
        /// shown instead.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">HtmlElementEventArgs</param>
        private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            e.ReturnValue = false;
            copyContextMenuItem.Enabled = CanCopy();
            pasteContextMenuItem.Enabled = CanPaste();

            contextMenuStrip.Show(this, e.ClientMousePosition);
        }

        /// <summary>
        /// Paste the contents of the clipboard into the current selection.
        /// </summary>
        public void Paste()
        {
            webBrowser.Document.ExecCommand("Paste", false, null);
        }

        /// <summary>
        /// Copy the current selection into the clipboard.
        /// </summary>
        public void Copy()
        {
            webBrowser.Document.ExecCommand("Copy", false, null);
        }

        /// <summary>
        /// Toggle bold formatting on the current selection.
        /// </summary>
        public void Bold()
        {
            webBrowser.Document.ExecCommand("Bold", false, null);
        }

        /// <summary>
        /// Toggle italic formatting on the current selection.
        /// </summary>
        public void Italic()
        {
            webBrowser.Document.ExecCommand("Italic", false, null);
        }

        /// <summary>
        /// Toggle underline formatting on the current selection.
        /// </summary>
        public void Underline()
        {
            webBrowser.Document.ExecCommand("Underline", false, null);
        }

        /// <summary>
        /// Called when the bold button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void boldButton_Click(object sender, EventArgs e)
        {
            boldButton.Checked = !boldButton.Checked;

            Bold();
        }

        /// <summary>
        /// Called when the italic button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void italicButton_Click(object sender, EventArgs e)
        {
            italicButton.Checked = !italicButton.Checked;

            Italic();
        }

        /// <summary>
        /// Called when the underline button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void underlineButton_Click(object sender, EventArgs e)
        {
            underlineButton.Checked = !underlineButton.Checked;

            Underline();
        }

                /// <summary>
        /// Called when the copy button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void copyContextMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        /// <summary>
        /// Called when the paste button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void pasteContextMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

    }
    
}

