using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace RipperQuotesDesktopPlugin
{
    public class QuoteBase
    {

    }
    public class QuoteReader
    {
        private static Uri q_url = new Uri("http://ripperquotes.azurewebsites.net/api/QuotesApi");
        private static Uri t_url = new Uri("http://ripperquotes.azurewebsites.net/api/TopicsApi");
        public static List<Quotes> q_list = new List<Quotes>();
        public static List<Topic> t_list = new List<Topic>();
        public List<Quotes> pulled_quote = new List<Quotes>();

        public async void DownloadQuotes()
        {
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage q_response = await http.GetAsync(q_url);
                var q_json = await q_response.Content.ReadAsStringAsync();
                q_list = JsonConvert.DeserializeObject<List<Quotes>>(q_json);
                HttpResponseMessage t_response = await http.GetAsync(t_url);
                var t_json = await t_response.Content.ReadAsStringAsync();
                t_list = JsonConvert.DeserializeObject<List<Topic>>(t_json);

            }
        }
        public List<Quotes> quotes()
        {
            return q_list;
        }
        public List<Topic> topics()
        {
            return t_list;
        }
        public Dictionary<int, string> quotes_dictionary()
        {
            Dictionary<int, string> qd = new Dictionary<int, string>();
            foreach (var q in q_list)
            {
                qd.Add(q.QuoteId, q.QuoteText);
            }
            qd.OrderByDescending(q => q.Key);
            return qd;
        }
        // Pull //
        public async void PullQuote(int id)
        {
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage response = await http.GetAsync(new Uri("http://ripperquotes.azurewebsites.net/api/QuotesApi/" + id));
                var json = await response.Content.ReadAsStringAsync();
                pulled_quote = JsonConvert.DeserializeObject<List<Quotes>>(json);
            }
        }


    }
    public class Quotes
    {
        public int QuoteId { get; set; }
        public int TopicId { get; set; }
        public string QuoteText { get; set; }
        public string QuoteAuthor { get; set; }
        public Topic Topic { get; set; }
        public string QuoteEffect { get; set; }
    }
    //Topic Model//
    public class Topic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public int TopicAmount { get; set; }
    }
}
