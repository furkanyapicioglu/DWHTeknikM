using DWHTeknikM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;



namespace DWHTeknikM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriBankaController : ControllerBase
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-54QDQS53;Initial Catalog=DWHTeknikH;Integrated Security=True");
        Musteri musteri = new Musteri();
        // GET: api/<MusteriBankaController>

        //Tum Musterileri Getirme
        [HttpGet]
        public List<Musteri> Get()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Sp_TumMusterileriGoster", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            List<Musteri> listeMusteri = new List<Musteri>();

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Musteri musteri = new Musteri();
                    musteri.MusteriNumarasi = Convert.ToInt32(dataTable.Rows[i]["MusteriNumarasi"]);
                    musteri.Isim = dataTable.Rows[i]["Isim"].ToString();
                    musteri.SoyIsim = dataTable.Rows[i]["soyIsim"].ToString();
                    musteri.DogumYeri = dataTable.Rows[i]["DogumYeri"].ToString();
                    musteri.Yas = Convert.ToInt32(dataTable.Rows[i]["Yas"]);
                    musteri.TcKimlikNo = dataTable.Rows[i]["TcKimlikNo"].ToString();
                    musteri.Email = dataTable.Rows[i]["Email"].ToString();
                    musteri.TelNo = dataTable.Rows[i]["TelefonNo"].ToString();
                    musteri.AktifMi = Convert.ToInt32(dataTable.Rows[i]["AktifMi"]);
                    musteri.GuncellemeTarihi = dataTable.Rows[i]["GuncellemeTarihi"].ToString();
                    musteri.EklemeTarihi = dataTable.Rows[i]["EklemeTarihi"].ToString();

                    listeMusteri.Add(musteri);
                }
            }
            if(listeMusteri.Count > 0)
            {
                return listeMusteri;
            }
            else
            {
                return null;
            }
        }

        // GET api/<MusteriBankaController>/5


        //id'ye göre musterileri getirme
        [HttpGet("{id}")]
        public Musteri Get(int id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Sp_IdBagliMusterileriGoster", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@id",id);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            Musteri musteri = new Musteri();
            if (dataTable.Rows.Count > 0)
            {
                    musteri.MusteriNumarasi = Convert.ToInt32(dataTable.Rows[0]["MusteriNumarasi"]);
                    musteri.Isim = dataTable.Rows[0]["Isim"].ToString();
                    musteri.SoyIsim = dataTable.Rows[0]["soyIsim"].ToString();
                    musteri.DogumYeri = dataTable.Rows[0]["DogumYeri"].ToString();
                    musteri.Yas = Convert.ToInt32(dataTable.Rows[0]["Yas"]);
                    musteri.TcKimlikNo = dataTable.Rows[0]["TcKimlikNo"].ToString();
                    musteri.Email = dataTable.Rows[0]["Email"].ToString();
                    musteri.TelNo = dataTable.Rows[0]["TelefonNo"].ToString();
                    musteri.AktifMi = Convert.ToInt32(dataTable.Rows[0]["AktifMi"]);
                    musteri.GuncellemeTarihi = dataTable.Rows[0]["GuncellemeTarihi"].ToString();
                    musteri.EklemeTarihi = dataTable.Rows[0]["EklemeTarihi"].ToString();

            }
            if (musteri != null)
            {
                return musteri;
            }
            else
            {
                return null;
            }
        }

        // POST api/<MusteriBankaController>

        //musteri ekleme
        [HttpPost]
        public string Post([FromBody] Musteri musteri)
        {
            string mesaj = "";
            if (musteri != null)
            {
                SqlCommand com = new SqlCommand("Sp_MusteriEkleme", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Isim", musteri.Isim);
                com.Parameters.AddWithValue("@SoyIsim", musteri.SoyIsim);
                com.Parameters.AddWithValue("@DogumYeri", musteri.DogumYeri);
                com.Parameters.AddWithValue("@Yas", musteri.Yas);
                com.Parameters.AddWithValue("@TcKimlikNo", musteri.TcKimlikNo);
                com.Parameters.AddWithValue("@Email", musteri.Email);
                com.Parameters.AddWithValue("@TelNo", musteri.TelNo);
                com.Parameters.AddWithValue("@AktifMi", musteri.AktifMi);

                connection.Open();
                int i = com.ExecuteNonQuery();
                connection.Close();

                if (i > 0)
                {
                    return "Müşteri Ekleme İşlemi Başarıyla Tamamlandı...";
                }
                else
                {
                    return "Hata Tespit Edildi...";
                }
            }
            return mesaj;
        }

        // PUT api/<MusteriBankaController>/5 
        
        //musteri güncelleme
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Musteri musteri)
        {
            string mesaj = "";
            if (musteri != null)
            {
                SqlCommand com = new SqlCommand("Sp_MusteriGuncelleme", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@Isim", musteri.Isim);
                com.Parameters.AddWithValue("@SoyIsim", musteri.SoyIsim);
                com.Parameters.AddWithValue("@DogumYeri", musteri.DogumYeri);
                com.Parameters.AddWithValue("@Yas", musteri.Yas);
                com.Parameters.AddWithValue("@TcKimlikNo", musteri.TcKimlikNo);
                com.Parameters.AddWithValue("@Email", musteri.Email);
                com.Parameters.AddWithValue("@TelNo", musteri.TelNo);
                com.Parameters.AddWithValue("@AktifMi", musteri.AktifMi);

                connection.Open();
                int i = com.ExecuteNonQuery();
                connection.Close();

                if (i > 0)
                {
                    return "Müşteri Güncelleme İşlemi Başarıyla Tamamlandı...";
                }
                else
                {
                    return "Hata Tespit Edildi...";
                }
            }
            return mesaj;
        }

        // DELETE api/<MusteriBankaController>/5

        //musteri silme
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string mesaj = "";
            SqlCommand com = new SqlCommand("Sp_MusteriSilme", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                return "Müşteri Silme İşlemi Başarıyla Tamamlandı...";
            }
            else
            {
                return "Hata Tespit Edildi...";
            }
            
            return mesaj;
        }
    }
}
