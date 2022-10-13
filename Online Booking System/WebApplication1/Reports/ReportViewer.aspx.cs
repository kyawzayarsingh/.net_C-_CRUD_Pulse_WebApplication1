using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Info> infos = new List<Info>();
                TravelTourDBContext _context = new TravelTourDBContext();

                infos = _context.Infos.ToList();

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("ListOfInfo.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WebForms.ReportDataSource("dsData", infos)
                    );
            }
        }
    }
}