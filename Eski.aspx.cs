using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace YeniErasmus.ErasmusTurk
{
    public partial class Eski : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Models.KarsilikliAnlasmalar> University = Sql.KarsilikliAnlasmalar.TumAnlasmalar();
                for (int i = 0; i < (University != null ? University.Count : 0); i++)
                {
                    int flag = 0;
                    for (int s = 0; s < DropDownListBolum.Items.Count; s++)
                        if (DropDownListBolum.Items[s].Text == University[i].UniversiteIsim)
                        { flag = 1; break; }
                    if (flag == 0)
                        DropDownListBolum.Items.Add(University[i].UniversiteIsim);
                }
                LIST(Sql.EskiErasmusOgrencileri.TumEskiErasmusOgrencileri());
            }
        }
        private void LIST(List<Models.EskiErasmusOgrencileri> Liste)
        {
            List<GridViewDos> gridListesi = new List<GridViewDos>();
            for (int m = 0; m < (Liste != null ? Liste.Count : 0); m++)
            {
                GridViewDos yeni = new GridViewDos();
                yeni.AdSoyad = Liste[m].AdSoyad;
                yeni.Bolumİsmi = Liste[m].BolumBilgisi.BolumAdi;
                yeni.GidisYili = Liste[m].GidisYili;
                yeni.Sira = Liste[m].Sira.ToString();
                yeni.Ulke = Liste[m].AnlasmaBilgisi.Ulke;
                yeni.UniAdı = Liste[m].AnlasmaBilgisi.UniversiteIsim;
                gridListesi.Add(yeni);
            }
            GridView1.DataSource = gridListesi;
            GridView1.DataKeyNames = new string[] { "Sira" };
            GridView1.DataBind();
        }

        protected void DropDownListBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListBolum.SelectedValue == "Üniversite Seçiniz(Tümü)")
                LIST(Sql.EskiErasmusOgrencileri.TumEskiErasmusOgrencileri());
            else
                LIST(Sql.EskiErasmusOgrencileri.SorguluOgrenci(DropDownListBolum.Text));

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            if (DropDownListBolum.SelectedValue == "Üniversite Seçiniz(Tümü)")
                LIST(Sql.EskiErasmusOgrencileri.TumEskiErasmusOgrencileri());
            else
                LIST(Sql.EskiErasmusOgrencileri.SorguluOgrenci(DropDownListBolum.Text));
        }
        public class GridViewDos
        {
            public string Sira { get; set; }
            public string AdSoyad { get; set; }
            public string Bolumİsmi { get; set; }
            public string UniAdı { get; set; }
            public string Ulke { get; set; }
            public string GidisYili { get; set; }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace("AdSoyad", "Ad Soyad");
                    e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace("Bolumİsmi", "Bölüm");
                    e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace("UniAdı", "Üniversite");
                    e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace("Ulke", "Ülke");
                    e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace("GidisYili", "Gidiş Yılı");
                }
            }
        }
    }

}