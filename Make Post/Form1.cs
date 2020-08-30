using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;


namespace Make_Post
{
    public partial class BaseInterface : Form
    {
        public BaseInterface()
        {
            InitializeComponent();
            tbox_path.Enabled = false;
        }

        public String FilePath { get; set; }
        public String NewFilePath { get; set; }
        public String NewFilePathBase = "C:\\Users\\AirBu\\Documents\\blu web\\thoughts\\";
        public String NewBookPathBase = "C:\\Users\\AirBu\\Documents\\blu web\\books\\";
        public String ThoughtsHomePath = "C:\\Users\\AirBu\\Documents\\blu web\\thoughts home.html";
        public String BookHomePath = "C:\\Users\\AirBu\\Documents\\blu web\\thoughts\\books.html";
        public List<string> ContentList = new List<string>();
        public List<string> LastPostContentList = new List<string>();
        public List<string> NewBookContentList = new List<string>();
        public List<string> ThoughtHomeContentList = new List<string>();
        public List<string> BookHomeContentList = new List<string>();
        public List<string> FilesToUpload = new List<string>();
        public String Title { get; set; }
        public String BookTitle { get; set; }

        public String LastPost = Properties.Settings.Default.LastPost;
        private void btn_chooseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                FilePath = openFileDialog.FileName;
                tbox_path.Text = FilePath;
                tbox_fileContent.Text = File.ReadAllText(FilePath);
                btn_createNewFile.Enabled = true;
            }
        }
     
        private void btn_createNewFile_Click(object sender, EventArgs e)
        {
            if (cmbbox_postType.Text == "Thought")
            {
                CreateNewFile();
                UpdateLastFile();
                UpdateThoughtsHome();
                btn_editlastPost.Enabled = false;
                btn_putFiles.Enabled = true;
            }
            else
            {
                CreateBookPage();
                UpdateBooksHome();
                btn_editlastPost.Enabled = false;
                btn_putFiles.Enabled = true;
            }
        }
        //adds html code that precedes all posts to content list
        private void BeginningHtml(List<string> contentList, string title, bool isBook)
        {
            contentList.Add("<!doctype html> ");
            contentList.Add("<html>");
            contentList.Add("<head>");
            contentList.Add(@"<meta charset=""utf - 8"" name=""viewport"" content=""width=device-width,initial-scale=1.0""> ");
            contentList.Add($"<title>{title}</title> ");
            contentList.Add(@"<link rel = ""stylesheet"" href=""../styles.css"">");
            contentList.Add(@"<link rel = ""shortcut icon"" href = ""../icon.ico"">");
            contentList.Add("</head>");
            contentList.Add(@"<body> <div id =""mainContainer"" >");
            contentList.Add("<div>");
            contentList.Add(@"<div class=""dropdown"">");
            contentList.Add(@"<button class=""dropbtn"">Explore</button>");
            contentList.Add(@"<div class=""dropdown-content"">");
            contentList.Add(@"<a href = ""../writing.html""> Text </a>");
            contentList.Add(@"<a href=""../video.html""> Images </a>");
            contentList.Add(isBook ? @"<a href = ""../thoughts/books.html""> Books </a>" : @"<a href = ""books.html""> Books </a>");
            contentList.Add("</div>");
            contentList.Add("</div>");
            contentList.Add(@"<a href=""../index.html"">");
            contentList.Add(@"<div id = ""logo""><img src=""../head.jpg"" alt=""print(Jett)"" class=""center""></div>");
            contentList.Add("</a>");
            contentList.Add("</div>");
            contentList.Add(isBook ? $@"<h1 class=""blurb"">{title}</h1>" : $@"<h1 class=""post"">{title}</h1>");
        }

        private void CreateNewFile()
        {
            try
            {
                Title = Path.GetFileNameWithoutExtension(FilePath);
                NewFilePath = NewFilePathBase + Title + ".html";
                StreamReader file = new StreamReader(FilePath);
                string line;
                bool isFirst = true;
                BeginningHtml(ContentList, Title, false);
                string paragraph = "";
                while ((line = file.ReadLine()) != null)
                {
                    if (isFirst)
                    {
                        paragraph += $"<p> {line}";
                        isFirst = false;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(line)) paragraph += $" {line}";
                        if (string.IsNullOrEmpty(line))
                        {
                            paragraph += " </p>";
                            ContentList.Add(paragraph);
                            paragraph = "<p>";
                        }
                    }
                }

                paragraph += " </p>";
                ContentList.Add(paragraph);
                file.Close();
                ContentList.Add($@"<p> Previous Thought: <a href = ""{LastPost}.html"" class=""thought"">{LastPost}</a></p>");
                ContentList.Add("</div></body>");
                ContentList.Add("</html>");

                using (FileStream fileStream = new FileStream(NewFilePath, FileMode.Create))
                {
                    using (StreamWriter fileWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        foreach (var htmlLine in ContentList)
                        {
                            fileWriter.WriteLine(htmlLine);
                        }
                    }
                }
                FilesToUpload.Add(NewFilePath);
                Utils.UserMessage($"NOICE! File entitled {Title} created!", Globals.MessageTypes.Status);
            }
            catch (Exception exception)
            {
                Utils.UserMessage($"Error encountered while creating file. Error: {exception}", Globals.MessageTypes.Error);
                return;
            }
        }

        private void UpdateLastFile()
        {
            try
            {
                string lastPostSpec = NewFilePathBase + LastPost + ".html";
                StreamReader file = new StreamReader(lastPostSpec);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    LastPostContentList.Add(line);
                }

                var nextThought =
                    $@"<p> Next Thought: <a href = ""{Title}.html"" class=""thought"">{Title}</a></p>";
                LastPostContentList.Insert(LastPostContentList.Count -3, nextThought);
                file.Close();
                using (FileStream fileStream = new FileStream(lastPostSpec, FileMode.Create))
                {
                    using (StreamWriter fileWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        foreach (var htmlLine in LastPostContentList)
                        {
                            fileWriter.WriteLine(htmlLine);
                        }
                    }
                }

                FilesToUpload.Add(lastPostSpec);
                Properties.Settings.Default.LastPost = Title;
                Properties.Settings.Default.Save();
                Utils.UserMessage("Thoughts have been created/ updated. Nice job sir.", Globals.MessageTypes.Status);
            }
            catch (Exception e)
            {
                Utils.UserMessage("Difficulties encountered while updating previous post.", Globals.MessageTypes.Error);
                throw;
            }
            
        }

        private void UpdateThoughtsHome()
        {
            try
            {
                StreamReader file = new StreamReader(ThoughtsHomePath);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    ThoughtHomeContentList.Add(line);
                }
                file.Close();
                ThoughtHomeContentList.Insert(25, $@"<li> <a href = ""thoughts/{Title}.html"" class=""thought"">{Title}</a> </li>");
                using (FileStream fileStream = new FileStream(ThoughtsHomePath, FileMode.Create))
                {
                    using (StreamWriter fileWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        foreach (var htmlLine in ThoughtHomeContentList)
                        {
                            fileWriter.WriteLine(htmlLine);
                        }
                    }
                }

                FilesToUpload.Add(ThoughtsHomePath);
                Utils.UserMessage("Thoughts Home Updated.", Globals.MessageTypes.Status);
            }
            catch (Exception e)
            {
                Utils.UserMessage("Difficulties encountered while updating thoughts home. C'mon dude.", Globals.MessageTypes.Error);
                throw;
            }
            
        }

        private void BaseInterface_Load(object sender, EventArgs e)
        {
            tbox_LastPost.Text = LastPost;
            tbox_LastPost.Enabled = false;
            btn_putFiles.Enabled = false;
            btn_createNewFile.Enabled = false;
            cmbbox_postType.Text = "Thought";
        }

        private void CreateBookPage()
        {
            try
            {
                BookTitle = Path.GetFileNameWithoutExtension(FilePath);
                NewFilePath = NewBookPathBase + BookTitle + ".html";
                StreamReader file = new StreamReader(FilePath);
                string line;
                int count = 0;
                bool isFirst = true;
                BeginningHtml(NewBookContentList, BookTitle, true);
                string paragraph = "";
                while ((line = file.ReadLine()) != null)
                {
                    if (isFirst)
                    {
                        paragraph = $"<p> {line}";
                        isFirst = false;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(line)) paragraph += $" {line}";
                        if (string.IsNullOrEmpty(line))
                        {
                            paragraph += " </p>";
                            NewBookContentList.Add(paragraph);
                            paragraph = "<p>";
                        }
                    }
                }

                paragraph += " </p>";
                NewBookContentList.Add(paragraph);
                file.Close();
                NewBookContentList.Add("</div></body>");
                NewBookContentList.Add("</html>");

                using (FileStream fileStream = new FileStream(NewFilePath, FileMode.Create))
                {
                    using (StreamWriter fileWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        foreach (var htmlLine in NewBookContentList)
                        {
                            fileWriter.WriteLine(htmlLine);
                        }
                    }
                }
                FilesToUpload.Add(NewFilePath);
                Utils.UserMessage($"NOICE! Book File entitled {BookTitle} created!", Globals.MessageTypes.Status);
            }
            catch (Exception exception)
            {
                Utils.UserMessage($"Error encountered while creating book file. Error: {exception}", Globals.MessageTypes.Error);
            }
        }
        private void UpdateBooksHome()
        {
            try
            {
                StreamReader file = new StreamReader(BookHomePath);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    BookHomeContentList.Add(line);
                }
                file.Close();
                BookHomeContentList.Insert(23, $@"<ul> <a href = ""../books/{BookTitle}.html"" class=""book-link"">{BookTitle}</a> </ul>");
                using (FileStream fileStream = new FileStream(BookHomePath, FileMode.Create))
                {
                    using (StreamWriter fileWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        foreach (var htmlLine in BookHomeContentList)
                        {
                            fileWriter.WriteLine(htmlLine);
                        }
                    }
                }
                FilesToUpload.Add(BookHomePath);
                Utils.UserMessage("Books Home Updated.", Globals.MessageTypes.Status);
            }
            catch (Exception e)
            {
                Utils.UserMessage("Difficulties encountered while updating thoughts home. C'mon dude.", Globals.MessageTypes.Error);
                throw;
            }

        }
        public void FileUploadSFTP(bool isConnectionTest, List<string> filesList = null)
        {
            var host = Properties.Settings.Default.Host;
            var port = Properties.Settings.Default.Port;
            var username = Properties.Settings.Default.Username;
            var password = Properties.Settings.Default.Password;
            var remoteThoughtsDirectory = "/home/jettsozq/public_html/thoughts";
            var remoteBooksDirectory = "/home/jettsozq/public_html/books";
            var remoteDirectory = "/home/jettsozq/public_html";
            var currentDirectory = "";


            using (var client = new SftpClient(host, port, username, password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    // returns connection status if IsConnected equals true
                    if (isConnectionTest)
                    {
                        Utils.UserMessage("Connected baby", Globals.MessageTypes.Status);
                        return;
                    }
                    //switches remote directory access based on combo box values
                    switch (cmbbox_postType.Text)
                    {
                        case "Thought":
                            client.ChangeDirectory(remoteThoughtsDirectory);
                            currentDirectory = remoteThoughtsDirectory;
                            break;
                        case "Book Summary":
                            client.ChangeDirectory(remoteBooksDirectory);
                            currentDirectory = remoteBooksDirectory;
                            break;
                    }
                    // uploads each file in FilesToUpload list
                    foreach (var file in FilesToUpload)
                    {
                        // switches directory client writes to based on files in upload list. If files are home pages...sent to public_html
                        // if individual thoughts or books, sent to respective directories within public_html
                        if (file == ThoughtsHomePath)
                        {
                            client.ChangeDirectory(remoteDirectory);
                        }
                        else if (file == BookHomePath)
                        {
                            client.ChangeDirectory(remoteThoughtsDirectory);
                        }
                        else
                        {
                            if(client.WorkingDirectory != currentDirectory) client.ChangeDirectory(currentDirectory);
                        }
                        using (var fileStream = new FileStream(file, FileMode.Open))
                        {

                            client.BufferSize = 4 * 1024; // bypass Payload error large files
                            try
                            {
                                client.UploadFile(fileStream, Path.GetFileName(file));
                            }
                            catch (Exception e)
                            {
                                Utils.UserMessage($"Error while uploading file. Check path and current status of relevant files. {e}", Globals.MessageTypes.Error);
                                return;
                            }
                        }
                    }
                    Utils.UserMessage("Thanks for sharing with the world. Mission complete captain.", Globals.MessageTypes.Status);
                }
                else
                {
                    Utils.UserMessage("Awh. Failed to connect.", Globals.MessageTypes.Error);
                }
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            FileUploadSFTP(true);
        }

        private void btn_putFiles_Click(object sender, EventArgs e)
        {
            FileUploadSFTP(false, FilesToUpload);
        }

        private void btn_editlastPost_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LastPost = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                tbox_LastPost.Text = LastPost;
            }
        }
    }
}
