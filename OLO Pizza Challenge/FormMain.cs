using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;


namespace OLO_Pizza_Challenge
{
    public partial class FormMain : Form
    {
        string sURL = @"http://files.olo.com/pizzas.json";

        #region CONSTRUCTOR
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region private void Button_ShowPopularCombinations_Click(object sender, EventArgs e)
        private void Button_ShowPopularCombinations_Click(object sender, EventArgs e)
        {
            string sJSON = "";
            List<PizzaOrder> lstPizzasOrdered;
            List<PizzaVariety> lstPizzaVarieties;
            const int iMAX_RESULTS = 20;

            // HIDE ANY PRIOR RESULTS IN CASE OF AN ERROR ON A SUBSEQUENT RUN
            dgvResults.Visible = false;

            #region DOWNLOAD PIZZA ORDERS JSON, IF ERROR SHOW MESSAGE, RETURN
            try
            {
                sJSON = WebRequestGetJSON(sURL);
            }
            catch
            {
                MessageBox.Show("Error downloading pizza order data, please try again.");

                return;
            }
            #endregion

            #region DESERIALIZE JSON INTO LIST OF PIZZAS ORDERED
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                lstPizzasOrdered = jss.Deserialize<List<PizzaOrder>>(sJSON);
            }
            catch
            {
                MessageBox.Show("Error converting pizza order data.  An OLO representative will be in contact to assist you");
                
                // IDEALLY TRIGGER NOTIFICATION TO SUPPORT STAFF
                return;
            }

            //MessageBox.Show("lstPizzasOrdered.Count: " + lstPizzasOrdered.Count);
            #endregion

            #region GROUP THE PIZZAS ORDERED BY NORMALIZED TOPPING COMBINATION, SORT BY ORDER COUNTS (HIGHEST FIRST)
            lstPizzaVarieties = lstPizzasOrdered.GroupBy(po => po.GetNormalizedToppingCombination())
                .Select(pv => new PizzaVariety
                    {
                        ToppingCombination = pv.Key,
                        OrderCount = pv.Count()
                    }
                )
                .OrderByDescending(pvo => pvo.OrderCount).ToList();
            #endregion

            #region LIMIT THE RESULTS SET
            if (lstPizzaVarieties.Count > iMAX_RESULTS)
            {
                lstPizzaVarieties.RemoveRange(iMAX_RESULTS, lstPizzaVarieties.Count - iMAX_RESULTS);
            }
            #endregion

            #region SET THE POPULARITY RANKS (ORDINALLY) 1-BASED
            for (int iIndex = 0; iIndex < lstPizzaVarieties.Count; iIndex++)
            {
                lstPizzaVarieties[iIndex].Rank = iIndex + 1;
            }
            #endregion

            // BIND THE RESULT SET TO RESULTS DATA GRID VIEW
            dgvResults.DataSource = lstPizzaVarieties;

            // SHOW THE RESULTS
            dgvResults.Visible = true;
        }
        #endregion


        #region private static string WebRequestGetJSON(string sURL)
        private static string WebRequestGetJSON(string sURL)
        {
            string sResponse = "";

            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(sURL);
            webReq.Method = WebRequestMethods.Http.Get;
            webReq.Accept = "application/json; charset=utf-8";

            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("HttpStatusCode is not OK");
            }

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    sResponse = streamReader.ReadToEnd();
                }
            }

            return sResponse;
        }
        #endregion

    }


    #region PizzaOrder CLASS
    public class PizzaOrder
    {
        public List<string> Toppings { get; set; }

        public string GetNormalizedToppingCombination()
        {
            // SORT THE TOPPINGS FOR PROPER GROUPING
            List<string> lstSortedToppings = Toppings.OrderBy(t => t).ToList();

            // PUT IN LOWER CASE COMMA DELIMITED STRING
            string sResult = string.Join(", ", lstSortedToppings).ToLower();

            return sResult;
        }
    }
    #endregion

    #region PizzaVariety CLASS
    public class PizzaVariety
    {
        public int Rank { get; set; }
        public string ToppingCombination { get; set; }
        public int OrderCount { get; set; }
    }
    #endregion

}
