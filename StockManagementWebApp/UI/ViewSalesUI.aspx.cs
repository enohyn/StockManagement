using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.UI
{
    public partial class ViewSalesUI : System.Web.UI.Page
    {
        ViewSalesManager viewSalesManager=new ViewSalesManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                userEmailLabel.Text = Session["Email"].ToString();

            }
            else
            {
                Response.Redirect("LoginUI.aspx");
            }
            if (!IsPostBack)
            {
                
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

            if (fromDateCalender.SelectedDate.Date == DateTime.MinValue.Date &&
                toDateCalender.SelectedDate.Date == DateTime.MinValue.Date)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg1()", true);
            }
            else
            {
                DateTime d1 = fromDateCalender.SelectedDate;
                DateTime d2 = toDateCalender.SelectedDate;
                if (d1 <= d2)
                {
                    ViewSalesModel viewSalesModel = new ViewSalesModel();
                    viewSalesModel.FromDate = fromDateCalender.SelectedDate.ToString("dd-MM-yyyy");
                    viewSalesModel.ToDate = toDateCalender.SelectedDate.ToString("dd-MM-yyyy");

                    allSellsItemGridView.DataSource = viewSalesManager.GetAllSellsByDate(viewSalesModel);
                    allSellsItemGridView.DataBind();


                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg()", true);
                    allSellsItemGridView.DataSource = null;

                    allSellsItemGridView.DataBind();
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //int columnsCount = allSellsItemGridView.HeaderRow.Cells.Count;
            //// Create the PDF Table specifying the number of columns
            //PdfPTable pdfTable = new PdfPTable(columnsCount);

            //// Loop thru each cell in GrdiView header row
            //foreach (TableCell gridViewHeaderCell in allSellsItemGridView.HeaderRow.Cells)
            //{
            //    // Create the Font Object for PDF document
            //    Font font = new Font();
            //    // Set the font color to GridView header row font color
            //    font.Color = new BaseColor(allSellsItemGridView.HeaderStyle.ForeColor);

            //    // Create the PDF cell, specifying the text and font
            //    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

            //    // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
            //    pdfCell.BackgroundColor = new BaseColor(allSellsItemGridView.HeaderStyle.BackColor);

            //    // Add the cell to PDF table
            //    pdfTable.AddCell(pdfCell);
            //}

            //// Loop thru each datarow in GrdiView
            //foreach (GridViewRow gridViewRow in allSellsItemGridView.Rows)
            //{
            //    if (gridViewRow.RowType == DataControlRowType.DataRow)
            //    {
            //        // Loop thru each cell in GrdiView data row
            //        foreach (TableCell gridViewCell in gridViewRow.Cells)
            //        {
            //            Font font = new Font();
            //            font.Color = new BaseColor(allSellsItemGridView.RowStyle.ForeColor);

            //            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

            //            pdfCell.BackgroundColor = new BaseColor(allSellsItemGridView.RowStyle.BackColor);

            //            pdfTable.AddCell(pdfCell);
            //        }
            //    }
            //}

            //// Create the PDF document specifying page size and margins
            //Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            //// Roate page using Rotate() function, if you want in Landscape
            //// pdfDocument.SetPageSize(PageSize.A4.Rotate());

            //// Using PageSize.A4_LANDSCAPE may not work as expected
            //// Document pdfDocument = new Document(PageSize.A4_LANDSCAPE, 10f, 10f, 10f, 10f);

            //PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            //pdfDocument.Open();
            //pdfDocument.Add(pdfTable);
            //pdfDocument.Close();

            //Response.ContentType = "application/pdf";
            //Response.AppendHeader("content-disposition",
            //    "attachment;filename=Employees.pdf");
            //Response.Write(pdfDocument);
            //Response.Flush();
            //Response.End();
        }

       
        }

        

      

    }

     
