using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                string[] assetNames = new string[0];
                int[] electionsRigged = new int[0];
                int[] actsOfSubterfuge = new int[0];

                ViewState.Add("Asset Names", assetNames);
                ViewState.Add("Elections Rigged", electionsRigged);
                ViewState.Add("Acts of Subterfuge", actsOfSubterfuge);
            }
        }

        protected void addAssetButton_Click(object sender, EventArgs e)
        {
            string[] assetNames = (string[])ViewState["Asset Names"];
            int[] electionsRigged = (int[])ViewState["Elections Rigged"];
            int[] actsOfSubterfuge = (int[])ViewState["Acts of Subterfuge"];

            Array.Resize(ref assetNames, assetNames.Length + 1);
            Array.Resize(ref electionsRigged, electionsRigged.Length + 1);
            Array.Resize(ref actsOfSubterfuge, actsOfSubterfuge.Length + 1);

            int highestIndex = assetNames.GetUpperBound(0);

            assetNames[highestIndex] = assetNameTextBox.Text;
            electionsRigged[highestIndex] = int.Parse(electionsRiggedTextBox.Text);
            actsOfSubterfuge[highestIndex] = int.Parse(actsOfSubterfugeTextBox.Text);

            ViewState["Asset Names"] = assetNames;
            ViewState["Elections Rigged"] = electionsRigged;
            ViewState["Acts of Subterfuge"] = actsOfSubterfuge;

            resultLabel.Text = String.Format("Total Elections Rigged: {0} <br/>Average Acts of Subterfuge per Asset: {1:N2} <br/>(Last Asset you Added: {2})", electionsRigged.Sum(), (double)actsOfSubterfuge.Average(), assetNames.Last());
        }
    }
}