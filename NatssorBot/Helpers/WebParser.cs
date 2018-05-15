using HtmlAgilityPack;
using Knyaz.Optimus;
using Knyaz.Optimus.Dom.Elements;
using Knyaz.Optimus.TestingTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatssorBot.Helpers
{
    
    class WebParser
    {
         StringBuilder TitleList = new StringBuilder();
        bool wait = true;
        public string Schedule()
        {
            int count = 0;
            string Url = "http://anichart.net/?season=Spring&year=2018&type=Tv&sort=-popularity";
            var engine = new Engine();
            //engine.OpenUrl("https://myanimelist.net/anime/season/schedule");
            engine.OpenUrl("https://www.livechart.me/schedule/tv");
            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument doc = web.Load(Url);



            //Uri uri = new Uri("http://www.somewebsite.com/somepage.htm");

            //System.Windows.Forms.WebBrowser webBrowserControl = new System.Windows.Forms.WebBrowser();
            //webBrowserControl.AllowNavigation = true;
            //// optional but I use this because it stops javascript errors breaking your scraper
            //webBrowserControl.ScriptErrorsSuppressed = true;
            //// you want to start scraping after the document is finished loading so do it in the function you pass to this handler
            //webBrowserControl.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowserControl_DocumentCompleted);
            //webBrowserControl.Navigate(uri);

            //   
            foreach (var title in engine.WaitSelector(".title-text"))//engine.Document.GetElementsByClassName("title"))
            {
                TitleList.Append(title.TextContent + "\n");
            }
            //foreach (var title in doc.DocumentNode.Descendants())
            //{
            //TitleList.Append(title.GetClasses() + "\n");
            //}

            //while(wait)
            //{
            //count++;
            //System.Console.WriteLine("waited " + count + "cycles");



            //}

            System.Console.WriteLine(TitleList.ToString());
            return TitleList.ToString();
        }

        //private void webBrowserControl_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
            //var browser = (System.Windows.Forms.WebBrowser)sender;
            //HtmlElementCollection divs = browser.Document.GetElementsByTagName("div");
            //foreach( System.Windows.Forms.HtmlElement div in divs.GetElementsByName("title"))
            //{
                //TitleList.Append(div.InnerHtml);
            //}

            //wait = false;

        //}
    }
}
