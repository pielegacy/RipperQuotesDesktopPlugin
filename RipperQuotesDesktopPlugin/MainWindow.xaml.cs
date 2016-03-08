using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RipperQuotesDesktopPlugin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuoteReader qr = new QuoteReader();
        List<Quotes> quote_list = new List<Quotes>();
        List<Topic> topic_list = new List<Topic>();
        public MainWindow()
        {
            InitializeComponent();
            quote_topic.Visibility = Visibility.Collapsed;
        }
        private void ClearQuote(object sender, RoutedEventArgs e)
        {
            if (quote_content.Text == "Your quote...")
            {
                quote_content.Text = "";
            }
            FillTopics();
        }

        private void ClearAuthor(object sender, RoutedEventArgs e)
        {
            if (quote_author.Text == "The author...")
            {
                quote_author.Text = "";
            }
            FillTopics();
        }
        public void FillTopics()
        {
            if (quote_topic.Items.Count == 0)
            {
                qr.DownloadQuotes();
                foreach (var t in qr.topics())
                {
                    quote_topic.Items.Add(t.TopicName);
                }
            }
            if (quote_topic.Items.Count > 0)
            {
                quote_topic.Visibility = Visibility.Visible;
                quote_list = qr.quotes();
                topic_list = qr.topics();
            }
        }
        private void ShowSubmit(object sender, SelectionChangedEventArgs e)
        {
            quote_submit.Visibility = Visibility.Visible;
        }

        private void LoadShit(object sender, EventArgs e)
        {
            FillTopics();
        }
        private void SubmitQuote(object sender, RoutedEventArgs e)
        {
            Quotes quote = new Quotes();
            quote = new Quotes()
            {
                QuoteId = quote_list[0].QuoteId + 1,
                TopicId = topic_list.Find(t => t.TopicName == quote_topic.SelectedValue.ToString()).TopicId,
                Topic = topic_list.Find(t => t.TopicName == quote_topic.SelectedValue.ToString()),
                QuoteText = quote_content.Text,
                QuoteAuthor = quote_author.Text

            };
            string quote_string = JsonConvert.SerializeObject(quote);
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.UploadString("http://ripperquotes.azurewebsites.net/api/QuotesApi", "POST", quote_string);
                MessageBoxResult success = MessageBox.Show("Quote Posted");
                this.Close();
            }
        }
    }
}
